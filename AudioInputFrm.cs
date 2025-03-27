using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace KCS_Retro
{
    public partial class AudioInputFrm : Form
    {
        public AudioInputFrm()
        {
            InitializeComponent();
        }

        private void AudioInputFrm_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < WaveInEvent.DeviceCount; i++)
            {
                var info = WaveInEvent.GetCapabilities(i);
                comboBox1.Items.Add($"{i}: {info.ProductName}");
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.Items.Add("No input audio devices found!");
                comboBox1.SelectedIndex = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
