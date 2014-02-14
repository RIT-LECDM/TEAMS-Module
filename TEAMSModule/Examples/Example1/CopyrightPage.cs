using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAMSModule;
using WindowsApplication1;
namespace TEAMSModule
{
    public partial class Copyright : Form
    {
        public Copyright()
        {
            InitializeComponent();
        }

        private void Copyright_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TEAMS t = new TEAMS();
            t.Show();
            this.Close();
        }
    }
}
