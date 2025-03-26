using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KCS_Retro
{
    public partial class Settings : Form
    {
        private KansasCityStandardParameters _settings;
        public Settings(KansasCityStandardParameters settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileConfig.SaveKcsSettings(_settings, "config.json");
            Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.AcceptButton = closeBtn;
            baudrate.DataBindings.Add("Text",_settings,nameof(_settings.BaudRate), true,DataSourceUpdateMode.OnPropertyChanged);
            sampleRate.DataBindings.Add("Text", _settings, nameof(_settings.SampleRate), true, DataSourceUpdateMode.OnPropertyChanged);
            oneHz.DataBindings.Add("Text", _settings, nameof(_settings.Frequency1), true, DataSourceUpdateMode.OnPropertyChanged);
            zeroHz.DataBindings.Add("Text", _settings, nameof(_settings.Frequency0), true, DataSourceUpdateMode.OnPropertyChanged);
            leadInDuration.DataBindings.Add("Text", _settings, nameof(_settings.LeadInMinDurationMs), true, DataSourceUpdateMode.OnPropertyChanged);
            leadInHz.DataBindings.Add("Text", _settings, nameof(_settings.LeadInFrequency), true, DataSourceUpdateMode.OnPropertyChanged);
            stopBits.DataBindings.Add("Text", _settings, nameof(_settings.StopBits), true, DataSourceUpdateMode.OnPropertyChanged);
            dataBits.DataBindings.Add("Text", _settings, nameof(_settings.DataBits), true, DataSourceUpdateMode.OnPropertyChanged);
            frequencywiggle.DataBindings.Add("Text", _settings, nameof(_settings.FrequencyToleranceHz), true, DataSourceUpdateMode.OnPropertyChanged);
            bitsPerSample.DataBindings.Add("Text", _settings, nameof(_settings.BitsPerSample), true, DataSourceUpdateMode.OnPropertyChanged);
            channels.DataBindings.Add("Text", _settings, nameof(_settings.Channels), true, DataSourceUpdateMode.OnPropertyChanged);
            foreach (ExportFormat formats in Enum.GetValues(typeof(ExportFormat)))
            {

                switch (formats)
                {

                        case ExportFormat.Ogg: 
                       
                        var jau = exportFormat.Items.Add("OGG file format (*.ogg)");

                        if (_settings.ExportingFormat == formats) { exportFormat.SelectedIndex = jau; }
                        break;
                    case ExportFormat.Wav: 
                        var addz = exportFormat.Items.Add("WAV file format (*.wav)");
                        if (_settings.ExportingFormat == formats) { exportFormat.SelectedIndex = addz; }
                        break;

                    case ExportFormat.Mp3:
                        var addz1 = exportFormat.Items.Add("MP3 file format (*.Mp3)");
                        if (_settings.ExportingFormat == formats) { exportFormat.SelectedIndex = addz1; }
                        break;
                }

          
            }


        }
    }
}
