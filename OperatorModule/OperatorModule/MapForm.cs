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
    public partial class MapForm : Form
    {
        public string GoogleMapUrl
        {
            set;
            get;
        }
        public string AddUrl = "http://localhost:3270/home/AddPost";
        public string AddPostUrl = string.Empty;
        public string SessionGUID { set; get; }
        public MapForm()
        {
            InitializeComponent();
            GoogleMapBrowser.Navigating += new WebBrowserNavigatingEventHandler(GoogleMapBrowser_Navigating);
        }

        void GoogleMapBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            MessageBox.Show(e.Url.ToString());
        }

      
        private void GoogleMapBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void AddPostBtn_Click(object sender, EventArgs e)
        {
            ClusterForm cluster = new ClusterForm();
            
            cluster.ShowDialog();
            bool ok2proceed = false;
            if (!string.IsNullOrEmpty(cluster.ClusterUniqueID))
            {
                AddPostUrl = AddUrl + "?Cluster=" + cluster.ClusterUniqueID;
                ok2proceed = true;
            }
            else if (!string.IsNullOrEmpty(cluster.CreateNewCluster))
            {
                AddPostUrl = AddUrl + "?Cluster=" + cluster.CreateNewCluster;
                ok2proceed = true;
            }

            if (ok2proceed)
            {
                AddPostForm addPost = new AddPostForm();
                addPost.GoogleMap_AddPost = AddPostUrl;
                addPost.ShowInTaskbar = false;
                addPost.TopMost = true;
                addPost.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                addPost.StartPosition = FormStartPosition.CenterScreen;
                addPost.ShowDialog(); 
            }
            //Show Message.. 
            Thread t = new Thread(delegate()
            {
                GoogleMapBrowser.Refresh(WebBrowserRefreshOption.Completely);
                ShowMainMap("http://localhost:3270/");
                
            });
            t.Start();
        }

        public void ShowMainMap(string Url)
        {
            GoogleMapBrowser.Refresh(WebBrowserRefreshOption.Completely);
            GoogleMapBrowser.Navigate(Url);
            
        }

        private void ClusterBtn_Click(object sender, EventArgs e)
        {
            ClusterForm clusterForm = new ClusterForm();
            clusterForm.ShowInTaskbar = false;
            clusterForm.TopMost = true;
            clusterForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            clusterForm.StartPosition = FormStartPosition.CenterScreen;
            clusterForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Show Message..
            Thread t = new Thread(delegate()
            {
                GoogleMapBrowser.Refresh(WebBrowserRefreshOption.Completely);
                ShowMainMap("http://localhost:3270/");
                
            });
            t.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Fix this Button.
            try
            {
                FixPost fix = new FixPost();
                fix.TopMost = false;
                fix.ShowInTaskbar = false;
                fix.StartPosition = FormStartPosition.CenterScreen;
                fix.ShowDialog(this);
            }
            catch {

            }
            Thread t = new Thread(delegate()
            {
                ShowMainMap("http://localhost:3270/");
            });
            t.Start();
        }

        
    }
}
