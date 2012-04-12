using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Serial.Coe25Db;

namespace Serial
{
    public enum StateMessage
    {
        On,
        Off
    }

    public partial class SerialForm : Form
    {
        #region Declarations

        SerialPort comPort = null;
        string portname = "COM17";
        int baudrate = 9600;
        Parity parity = Parity.None;
        StopBits stopbits = StopBits.One;

        string Data = string.Empty;
        int IndexOfInbox = 1;

        public Dictionary<string, string> LatLong = new Dictionary<string, string>();
        int SixAM = 6;
        int SixPM = 18;
        bool SixAMFlag = false;
        bool SixPMFlag = false;
        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        public SerialForm()
        {
            InitializeComponent();
            InitComport();

        }

        /// <summary>
        /// 
        /// </summary>
        void InitializeComport()
        {
            comPort = new SerialPort();
            comPort.PortName = portname;
            comPort.BaudRate = baudrate;
            comPort.Parity = parity;
            comPort.StopBits = stopbits;

            if (!comPort.IsOpen)
	        {
                comPort.Open();
                comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
                comPort.Disposed += new EventHandler(comPort_Disposed);
	        }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comPort_Disposed(object sender, EventArgs e)
        {
            comPort.Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Data = comPort.ReadExisting();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialForm_Load(object sender, EventArgs e)
        {
            InitializeComport();

            SendCommand();
        }
        /// <summary>
        /// 
        /// </summary>
        public void InitComport()
        {
            InitializeComport();

            SendCommand();
        }
        /// <summary>
        /// 
        /// </summary>
        void SendCommand()
        {
            string AT = "AT";
            string ATCFUN0 = "AT+CFUN=0";
            string ATCFUN1 = "AT+CFUN=1";
            string ATCMGF1 = "AT+CMGF=1";
            string ATCPMSME = "AT+CPMS=\"ME\"";
            bool flag = true;
            while (flag)
            {
                WritePort(AT);
                Thread.Sleep(700);
                if (ReadPort().ToLower().Contains("ok"))
                {
                    WritePort(ATCMGF1);
                    Thread.Sleep(700);
                    if (ReadPort().ToLower().Contains("ok"))
                    {
                        WritePort(ATCPMSME);
                        Thread.Sleep(700);
                        if (ReadPort().ToLower().Contains("ok"))
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        WritePort(ATCFUN0);
                        Thread.Sleep(5000);
                        WritePort(ATCFUN1);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Message"></param>
        public void WritePort(string Message)
        {
            comPort.Write(Message + Environment.NewLine);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReadPort()
        {
            return comPort.ReadExisting();
        }
        string ATCMGR = "AT+CMGR=";
        string ATCMGD = "AT+CMGD=";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialTimer_Tick(object sender, EventArgs e)
        {
            WritePort(ATCMGR + IndexOfInbox.ToString());
            Thread.Sleep(500);
            Data = ReadPort();
            //GET Static LatLong Details in Database;
            if (Data.ToLower().Contains("**"))
            {
                string DataHolder = Data;
                string PhoneNumber = ParseSerialNumber(DataHolder);
                string SerialCluster = ParseSerialCluster(DataHolder);
                tbl_Cluster cluster = CheckIfValidCluster(PhoneNumber);
                if (cluster != null) // Hello: Static message
                {
                    //Assign Data to LatLong variable :(Dictionary LatLong);
                    GetLatLong(SerialCluster);
                    WritePort(ATCMGD + IndexOfInbox.ToString()); //Delete message
                }
                else
                WritePort(ATCMGD + IndexOfInbox.ToString()); //Delete message
            }
            else if ( Data.ToLower().Contains("ok"))
                WritePort(ATCMGD + IndexOfInbox.ToString()); //Delete message
            
            IndexOfInbox = IndexOfInbox + 1;
            if (IndexOfInbox > 6)
                IndexOfInbox = 0;
            
            //For 6am-6pm sending message to cluster
            {
                DateTime currentDate = DateTime.Now;

                DateTime sendTime6AM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0,0); // 6:00 AM
                DateTime sendTime6PM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12,12,0); // 6:00 PM


                bool Ok2Proceed = false;
                string State = string.Empty;
                //if (6 == SixAM && !SixAMFlag)
                if (currentDate.TimeOfDay.Hours == sendTime6AM.TimeOfDay.Hours &&
                    currentDate.TimeOfDay.Minutes == sendTime6AM.TimeOfDay.Minutes) 
                {
                    State = StateMessage.Off.ToString();
                    Ok2Proceed = true;
                }
                else if (currentDate.TimeOfDay.Hours == sendTime6PM.TimeOfDay.Hours &&
                         currentDate.TimeOfDay.Minutes == sendTime6PM.TimeOfDay.Minutes)
                {
                    State = StateMessage.On.ToString();
                    Ok2Proceed = true;
                }

                if (Ok2Proceed)
                {
                    SerialTimer.Stop();
                    //Get all Cluster.
                    List<tbl_Cluster> clusters = getAllCluster();
                    clusters.ForEach(delegate(tbl_Cluster cluster)
                    {
                        SendMessageToCluster(State, cluster.ClusterPhoneNumber);
                        Thread.Sleep(3000);
                    });
                    SerialTimer.Start();
                }
            }
        }

        public List<tbl_Cluster> getAllCluster()
        {
            List<tbl_Cluster> clusters = new List<tbl_Cluster>();
            try
            {
                Code25dbDataContext db = new Code25dbDataContext();
                clusters = (from m in db.tbl_Clusters
                            select m).ToList();
            }
            catch (Exception)
            {
                clusters = null;
            }
            return clusters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public tbl_Cluster CheckIfValidCluster(string Data)
        {
            try
            {
                if( !string.IsNullOrEmpty(Data)){
                    Code25dbDataContext db = new Code25dbDataContext();
                    #region Comment
                    //tbl_Post post = (from m in db.tbl_Posts
                    //                 where m.PostSerialNumber == Data
                    //                 select m).SingleOrDefault();
                    //if (post != null)
                    //    flag = true; 
                    #endregion

                    tbl_Cluster cluster = new tbl_Cluster();
                    cluster = (from m in db.tbl_Clusters
                               where m.ClusterPhoneNumber == Data
                               select m).FirstOrDefault();
                    if (cluster != null)
                    {
                        return cluster;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public string ParseSerialNumber(string Message)
        {
            string number = "";
            try
            {
                if (Message.ToLower().Contains("+63"))
                {
                    //getnumber
                    int i = Message.IndexOf("+63");
                    number = Message.Substring(i, 13);
                    number = number.Replace("+63", "0");
                }
                else if (Message.Contains("09"))
                {
                    //getnumber
                    int i = Message.IndexOf("09");
                    number = Message.Substring(i, 11);
                }
            }
            catch { }
            return number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public string ParseSerialCluster(string Message)
        {
            string SerailNumber = "";
            try
            {
                if (Message.ToLower().Contains("**"))
                {
                    //getnumber
                    int i = Message.IndexOf("**");
                    SerailNumber = Message.Substring(i + 2, 4);
                }
            }
            catch { }
            return SerailNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        public void GetLatLong(string ClusterNumber)
        {
            try
            {
                Code25dbDataContext db = new Code25dbDataContext();
                tbl_Post post = (from m in db.tbl_Posts
                                       where m.PostSerialNumber == ClusterNumber
                                       select m).FirstOrDefault();

                if (post != null)
                {
                    tbl_Map map = (from m in db.tbl_Maps
                                   where m.PostID == post.ID
                                   select m).FirstOrDefault();
                    LatLong.Add("lat", map.Latitude);
                    LatLong.Add("long", map.Longitude);
                    LatLong.Add("PostID", string.Format("Event Occurred in this Post \"{0}\" Serial Number: {1}   ", post.PostName, post.PostSerialNumber));
                    //Insert New Session
                    LatLong.Add("SessionGUID",InsertNewSession(map.Latitude, map.Longitude));
                }
            }
            catch (Exception)
            {
            }
        }

        public string InsertNewSession(string Lat, string Long)
        {
            try
            {
                Code25dbDataContext db = new Code25dbDataContext();

                tbl_Map map = (from m in db.tbl_Maps
                               where m.Latitude == Lat && m.Longitude == Long
                               select m).FirstOrDefault();
                if (map != null)
                {
                    tbl_History history = new tbl_History();
                    history.PostID = map.PostID;
                    history.SessionGUID = Guid.NewGuid().ToString().Replace("-","");
                    history.CreateDate = DateTime.Now;
                    history.IsFixed = false;
                    db.tbl_Histories.InsertOnSubmit(history);
                    db.SubmitChanges();
                    return history.SessionGUID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string> GetLatLong()
        {
            return LatLong;
        }

        public string GetSystemLogs()
        {
            return comPort.ReadExisting();
        }

        public void SendMessageToCluster(string message, string PhoneNumber)
        {
            Thread t = new Thread(delegate()
            {
                try
                {
                    string Message = "AT + CMGS = \"" + PhoneNumber + "\"";

                    WritePort(Message);
                    Thread.Sleep(500);

                    string data = this.comPort.ReadExisting();
                    if (data.ToLower().Contains('>'))
                    {
                        Message = message + (char)(26);
                        WritePort(Message);

                        Thread.Sleep(1000);
                        data = this.comPort.ReadExisting();

                        if (data.ToLower().Contains("ok"))
                        {
                            //Successful
                            //MessageBox.Show("Success! Sending Message to Cluster");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            t.Start();
        }
    }
}
