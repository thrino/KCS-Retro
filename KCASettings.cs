using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS_Retro
{
    public enum ExportFormat
    {
        None = 0,
        Wav = 1,
        Mp3 = 2,
        Ogg = 3
    }
    public class KansasCityStandardParameters
    {
        // Audio / Sampling
        public int SampleRate { get; set; } = 44100;      // Hz
        public int BitsPerSample { get; set; } = 16;      // Typically 16-bit PCM
        public int Channels { get; set; } = 1;            // Mono

        // Kansas City Frequencies
        public double Frequency0 { get; set; } = 1200.0;  // Hz for binary '0'
        public double Frequency1 { get; set; } = 2400.0;  // Hz for binary '1'

        // Transmission properties
        public int BaudRate { get; set; } = 300;          // Bits per second
        public int DataBits { get; set; } = 8;            // Bits per byte
        public int StopBits { get; set; } = 1;            // Number of stop bits

        public ExportFormat ExportingFormat { get; set; } = ExportFormat.Wav;
        // Lead-in detection
        public double LeadInFrequency { get; set; } = 2400.0;    // Frequency to detect start
        public int LeadInMinDurationMs { get; set; } = 300;      // Minimum ms of 2400 Hz to start recording

        // Detection sensitivity / tolerance
        public double FrequencyToleranceHz { get; set; } = 200.0; // Acceptable deviation for frequency detection

        // Termination behavior
        public int MaxSilenceDurationMs { get; set; } = 1000;    // Max silence or pure stop bits before ending capture

        // Optional parity (future expansion)
        public bool UseParity { get; set; } = false;

        // Debugging / Logging
        public bool EnableDebug { get; set; } = false;
    }
}
