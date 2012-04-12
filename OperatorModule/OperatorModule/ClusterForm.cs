using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OperatorModule.Database;

namespace OperatorModule
{
    public partial class ClusterForm : Form
    {
        public string CreateNewCluster = string.Empty;
        public string ClusterUniqueID = string.Empty;
        public ClusterForm()
        {
            InitializeComponent();
            this.textBox2.Text = getUniqueID();
        }


        public string getUniqueID()
        {
            Random rand = new Random();
            string temp = string.Empty;
            string UniqueID = string.Empty;
            bool running = true;
            try
            {
                Coe25DBDataContext db = new Coe25DBDataContext();
                while (running)
                {
                    temp = rand.Next(0, 9).ToString();
                    if (!string.IsNullOrEmpty(temp))
                    {
                        UniqueID = UniqueID + temp;
                    }
                    if (UniqueID.Length == 5)
                    {
                        var dbChecker = (from m in db.tbl_Clusters
                                         where m.UniqueCode == UniqueID
                                         select m).FirstOrDefault();
                        if (dbChecker != null)
                        {
                            UniqueID = string.Empty;
                        }
                        else
                        {
                            running = false;
                            break;
                        }
                    }
                }
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return UniqueID;
        }

        private void ClusterForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = getAllCluster();
        }

        public List<string> getAllCluster()
        {
            Coe25DBDataContext db = new Coe25DBDataContext();
            List<string> clusters = new List<string>();
            try
            {
                clusters = (from m in db.tbl_Clusters
                            select m.UniqueCode).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return clusters;
        }

        public tbl_Cluster getClusterByText(string Value)
        {
            Coe25DBDataContext db = new Coe25DBDataContext();
            return db.tbl_Clusters.FirstOrDefault(c => c.UniqueCode == Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get Cluster base from this.comboBox1.SelectedText
            tbl_Cluster cluster = getClusterByText(this.comboBox1.SelectedItem.ToString());
            if (cluster != null)
            {
                ClusterUniqueID = cluster.UniqueCode;
                this.Close();
            }
        }

        public string GetCluster()
        {
            return ClusterUniqueID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_Cluster cluster = new tbl_Cluster();
                cluster.UniqueCode = this.textBox2.Text;
                cluster.ClusterPhoneNumber = this.textBox1.Text;
                cluster.CreateDate = DateTime.UtcNow;
                Coe25DBDataContext db = new Coe25DBDataContext();
                db.tbl_Clusters.InsertOnSubmit(cluster);
                db.SubmitChanges();
                db.Dispose();
                CreateNewCluster = cluster.UniqueCode;
                this.Close();
            }
            catch { }
        }
        public string GetCreateNewCluster()
        {
            return CreateNewCluster;
        }
    }
}
