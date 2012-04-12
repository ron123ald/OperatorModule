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
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
            
        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( Type.SelectedItem.ToString().ToLower() != "none")
            {
                ContinueBtn.Enabled = true;
            }
            else
                ContinueBtn.Enabled = false;
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            string Selection = Type.SelectedItem.ToString();
            History history = null;
            if (Selection.Equals("cluster", StringComparison.InvariantCultureIgnoreCase)) // Cluster
                history = new History("cluster");
            else // Post
                history = new History("postid");
            Hide();
             
            history.StartPosition = FormStartPosition.CenterScreen;
            history.Text += " by " + Type.SelectedItem.ToString();
            history.ShowDialog();
            Show();
        }

    }
}
