using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serial.Coe25Db;

namespace OperatorModule
{
    public partial class History : Form
    {
        public Code25dbDataContext db = new Code25dbDataContext();
        public string type { get; set; }
        
        public History(string type)
        {
            InitializeComponent();
            this.type = type;
            SetSelection();
        }

        public void SetSelection()
        {
            if (this.type.Contains("postid"))
                this.listBox1.DataSource = GetAllHistoryPost();
            else
                this.listBox1.DataSource = GetAllCluster();
        }

        public List<string> GetAllHistoryPost()
        {
            List<string> historyID = null;
            List<int> historyPostID = (from m in db.tbl_Histories
                                       select (int)m.PostID).ToList();
            if (historyPostID.Count > 0)
            {
                string temp;
                historyID = new List<string>();
                historyPostID.ForEach(delegate(int history)
                {
                    //Check if history is in historyID
                    temp = "Post Id: " + history.ToString();
                    if(!IsHistoryIDinList(temp, historyID))
                        historyID.Add(temp);
                }); 
            }

            return historyID;
        }

        public bool IsHistoryIDinList(string ID, List<string> history)
        {
            bool flag = false;
            foreach(string item in history)
            {
                if (item.Equals(ID, StringComparison.InvariantCultureIgnoreCase))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public List<string> GetAllHistoryCluster()
        {
            List<string> historyID = null;
            List<int> clusters = (from m in db.tbl_Clusters
                                  select m.ID).ToList();
            if (clusters.Count > 0)
            {
                historyID = new List<string>();
                string temp = string.Empty;
                clusters.ForEach(delegate(int cluster)
                {
                    //Get All Posts
                    List<int> postsID = GetAllPostIDbyClusterID(cluster);
                    //Get all Events
                    string tempstr = string.Empty;
                    postsID.ForEach(delegate(int item)
                    {
                        this.textBox1.Text += GetHistoryByPostID(item);
                        //Get Cluster by ID
                        int tblcluster = GetClusterByPostID(item);
                        //Check if Cluster is in List
                        if (tblcluster > 0)
                        {
                            tempstr = "Cluster Id: " + tblcluster.ToString();
                            if (!IsHistoryIDinList(tempstr, historyID))
                                historyID.Add(tempstr); 
                        }
                    });
                }); 
            }
            return historyID;
        }

        public List<string> GetAllCluster()
        {
            List<string> AllClusters = null;
            List<string> clusters = new List<string>();
            clusters = (from m in db.tbl_Clusters
                        select m.ID.ToString()).ToList();
            if (clusters.Count > 0)
            {
                AllClusters = new List<string>();
                clusters.ForEach(delegate(string index)
                {
                    index = "Cluster Id: " + index;
                    AllClusters.Add(index);
                });
            }
            return AllClusters;
        }

        public int GetClusterByPostID(int Cluster)
        {
            try
            {
                int post = (from m in db.tbl_Posts
                            where m.Cluster == Cluster
                            select (int)m.Cluster).FirstOrDefault();
                return post;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<int> GetAllPostIDbyClusterID(int ClusterID)
        {
            List<int> postsID = (from m in db.tbl_Posts
                                 where m.Cluster == ClusterID
                                 select (int)m.ID).ToList();
            return postsID;
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string data = ((System.Windows.Forms.ListBox)(sender)).Text;
            if (!string.IsNullOrEmpty(data) && data.Contains("Post Id: "))
            {
                data = data.Replace("Post Id: ", "");
                this.textBox1.Text = GetHistoryByPostID(int.Parse(data));
            }
            else if (!string.IsNullOrEmpty(data) && data.Contains("Cluster Id: "))
            {
                this.textBox1.Text = string.Empty;
                data = data.Replace("Cluster Id: ", "");
                ///Get all Post base from clusterID
                List<int> PostID = GetAllPostIDbyClusterID(int.Parse(data));
                PostID.ForEach(delegate(int index)
                {
                    this.textBox1.Text += GetHistoryByPostID(index);
                });
            }
        }

        public string GetHistoryByPostID(int PostID)
        {
            string temp = string.Empty;
            try
            {
                List<tbl_History> history = (from m in db.tbl_Histories
                                             where m.PostID == PostID
                                             select m).ToList();
                
                history.ForEach(delegate(tbl_History indexHistory)
                {
                    temp += "Post Id: " + indexHistory.PostID.ToString() + Environment.NewLine;
                    temp += "Date of triggered event: " + indexHistory.CreateDate + Environment.NewLine + Environment.NewLine;
                });
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return temp;
        }
    }
}
