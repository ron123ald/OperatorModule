using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OperatorModule.Database;
using System.Threading;

namespace OperatorModule
{
    public partial class FixPost : Form
    {
        int PostIdentity = 0;
        public FixPost()
        {
            InitializeComponent();
            SetListBox();
        }

        public void SetListBox()
        {
            List<string> listBox = getAllPostInHistory();
            if (listBox != null)
                this.listBox1.DataSource = listBox;
            //else
            //    this.textBox1.Text = string.Empty;
        }

        public List<string> getAllPostInHistory()
        {
            Coe25DBDataContext db = new Coe25DBDataContext();
            List<string> posts = null;
            List<int> postId = new List<int>();
            try
            {
                postId = (from m in db.tbl_Histories
                          where m.IsFixed == false
                          select (int)m.PostID).ToList();
                if (postId.Count > 0)
                {
                    this.button1.Enabled = true;
                    posts = new List<string>();
                    string temp = string.Empty;
                    postId.ForEach(delegate(int index)
                    {
                        temp = "Post Id: " + index.ToString();
                        if (!IsHistoryIDinList(temp, posts))
                            posts.Add(temp);
                    });
                }
                else
                {
                    this.button1.Enabled = false;
                    MessageBox.Show("All Post is Fixed.");
                    this.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return posts;
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string temp = string.Empty;
            string data = ((System.Windows.Forms.ListBox)(sender)).Text;
            if (!string.IsNullOrEmpty(data) && data.Contains("Post Id: "))
            {
                data = data.Replace("Post Id: ", "");
                this.textBox1.Text = GetHistoryByPostID(int.Parse(data));
                PostIdentity = int.Parse(data);
                //Show map;
                ShowMapByPost();
            }
        }

        public void ShowMapByPost()
        {
            if (PostIdentity > 0)
            {
                Coe25DBDataContext db = new Coe25DBDataContext();
                tbl_Map map = (from m in db.tbl_Maps
                               where m.PostID == PostIdentity
                               select m).FirstOrDefault();
                if (map != null)
                {
                    string Url = string.Format("http://localhost:3270/?lat={0}&long={1}&PostDetail={2}",map.Latitude, map.Longitude, PostIdentity);
                    this.webBrowser1.Navigate(Url);
                }
            }
        }

        public bool IsHistoryIDinList(string ID, List<string> history)
        {
            bool flag = false;
            foreach (string item in history)
            {
                if (item.Equals(ID, StringComparison.InvariantCultureIgnoreCase))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public string GetHistoryByPostID(int PostID)
        {
            string temp = string.Empty;
            try
            {
                Coe25DBDataContext db = new Coe25DBDataContext();
                List<tbl_History> history = (from m in db.tbl_Histories
                                             where m.PostID == PostID &&
                                                   m.IsFixed == false
                                             select m).ToList();
                db.Dispose();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Fix Button
            if (PostIdentity != 0)
            {
                Coe25DBDataContext db = new Coe25DBDataContext();
                List<tbl_History> history = (from m in db.tbl_Histories
                                             where m.PostID == PostIdentity &&
                                                   m.IsFixed == false
                                             select m).ToList();
                if (history.Count > 0)
                {
                    history.ForEach(delegate(tbl_History hist)
                    {
                        hist.IsFixed = true;
                    });
                    db.SubmitChanges();
                    MessageBox.Show("POST is Fix.");
                    SetListBox();
                }
            } 
        }
    }
}
