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
    public partial class MessageDialogBox : Form
    {

        public MessageDialogBox()
        {
            InitializeComponent();
            SetTimer();
        }
        public void SetTimer()
        {
            Timer time = new Timer();
            time.Interval = 100;
            time.Enabled = true;
            time.Tick += new EventHandler(time_Tick);
        }

        void time_Tick(object sender, EventArgs e)
        {

        }
    }
}
