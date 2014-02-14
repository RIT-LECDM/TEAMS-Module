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
    public partial class ResultsSheet : Form
    {
        double percent;
        public ResultsSheet(TEAMS t)
        {
            percent = t.EfficiencyForPetroleumRecovery;
            InitializeComponent();
        }

        private void ResultsSheet_Load(object sender, EventArgs e)
        {
            percent = percent * 5;
            int cent = (int)percent;
            button2.Height = cent;
            button2.Location = new Point(button1.Location.X + button1.Width + 10, button1.Location.Y + (button1.Height - button2.Height));
        }
    }
}
