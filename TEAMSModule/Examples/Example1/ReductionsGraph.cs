using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace TEAMSModule
{
    public partial class ReductionsGraph : Form
    {
        public ResultsSheet res;
        public ReductionsGraph(ResultsSheet rs)
        {
            res = rs;
            InitializeComponent();
        }

        private void BarGraphSheet_Load(object sender, EventArgs e)
        {
            // The series that you are working with
            string series = "total_energy";

            // All values formatted as *percentages*
            double natural_gas = .245;
            double biodiesel = .173;
            double dmb = -.035;
            double dma = -.045;
            double ifo = .0645;

            // Set containing all resources
            double[] resources = { natural_gas, biodiesel, dmb, dma, ifo };

            Generate_Graph(resources, series);
        }
        /// <summary>
        /// Generates the horizontal bar graph with the specified data.
        /// </summary>
        /// <param name="resources">A set containing all resource values: { %natural_gas%, %biodiesel%, %dmb%, %dma%, %ifo% }</param>
        /// <param name="series">The name of the chart series you are working with (see the designer / make your own within it.</param>
        private void Generate_Graph(double[] resources, string series)
        {
            for (int r = 0; r < resources.Length; r++)
            {
                chart1.Series[series].Points.AddY(resources[r]);
            }
        }

  
         
         
    }
}
