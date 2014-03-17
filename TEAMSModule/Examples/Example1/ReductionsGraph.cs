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
            // All values formatted as **percentages**, with 1.0 being 100%
            public double residual_oil;
            public double low_sulfur;
            public double biodiesel;
            public double natural_gas;
            public double fischer_tropsch;
            public string title;

        public ReductionsGraph(double RO, double LSD, double BD, double NG, double FTD, string graphTitle)
        {
            InitializeComponent();
            residual_oil = RO;
            low_sulfur = LSD;
            biodiesel = BD;
            natural_gas = NG;
            fischer_tropsch = FTD;
            title = graphTitle;
            example_total_energy_consumption();
        }

        /// <summary>
        /// Example of setting up the values to be used by Generate_Graph().
        /// These values will be grabbed from the GREETFormattedResults in production.
        /// </summary>
        private void example_total_energy_consumption()
        {
            // Set containing all resources
            double[] resources = {residual_oil, low_sulfur, biodiesel, natural_gas, fischer_tropsch};

            // Title to display on the graph.
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
