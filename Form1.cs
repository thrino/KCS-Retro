
using System.Text;
using NAudio.Wave;

namespace KCS_Retro
{
    public partial class Form1 : Form
    {
        private readonly KansasCityStandard _kcs;
        private KansasCityStandardParameters _kcsParams = new KansasCityStandardParameters();
        public List<(string, string)> FilestoRecord = new List<(string, string)>();
        public Form1()
        {
            _kcs = new KansasCityStandard(_kcsParams);

            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Load dat shit
            fileList.View = View.Details;
            fileList.FullRowSelect = true;
            fileList.Columns.Add("Filename", 200);
            fileList.Columns.Add("Path", 300);
            fileList.Columns.Add("Filesize", 100);

            fileList.Columns.Add("Recording time", 100);
            fileList.Columns.Add("WAV size", 100);
            string settingsFile = "config.json";
            _kcsParams = FileConfig.LoadKcsSettings(settingsFile);

            // ...bruk kcsParams som normalt


        }

        private void openFileDialog1_HelpRequest(object sender, EventArgs e)
        {

        }



        private async void button4_Click_1(object sender, EventArgs e)
        {

        }
        private void button1_Click_2(object sender, EventArgs e)
        {


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadFromWAVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fromWAVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "WAV filer (*.wav)|*.wav";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var reader = new AudioFileReader(ofd.FileName);
                List<short> samples = new();
                var buffer = new float[reader.WaveFormat.SampleRate];
                int read;
                long totalBytes = reader.Length;
                long bytesRead = 0;

                // Sett opp ProgressBar
                progressBar.ProgressBar.Invoke(() => { progressBar.Value = 0; progressBar.Maximum = 100; });

                // Les samples med progress
                while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    samples.AddRange(buffer.Take(read).Select(f => (short)(f * short.MaxValue)));
                    bytesRead += read;

                    // Oppdater progress
                    double progress = (double)bytesRead / totalBytes;
                    progressBar.ProgressBar.Invoke(() => progressBar.Value = (int)(progress * 100));
                }

                // Dekod KCS blokkene
                var decodedBlocks = _kcs.DecodeMultipleBlocks(samples.ToArray());

                // Sjekk for KCS_FILES header
                string header = Encoding.ASCII.GetString(decodedBlocks[0]);
                List<string> filenames = new();

                if (header.StartsWith("KCS_FILES"))
                {
                    var parts = header.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    filenames = parts.Skip(1).ToList(); // Filnavnene
                                                        // decodedBlocks.RemoveAt(0); // Fjern metadata-blokken
                }

                // Lagre ut filene med navn eller fallback
                for (int i = 0; i < decodedBlocks.Count; i++)
                {
                    string fileName = (i < filenames.Count) ? filenames[i] : $"file_{i + 1}.bin";
                    File.WriteAllBytes(fileName, decodedBlocks[i]);
                }

                // Ferdig progress
                progressBar.ProgressBar.Invoke(() => progressBar.Value = 100);
                MessageBox.Show($"Dekodet {decodedBlocks.Count} filer fra WAV!");
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsFrm = new Settings(_kcsParams);
            settingsFrm.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog1.FileName;
                string fileName = Path.GetFileName(fullPath);
                byte[] fileBytes = File.ReadAllBytes(fullPath);

                // Beregn opptakstid for DENNE filen alene
                var recordingTime = _kcs.CalculateRecordingTime(
                    new List<(string FileName, byte[] Content)> { (fileName, fileBytes) },
                    includeFileNames: checkBox1.Checked
                );

                var calculateWaveSize = _kcs.CalculateWavSize(
                    new List<(string FileName, byte[] Content)> { (fileName, fileBytes) },
                    includeFileNames: checkBox1.Checked
                );
                FileInfo fi = new FileInfo(fullPath);
                long fileSizeBytes = fi.Length;
                double fileSizeKB = fileSizeBytes / 1024.0;
                // Legg til i ListView
                var item = new ListViewItem(fileName);
                item.SubItems.Add(fullPath);
                item.SubItems.Add($"{Math.Round(fileSizeKB)} KB");

                int minutes = (int)(recordingTime.seconds / 60);
                int seconds = (int)(recordingTime.seconds % 60);
                item.SubItems.Add($"{minutes}m {seconds}s");
                item.SubItems.Add($"{(calculateWaveSize / 1024.0 / 1024.0):F2} MB");

                fileList.Items.Add(item);

                // Oppdater samlet status om ønsket:
                // UpdateTotalRecordingTime();
            }
        }

        private async void button4_Click_2(object sender, EventArgs e)
        {
            if (fileList.Items.Count > 0)
            {
                progressBar.Value = 0;
                progressBar.Maximum = 100;

                // Start background Task
                await Task.Run(() =>
                {
                    var files = new List<(string, byte[])>();
                    foreach (ListViewItem file in fileList.Items)
                    {
                        string fileName = file.SubItems[0].Text;   // Kolonne 0 = filnavn
                        string filePath = file.SubItems[1].Text;   // Kolonne 1 = full path
                        files.Add((fileName, File.ReadAllBytes(filePath)));
                    }


                    byte[] pcm = _kcs.EncodeMultipleFiles(files, recordFilenames: checkBox1.Checked, progress =>
                    {
                        // Progress-rapportering må skje på UI-tråd
                        progressBar.ProgressBar.Invoke(() => progressBar.Value = (int)(progress * 100));
                    });

                    // Nå må vi spørre brukeren hvor vi skal lagre, men det må gjøres på UI-tråden
                    Invoke(() =>
                    {
                        saveFileDialog1.Filter = "WAV filer (*.wav)|*.wav";
                        saveFileDialog1.DefaultExt = "wav";
                        saveFileDialog1.FileName = "output_with_filenames.wav";

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            _kcs.SaveToWav(pcm, saveFileDialog1.FileName);
                            MessageBox.Show($"WAV lagret til: {saveFileDialog1.FileName}");
                        }
                    });
                });

                progressBar.Value = 100;
            }
            else
            {
                MessageBox.Show("Æsj da, ingen filer valgt???");
            }
        }

        private void debugButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Baudrate er nå: {_kcsParams.BaudRate}");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (fileList.SelectedItems.Count > 0)
            {
                // Lag en kopi av SelectedItems for å unngå samlingsendring under iterasjon
                var selectedItems = fileList.SelectedItems.Cast<ListViewItem>().ToList();

                foreach (var item in selectedItems)
                {
                    fileList.Items.Remove(item);
                }
            }
        }

        private async void aboutKCSRetroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutFrm = new AboutKCS();
            aboutFrm.TopMost = true;
            aboutFrm.ShowDialog();
        }
    }
}

