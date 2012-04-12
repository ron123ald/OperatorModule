using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using Serial;
using Serial.Coe25Db;
using OperatorModule.Database;
using System.IO;

namespace OperatorModule
{
    public partial class MainForm : Form
    {
        #region Declaration
        
        bool aboutFormIsOpen = false;
        bool mapFormIsOpen = false;
        bool historyFormIsOpen = false;

        HistoryForm history = null;
        MapForm mapform = null;
        SerialForm serialForm = null;
        public MainForm()
        {
            InitializeComponent();
            LoadMainScreen();
        }

        public void LoadMainScreen()
        {
            if (!mapFormIsOpen)
            {
                mapFormIsOpen = true;

                mapform = new MapForm();
                mapform.MdiParent = this;
                mapform.ShowMainMap("http://localhost:3270/");
                mapform.StartPosition = FormStartPosition.CenterScreen;
                mapform.Show();
                mapform.FormClosed += new FormClosedEventHandler(mapform_FormClosed);
            }
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        public void Login()
        {
            LogIn login = new LogIn();
            login.MdiParent = this;
            login.WindowState = FormWindowState.Maximized;
            login.Show();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitSerial();
        }
        /// <summary>
        /// SHOW MENU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void ShowMenu_Click(object sender, EventArgs e)
        //{
        //    if (!mapFormIsOpen)
        //    {
        //        mapFormIsOpen = true;

        //        mapform = new MapForm();
        //        mapform.MdiParent = this;
        //        mapform.StartPosition = FormStartPosition.CenterScreen;
        //        mapform.Show();
        //        mapform.FormClosed += new FormClosedEventHandler(mapform_FormClosed);
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mapform_FormClosed(object sender, FormClosedEventArgs e)
        {
            mapFormIsOpen = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoryMenu_Click(object sender, EventArgs e)
        {
            if (!historyFormIsOpen)
            {
                historyFormIsOpen = true;

                history = new HistoryForm();
                history.MdiParent = this;
                history.TopMost = true;
                history.WindowState = FormWindowState.Normal;

                history.StartPosition = FormStartPosition.CenterParent;
                history.Show();
                history.FormClosed += new FormClosedEventHandler(history_FormClosed); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void history_FormClosed(object sender, FormClosedEventArgs e)
        {
            historyFormIsOpen = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutMenu_Click(object sender, EventArgs e)
        {
            if (!aboutFormIsOpen)
            {
                aboutFormIsOpen = true;
                AboutForm about = new AboutForm();
                about.Show();
                about.FormClosed += new FormClosedEventHandler(about_FormClosed);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void about_FormClosed(object sender, FormClosedEventArgs e)
        {
            aboutFormIsOpen = false;
        }
        #region Serial

        public void InitSerial()
        {
            //CTRL+K+C <- CTRL + K+Uz
            serialForm = new SerialForm();
            
            //serialForm.Show();
            //serialForm.InitComport();
            //serialForm.Hide();//Purpose, Not to show in desktop;
            SerialReader.Enabled = true;
        }

        private void SerialReader_Tick(object sender, EventArgs e)
        {

            Dictionary<string, string> LatLong = serialForm.GetLatLong();
            this.SerialReader.Stop();
            if (LatLong.Count > 0)
            {
                serialForm.LatLong = new Dictionary<string, string>();
                string Lat = LatLong["lat"];
                string Long = LatLong["long"];
                string PostMessage = LatLong["PostID"];
                string SessionGUID = LatLong["SessionGUID"];
                
                //this.serialForm.LatLong = new Dictionary<string, string>();
                Notification notify = new Notification();
                notify.MessageLabel.Text = "EVENT REPORT"; //Static Message;
                PlayMusic();
                if (notify.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    mapform.ShowMainMap(string.Format("http://localhost:3270/?lat={0}&long={1}&PostDetail={2}", Lat, Long, PostMessage));
                }
            }
            this.SerialReader.Start();
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

        #endregion
    }
}
