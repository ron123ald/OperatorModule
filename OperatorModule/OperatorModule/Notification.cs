using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace OperatorModule
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
        }

        public void PlayMusic()
        {
            string MusicFile = OperatorModule.Properties.Resources.Music;

            Thread t = new Thread(delegate()
            {
                try
                {
                    FileInfo file = new FileInfo(MusicFile);

                    if (file.Exists)
                    {
                        System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer(MusicFile);
                        soundPlayer.Play();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to Play Sound");
                }
            });
            t.Start();
        }

        private void Notification_Load(object sender, EventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
