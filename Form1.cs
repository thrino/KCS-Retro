
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using NAudio.Wave;

namespace KCS_Retro
{
    public partial class mainFrm : Form
    {
        private readonly KansasCityStandard _kcs;
        private KansasCityStandardParameters _kcsParams = new KansasCityStandardParameters();
        public List<(string, string)> FilestoRecord = new List<(string, string)>();
        public mainFrm()
        {
            string settingsFile = "config.json";
            _kcsParams = FileConfig.LoadKcsSettings(settingsFile);
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


            progressBar.Anchor = AnchorStyles.Left;

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
            ofd.Filter = "WAV file (*.wav)|*.wav|MP3 file (*.mp3)|*.mp3|OGG file (*.ogg)|*.ogg|Alle filer (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                var response = _kcs.DecodeWavWithOptionalKcsFiles(ofd.FileName, progress =>
progressBar.ProgressBar.Invoke(() => progressBar.Value = (int)(progress * 100))
);


                if (!response.IsSuccess)
                {
                    MessageBox.Show(response.Message, "Feil under dekoding");
                }
                else
                {
                    AudioDataFile result = response.Data;
                    List<byte[]> blocks = result.DataBlocks;
                    List<string> filenames = result.Filenames;
                    if (result.Filenames != null && result.Filenames.Count > 0)
                    {
                        // KCS_FILES ble funnet, vi har filnavn
                        for (int i = 0; i < blocks.Count; i++)
                        {
                            string fileName = (i < result.Filenames.Count) ? result.Filenames[i] : $"file_{i + 1}.bin";
                            File.WriteAllBytes(fileName, blocks[i]);
                        }
                    }
                    else
                    {
                        // Ingen KCS_FILES - vi spør bruker om filnavn
                        for (int i = 0; i < blocks.Count; i++)
                        {
                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.Filter = "Binære filer (*.bin)|*.bin|Alle filer (*.*)|*.*";
                            sfd.FileName = $"file_{i + 1}.bin";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllBytes(sfd.FileName, blocks[i]);
                            }
                        }
                    }
                }

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
                    includeFileNames: recordFilenames.Checked
                );

                var calculateWaveSize = _kcs.CalculateWavSize(
                    new List<(string FileName, byte[] Content)> { (fileName, fileBytes) },
                    includeFileNames: recordFilenames.Checked
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

        private async void recordToFileBtn_Clicked(object sender, EventArgs e)
        {

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

        private async void recordToFileBtn_Click(object sender, EventArgs e)
        {
            if (fileList.Items.Count > 0)
            {
                progressBar.Value = 0;
                progressBar.Maximum = 100;

                // ✅ Hent ut info fra ListView FØR Task.Run
                var filesToProcess = new List<(string, string)>();
                foreach (ListViewItem file in fileList.Items)
                {
                    string fileName = file.SubItems[0].Text;   // Kolonne 0 = filnavn
                    string filePath = file.SubItems[1].Text;   // Kolonne 1 = full path
                    filesToProcess.Add((fileName, filePath));
                }

                // ✅ Start background Task
                await Task.Run(() =>
                {
                    var files = new List<(string, byte[])>();
                    foreach (var file in filesToProcess)
                    {
                        files.Add((file.Item1, File.ReadAllBytes(file.Item2)));
                    }

                    byte[] pcm = _kcs.EncodeMultipleFiles(files, recordFilenames: recordFilenames.Checked, progress =>
                    {
                        // ✅ Oppdater progress trygt på UI-tråden
                        progressBar.ProgressBar.Invoke(() => progressBar.Value = (int)(progress * 100));
                    });

                    // ✅ Lagre WAV må skje på UI
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var audioInputFrm = new AudioInputFrm();
            audioInputFrm.ShowDialog();
        }
    }
}


