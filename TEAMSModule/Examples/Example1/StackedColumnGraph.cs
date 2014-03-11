using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PlugInsInterfaces.DataTypes.Resource;
using PlugInsInterfaces.DataTypes;
using PlugInsInterfaces.DataTypes.Pathway;
using PlugInsInterfaces.DataTypes.Mix;
using PlugInsInterfaces.ResultTypes;
using TEAMSModule;
using System.Windows.Forms.DataVisualization.Charting;
namespace TEAMSModule
{
    public partial class StackedColumnGraph : Form
    {
        public StackedColumnGraph()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This sets up the data for Generate_Graph() to use.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            example_conv_diesel_graph();
        }

        /// <summary>
        /// An example generation of a chart using sample values for the conventional diesel graph.
        /// Other graphs can be constructed similarly.
        /// </summary>
        private void example_conv_diesel_graph()
        {
            //This is just demonstrating the expected contents of each resource set.
            //Actual resource arrays/sets will be filled using calculations from GREET
            

            // resourceType = { %upstream%, %vesseloperation% }
            double[] total_energy = { 50, 25 }; //Resource 0
            double[] fossil_fuels = { 10, 20 }; //Resource 1
            double[] petroleum = { 15, 25 };    //Resource 2
            double[] co2 = { 12, 53 };          //Resource 3
            double[] ch4 = { 44, 22 };          //Resource 4
            double[] n2o = { 40, 20 };          //Resource 5
            double[] ghgs = { 90, 4.5 };        //Resource 6
            double[] voc = { 20, 55 };          //Resource 7
            double[] co = { 60, 10 };           //Resource 8
            double[] nox = { 14, 21 };          //Resource 9
            double[] pm10 = { 50, 25 };         //Resource 10
            double[] sox = { 22, 33 };          //Resource 11

            //Compilation of all resources into one set.
            double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };
            string title = "Your Vessel using Conventional Diesel\nContribution of Each Stage";
            //Generate the graph using the resources set and seriesArray.
            Generate_Graph(resources, stacked_graph, title);
        }


        /// <summary>
        /// Generates the specified graph for display to the user.
        /// </summary>
        /// <param name="resources">A collection of the 12 resources to be modeled by the graph with values: { %upstream%, %vesseloperation% }</param>
        /// <param name="graph">The graph to be generated. Note that this should always be the graph from the designer, 'stacked_graph'.
        /// If you wish to generate another graph, you will need to do more than pass the graph in as a parameter.</param>
        /// <param name="title">The title of the graph to be displayed. These are taken from and match the titles from the graphs in the original TEAMS spreadsheet ~v1.4</param>
        private void Generate_Graph(double[][] resources, Chart graph, string title)
        {
            //Matches the series collection already outlined in the designer.
            string[] seriesArray = { "Upstream", "VesselOperation" };
            //Set the title of the graph to the passed in string title.
            graph.Titles[0].Text = title;
            //Iterate through each of the three series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                //Add each resource value to the respective series from the parent loop.
                for (int r = 0; r < resources.Length; r++)
                {
                    graph.Series[seriesArray[i]].Points.AddY(resources[r][i]);
                }
            }
        }


        
    }
}
