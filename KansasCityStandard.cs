using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using NAudio.Wave;
using System.Diagnostics;

namespace KCS_Retro
{


    public class KansasCityStandard
    {
        private readonly KansasCityStandardParameters _params;
        public KansasCityStandard(KansasCityStandardParameters kcsParams)
        {
            _params = kcsParams;
        }
        public long CalculateWavSize(List<(string FileName, byte[] Content)> files, bool includeFileNames = false)
        {
            double totalBits = 0;

            if (includeFileNames)
            {
                string header = "KCS_FILES " + string.Join(" ", files.Select(f => SanitizeFileName(f.FileName))) + "\n";
                int headerBytes = Encoding.ASCII.GetByteCount(header);
                totalBits += headerBytes * (8 + 1 + _params.StopBits);
                totalBits += (_params.LeadInMinDurationMs / 1000.0) * _params.BaudRate;
            }

            foreach (var file in files)
            {
                int fileBytes = file.Content.Length;
                totalBits += fileBytes * (8 + 1 + _params.StopBits);
                totalBits += (_params.LeadInMinDurationMs / 1000.0) * _params.BaudRate;
            }

            // Beregn samples
            double totalDurationSeconds = totalBits / _params.BaudRate;
            double totalSamples = _params.SampleRate * totalDurationSeconds;

            // Beregn PCM-datastørrelse
            long dataSize = (long)(totalSamples * (_params.BitsPerSample / 8.0) * _params.Channels);

            // WAV-header + data
            long wavSize = 44 + dataSize;
            Console.WriteLine("Baud rate: " + _params.BaudRate);
            return wavSize;
        }



        public byte[] EncodeMultipleFiles(List<(string FileName, byte[] Content)> files, bool recordFilenames, Action<double> progress = null)
        {
            var pcm = new List<byte>();
            int processed = 0;
            int total = files.Count + (recordFilenames ? 1 : 0);

            if (recordFilenames)
            {
                // Lag KCS_FILES header-strengen
                string header = "KCS_FILES " + string.Join(" ", files.Select(f => SanitizeFileName(f.FileName))) + "\n";
                byte[] headerBytes = Encoding.ASCII.GetBytes(header);
                pcm.AddRange(Encode(headerBytes)); // Send som egen KCS audio stream
            }

            foreach (var (fileName, content) in files)
            {
                processed++;
                pcm.AddRange(Encode(content)); // Vanlig KCS-encoding
                pcm.AddRange(GenerateTone(0, _params.SampleRate / 2)); // Stillhet mellom filer
                progress?.Invoke((double)processed / total);
            }

            progress?.Invoke(1.0);
            return pcm.ToArray();
        }
        public async Task<KcsResponse> RecordToAudioOutAsync(List<(string FileName, byte[] Content)> files, int outputDeviceNumber, bool recordFilenames, Action<double> reportProgress = null, CancellationToken cancellationToken = default)
        {
            try
            {
                // Generer PCM-data
                byte[] pcm = EncodeMultipleFiles(files, recordFilenames, reportProgress);

                // Spill av til valgt audio-utgang
                using var ms = new MemoryStream(pcm);
                using var rawSource = new RawSourceWaveStream(ms, new WaveFormat(_params.SampleRate, _params.BitsPerSample, _params.Channels));
                using var waveOut = new WaveOutEvent
                {
                    DeviceNumber = outputDeviceNumber
                };

                waveOut.Init(rawSource);
                waveOut.Play();

                // Vent på ferdig eller cancellation
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        waveOut.Stop();
                        break;
                    }
                    await Task.Delay(100, cancellationToken);
                }
                var successRes = new KcsResponse
                {
                      Code = KcsResponseCode.Success,
                };
                return KcsResponse.Success(new AudioDataFile { DataBlocks = null, Filenames = null });
            }
            catch (Exception ex)
            {
                return KcsResponse.Error(KcsResponseCode.StreamAborted, $"Feil under avspilling: {ex.Message}");
            }
        }

        private string SanitizeFileName(string name)
        {
            // Fjerner mellomrom og non-ASCII, kun [a-zA-Z0-9._-]
            return new string(name.Where(c => c < 127 && (char.IsLetterOrDigit(c) || "_-. ".Contains(c))).ToArray());
        }
        public List<byte[]> DecodeMultipleBlocks(short[] samples)
        {
            var result = new List<byte[]>();
            int samplesPerBit = _params.SampleRate / _params.BaudRate;
            int pos = 0;

            while (pos < samples.Length)
            {
                var chunk = new List<byte>();

                // Lytt på en blokk
                while (pos + samplesPerBit <= samples.Length)
                {
                    double freq = MeasureFreq(samples, pos, samplesPerBit);
                    if (freq < 300) // Stillhet detektert som "gap"
                    {
                        pos += samplesPerBit * 20; // Hopper over stillhet
                        break; // Fil ferdig
                    }

                    if (Math.Abs(freq - _params.Frequency0) < _params.FrequencyToleranceHz)
                    {
                        pos += samplesPerBit;
                        byte b = 0;
                        for (int i = 0; i < _params.DataBits; i++, pos += samplesPerBit)
                        {
                            double bitFreq = MeasureFreq(samples, pos, samplesPerBit);
                            if (bitFreq > (_params.Frequency0 + _params.Frequency1) / 2)
                                b |= (byte)(1 << i);
                        }
                        chunk.Add(b);
                        pos += samplesPerBit * _params.StopBits;
                    }
                    else
                    {
                        pos += samplesPerBit;
                    }
                }

                if (chunk.Count > 0)
                    result.Add(chunk.ToArray());

                // Lytt litt videre for å finne ut om mer data kommer
                if (pos + samplesPerBit * 50 > samples.Length)
                    break; // Nær slutten - stopp
            }

            return result;
        }
        public (double seconds, double minutes) CalculateRecordingTime(List<(string FileName, byte[] Content)> files, bool includeFileNames = false)
        {
            double totalBits = 0;

            // Hvis vi skal ha KCS_FILES header
            if (includeFileNames)
            {
                string header = "KCS_FILES " + string.Join(" ", files.Select(f => SanitizeFileName(f.FileName))) + "\n";
                int headerBytes = Encoding.ASCII.GetByteCount(header);
                totalBits += headerBytes * (8 + 1 + _params.StopBits);
                totalBits += (_params.LeadInMinDurationMs / 1000.0) * _params.BaudRate; // Lead-in
            }

            foreach (var file in files)
            {
                int fileBytes = file.Content.Length;
                totalBits += fileBytes * (8 + 1 + _params.StopBits); // data + start + stop
                totalBits += (_params.LeadInMinDurationMs / 1000.0) * _params.BaudRate; // Lead-in per fil
            }

            double seconds = totalBits / _params.BaudRate;
            double minutes = seconds / 60.0;
            return (seconds, minutes);
        }

        // Genererer PCM-lyd for gitt data
        public byte[] Encode(byte[] data, Action<double> reportProgress = null)
        {
            var pcm = new List<byte>();
            int leadSamples = (_params.SampleRate * _params.LeadInMinDurationMs) / 1000;
            pcm.AddRange(GenerateTone(_params.Frequency1, leadSamples));

            for (int index = 0; index < data.Length; index++)
            {
                byte b = data[index];
                pcm.AddRange(GenerateBit(false)); // Startbit

                for (int i = 0; i < _params.DataBits; i++)
                    pcm.AddRange(GenerateBit((b & (1 << i)) != 0));

                for (int i = 0; i < _params.StopBits; i++)
                    pcm.AddRange(GenerateBit(true)); // Stopbit

                // Report progress per byte
                reportProgress?.Invoke((double)(index + 1) / data.Length);
            }

            reportProgress?.Invoke(1.0);
            return pcm.ToArray();
        }

        // Skriv til .wav-fil
        public void SaveToWav(byte[] pcmData, string path)
        {
            using var fs = new FileStream(path, FileMode.Create);
            using var writer = new BinaryWriter(fs);

            int byteRate = _params.SampleRate * _params.Channels * (_params.BitsPerSample / 8);
            writer.Write(Encoding.ASCII.GetBytes("RIFF"));
            writer.Write(36 + pcmData.Length);
            writer.Write(Encoding.ASCII.GetBytes("WAVEfmt "));
            writer.Write(16); // PCM
            writer.Write((short)1);
            writer.Write((short)_params.Channels);
            writer.Write(_params.SampleRate);
            writer.Write(byteRate);
            writer.Write((short)(_params.Channels * _params.BitsPerSample / 8));
            writer.Write((short)_params.BitsPerSample);
            writer.Write(Encoding.ASCII.GetBytes("data"));
            writer.Write(pcmData.Length);
            writer.Write(pcmData);
        }
        public KcsResponse DecodeWavWithOptionalKcsFiles(string wavFilePath, Action<double> reportProgress = null)
        {
            try
            {
                var reader = new AudioFileReader(wavFilePath);
                List<short> samples = new();
                var buffer = new float[reader.WaveFormat.SampleRate];
                int read;
                long totalSamples = reader.Length / (reader.WaveFormat.BitsPerSample / 8);
                long samplesRead = 0;

                while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    samples.AddRange(buffer.Take(read).Select(f => (short)(f * short.MaxValue)));
                    samplesRead += read;
                    reportProgress?.Invoke((double)samplesRead / totalSamples);
                }

                if (samples.Count == 0)
                {
                    Debug.WriteLine($"No KCS sync signal found!");
                    return KcsResponse.Error(KcsResponseCode.NoLeadIn, "No audio samples found in the WAV file.");
                }
                // Decode blokker
                var decodedBlocks = DecodeMultipleBlocks(samples.ToArray());
                if (decodedBlocks.Count == 0)
                {
                    Debug.WriteLine($"No KCS blocks signal found to decode!");
                    return KcsResponse.Error(KcsResponseCode.DecodingError, "No KCS blocks decoded.");
                }
                // Sjekk for KCS_FILES header
                List<string> filenames = new();
                string header = Encoding.ASCII.GetString(decodedBlocks[0]);
                if (header.StartsWith("KCS_FILES"))
                {
                    Debug.WriteLine($"We have KCS_FILES! Use em!");
                    var parts = header.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    filenames = parts.Skip(1).ToList();
                    //decodedBlocks.RemoveAt(0); // Fjern metadata
                }

                reportProgress?.Invoke(1.0); // Ferdig

                // Retur suksess med dekodede data og evt. filnavn
                Debug.WriteLine($"All files were successfully konverted to DATA!");

                return new KcsResponse
                {
                    Code = KcsResponseCode.Success,
                    Message = "Decoded successfully.",
                    Data = new AudioDataFile { DataBlocks = decodedBlocks, Filenames = filenames }
                };
            }
            catch (Exception ex)
            {
                return KcsResponse.Error(KcsResponseCode.DecodingError, $"Error reading WAV file: {ex.Message}");
            }
        }


        // Lese fra wav og dekode
        public KcsResponse DecodeWav(string path, Action<double> reportProgress = null)
        {
            try
            {
                var reader = new AudioFileReader(path);
                List<short> samples = new();
                var buffer = new float[reader.WaveFormat.SampleRate];
                int read;
                long totalSamples = reader.Length / (reader.WaveFormat.BitsPerSample / 8);
                long samplesRead = 0;

                while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    samples.AddRange(buffer.Take(read).Select(f => (short)(f * short.MaxValue)));
                    samplesRead += read;
                    reportProgress?.Invoke((double)samplesRead / totalSamples);
                }

                if (samples.Count == 0)
                    return KcsResponse.Error(KcsResponseCode.NoLeadIn, "No audio samples found in the WAV file.");

                reportProgress?.Invoke(1.0); // Ferdig
                return DecodeSamples(samples.ToArray());
            }
            catch (Exception ex)
            {
                return KcsResponse.Error(KcsResponseCode.DecodingError, $"Error reading WAV file: {ex.Message}");
            }
        }

        // Sanntidslytting på lydport (krever NAudio)
        public async Task<KcsResponse> ListenAsync(int deviceNumber, Action<double> reportProgress = null, int listenTimeoutMs = 2000, CancellationToken cancellationToken = default)
        {
            try
            {
                var waveIn = new WaveInEvent
                {
                    DeviceNumber = deviceNumber,
                    WaveFormat = new WaveFormat(_params.SampleRate, _params.BitsPerSample, _params.Channels),
                    BufferMilliseconds = 200
                };

                List<short> sampleBuffer = new();
                DateTime lastDataTime = DateTime.Now;
                bool isRecording = true;

                waveIn.DataAvailable += (s, e) =>
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        isRecording = false;
                        waveIn.StopRecording();
                        return;
                    }

                    for (int i = 0; i < e.BytesRecorded; i += 2)
                        sampleBuffer.Add(BitConverter.ToInt16(e.Buffer, i));

                    lastDataTime = DateTime.Now;
                };

                waveIn.StartRecording();

                // Lytter loop
                while (isRecording)
                {
                    await Task.Delay(200, cancellationToken);

                    // Hvis vi har samples og det har vært stille lenge nok, stopp
                    if (sampleBuffer.Count > _params.SampleRate / 2 &&
                        (DateTime.Now - lastDataTime).TotalMilliseconds > listenTimeoutMs)
                    {
                        isRecording = false;
                        waveIn.StopRecording();
                    }
                }

                if (sampleBuffer.Count == 0)
                    return KcsResponse.Error(KcsResponseCode.NoLeadIn, "Ingen lyddata oppdaget.");

                // Bruk samme dekode-flyt som WAV
                var decodedBlocks = DecodeMultipleBlocks(sampleBuffer.ToArray());
                if (decodedBlocks.Count == 0)
                    return KcsResponse.Error(KcsResponseCode.DecodingError, "Ingen KCS-blokker dekodet fra lydstrøm.");

                // Sjekk KCS_FILES
                List<string> filenames = new();
                string header = Encoding.ASCII.GetString(decodedBlocks[0]);
                if (header.StartsWith("KCS_FILES"))
                {
                    var parts = header.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    filenames = parts.Skip(1).ToList();
                    decodedBlocks.RemoveAt(0); // Fjern metadata
                }

                return new KcsResponse
                {
                    Code = KcsResponseCode.Success,
                    Message = "Realtime audio dekodet.",
                    Data = new AudioDataFile { DataBlocks = decodedBlocks, Filenames = filenames }
                };
            }
            catch (Exception ex)
            {
                return KcsResponse.Error(KcsResponseCode.DecodingError, $"Feil under lytting: {ex.Message}");
            }
        }


        // --- Intern dekoder ---
        private KcsResponse DecodeSamples(short[] samples)
        {
            if (samples.Length < _params.SampleRate / 2) // For kort input?
                return KcsResponse.Error(KcsResponseCode.NoLeadIn, "Signal too short or missing lead-in.");

            var result = new List<byte>();
            int samplesPerBit = _params.SampleRate / _params.BaudRate;
            int pos = 0;

            while (pos + samplesPerBit <= samples.Length)
            {
                double freq = MeasureFreq(samples, pos, samplesPerBit);
                if (Math.Abs(freq - _params.Frequency0) < _params.FrequencyToleranceHz)
                {
                    // Startbit funnet, les byte
                    byte b = 0;
                    pos += samplesPerBit;
                    for (int i = 0; i < _params.DataBits; i++, pos += samplesPerBit)
                    {
                        if (pos + samplesPerBit > samples.Length)
                            return KcsResponse.Error(KcsResponseCode.DecodingError, "Unexpected end of stream during data bits.");

                        double bitFreq = MeasureFreq(samples, pos, samplesPerBit);
                        if (bitFreq > (_params.Frequency0 + _params.Frequency1) / 2)
                            b |= (byte)(1 << i);
                    }
                    result.Add(b);
                    pos += samplesPerBit * _params.StopBits;
                }
                else
                {
                    pos += samplesPerBit;
                }
            }

            if (result.Count == 0)
                return KcsResponse.Error(KcsResponseCode.DecodingError, "No valid data decoded.");

            return KcsResponse.SampleDecoded(result.ToArray());
        }

        // --- Genererer tone ---
        private byte[] GenerateBit(bool isOne) =>
            GenerateTone(isOne ? _params.Frequency1 : _params.Frequency0, _params.SampleRate / _params.BaudRate);

        private byte[] GenerateTone(double freq, int samples)
        {
            var ms = new MemoryStream();
            for (int i = 0; i < samples; i++)
            {
                double t = (double)i / _params.SampleRate;
                short sample = (short)(Math.Sin(2 * Math.PI * freq * t) * short.MaxValue);
                ms.Write(BitConverter.GetBytes(sample), 0, 2);
            }
            return ms.ToArray();
        }

        private double MeasureFreq(short[] samples, int start, int length)
        {
            int zeroCrossings = 0;
            bool lastPositive = samples[start] > 0;
            for (int i = start + 1; i < start + length && i < samples.Length; i++)
            {
                bool positive = samples[i] > 0;
                if (positive != lastPositive)
                {
                    zeroCrossings++;
                    lastPositive = positive;
                }
            }
            double durationSec = (double)length / _params.SampleRate;
            return (zeroCrossings / 2.0) / durationSec;
        }
    }
}
