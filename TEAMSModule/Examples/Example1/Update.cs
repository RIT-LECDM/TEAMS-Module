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
    public partial class Update : Form
    {
        TEAMS te;
        public Update(TEAMS t)
        {
            te = t;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            te.pullFromGREET();
        }
    }
}
