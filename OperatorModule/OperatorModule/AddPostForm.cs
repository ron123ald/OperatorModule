using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OperatorModule
{
    public partial class AddPostForm : Form
    {
        public string GoogleMap_AddPost = "";
        public AddPostForm()
        {
            InitializeComponent();
        }

        private void AddPostForm_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(GoogleMap_AddPost);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //Close here.
            if (e.Url.ToString().Contains("PostName"))
            {
                //Show Message Here..
                this.Close();
            }
        }
            
    }
}
