using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace TEAMSModule
{
    public partial class ReductionsGraph : Form
    {
        public ReductionsGraph()
        {
            InitializeComponent();
        }

        private void BarGraphSheet_Load(object sender, EventArgs e)
        {
            total_energy_consumption();
        }

        private void total_energy_consumption()
        {

            // All values formatted as **percentages**, with 1.0 being 100%
            double natural_gas = .245;
            double biodiesel = .173;
            double dmb = -.035;
            double dma = -.045;
            double ifo = .0645;

            // Set containing all resources
            double[] resources = { natural_gas, biodiesel, dmb, dma, ifo };

            // Title to display on the graph.
            string title = "Percent Change in Total Energy Consumption";
            Generate_Graph(resources, reduction_graph, title);
        }

        /// <summary>
        /// Generates the horizontal bar graph with the specified data.
        /// </summary>
        /// <param name="resources">A set containing all resource values: { %natural_gas%, %biodiesel%, %dmb%, %dma%, %ifo% }</param>
        /// <param name="graph">The specific graph you wish to generate. This /should/ always be reduction_graph. To generate another graph, update the designer as well.</param>
        /// <param name="title">The title you wish to assign to the graph.</param>
        private void Generate_Graph(double[] resources, Chart graph, string title)
        {
            // The series that you are working with
            string series = "percent_change";

            // Sets and displays the title for the graph.
            graph.Titles[0].Text = title;

            // Adds value to the specified graph (reduction_graph)
            for (int r = 0; r < resources.Length; r++)
            {
                graph.Series[series].Points.AddY(resources[r]);
            }
        }

  
         
         
    }
}
