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
using PlugInsInterfaces.DataTypes.Resource;
using PlugInsInterfaces.DataTypes;
using PlugInsInterfaces.DataTypes.Pathway;
using PlugInsInterfaces.DataTypes.Mix;
using PlugInsInterfaces.ResultTypes;
using PlugInsInterfaces.DataTypes.Technology;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;
namespace TEAMSModule
{
    public partial class GREETFormattedResults : Form
    {
        public string fuelUsed = "Conventional Diesel";
        public TEAMS te;

        #region All Needed Results Variables
        public double TE_WTP = 101;
        public double TE_VO = 101;
        public double TE_Total = 101;
        public double FF_Total = 101;
        public double CF_Total = 101;
        public double NGF_Total = 101;
        public double PF_Total = 101;
        public double VOC_WTP = 101;
        public double VOC_VO = 101;
        public double VOC_Total = 101;
        public double CO_WTP = 101;
        public double CO_VO = 101;
        public double CO_Total = 101;
        public double NOx_WTP = 101;
        public double NOx_VO = 101;
        public double NOx_Total = 101;
        public double PM10_WTP = 101;
        public double PM10_VO = 101;
        public double PM10_Total = 101;
        public double PM25_WTP = 101;
        public double PM25_VO = 101;
        public double PM25_Total = 101;
        public double SOx_WTP = 101;
        public double SOx_VO = 101;
        public double SOx_Total = 101;
        public double CH4_WTP = 101;
        public double CH4_VO = 101;
        public double CH4_Total = 101;
        public double CO2_WTP = 101;
        public double CO2_VO = 101;
        public double CO2_Total = 101;
        public double N2O_WTP = 101;
        public double N2O_VO = 101;
        public double N2O_Total = 101;

        public double GHG_WTP = 101;
        public double GHG_VO = 101;
        #endregion
        public GREETFormattedResults(TEAMS t)
        {
            //We will use this teams object to pull the GREET values into the TEAMS class, and then reference them here so they can be displayed
            te = t;
            InitializeComponent();
            setValues();
        }
        public void setValues()
        {
            treeView1.Select();
            BuildingTreeView1();
        }

        #region treeView1 After Select function
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Object tag = this.treeView1.SelectedNode.Tag;
            if (tag is IPathway)
            {
                IGDataDictionary<int, IResource> resources = ResultsAccess.controler.CurrentProject.Data.Resources;
                IGDataDictionary<int, IPathway> pathways = ResultsAccess.controler.CurrentProject.Data.Pathways;
                IData data = ResultsAccess.controler.CurrentProject.Data;
                IPathway path = tag as IPathway;
                IResource resourceUsed = ResultsAccess.controler.CurrentProject.Data.Resources.ValueForKey(path.MainOutputResourceID);
                foreach (IResource resource in resources.AllValues.Where(item => item.Id == path.MainOutputResourceID))
                {
                    fuelUsed = resource.Name;
                }
                IResults pathwayResults = path.GetUpstreamResults(data).ElementAt(0).Value;
                //These should be relatively accurate no matter what, since it's a total energy and not the different engines
                TE_WTP = te.MMBTUinperTrip * ((pathwayResults.LifeCycleResources().ElementAt(13).Value.Value + pathwayResults.LifeCycleResources().ElementAt(12).Value.Value + pathwayResults.LifeCycleResources().ElementAt(11).Value.Value + pathwayResults.LifeCycleResources().ElementAt(10).Value.Value + pathwayResults.LifeCycleResources().ElementAt(9).Value.Value + pathwayResults.LifeCycleResources().ElementAt(8).Value.Value + pathwayResults.LifeCycleResources().ElementAt(7).Value.Value + pathwayResults.LifeCycleResources().ElementAt(6).Value.Value + pathwayResults.LifeCycleResources().ElementAt(5).Value.Value + pathwayResults.LifeCycleResources().ElementAt(4).Value.Value + pathwayResults.LifeCycleResources().ElementAt(3).Value.Value + pathwayResults.LifeCycleResources().ElementAt(2).Value.Value + pathwayResults.LifeCycleResources().ElementAt(1).Value.Value + pathwayResults.LifeCycleResources().ElementAt(0).Value.Value)) - 1;
                TE_VO = te.MMBTUinperTrip;
                TE_Total = te.MMBTUinperTrip * ((pathwayResults.LifeCycleResources().ElementAt(13).Value.Value + pathwayResults.LifeCycleResources().ElementAt(12).Value.Value + pathwayResults.LifeCycleResources().ElementAt(11).Value.Value + pathwayResults.LifeCycleResources().ElementAt(10).Value.Value + pathwayResults.LifeCycleResources().ElementAt(9).Value.Value + pathwayResults.LifeCycleResources().ElementAt(8).Value.Value + pathwayResults.LifeCycleResources().ElementAt(7).Value.Value + pathwayResults.LifeCycleResources().ElementAt(6).Value.Value + pathwayResults.LifeCycleResources().ElementAt(5).Value.Value + pathwayResults.LifeCycleResources().ElementAt(4).Value.Value + pathwayResults.LifeCycleResources().ElementAt(3).Value.Value + pathwayResults.LifeCycleResources().ElementAt(2).Value.Value + pathwayResults.LifeCycleResources().ElementAt(1).Value.Value + pathwayResults.LifeCycleResources().ElementAt(0).Value.Value)) - 1 + te.MMBTUinperTrip;

                FF_Total = te.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(0).Value.Value;
                CF_Total = te.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(3).Value.Value;
                NGF_Total = te.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(1).Value.Value;
                PF_Total = te.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;

                //Requires an input on the input sheet
                VOC_WTP = pathwayResults.LifeCycleEmissions().ElementAt(0).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                VOC_VO = 101;
                VOC_Total = VOC_WTP + VOC_VO;

                CO_WTP = pathwayResults.LifeCycleEmissions().ElementAt(1).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                CO_VO = 101;
                CO_Total = CO_WTP + CO_VO;

                NOx_WTP = pathwayResults.LifeCycleEmissions().ElementAt(2).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                NOx_VO = 101;
                NOx_Total = NOx_WTP + NOx_VO;

                //Requires an input on the input sheet
                PM10_WTP = pathwayResults.LifeCycleEmissions().ElementAt(3).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                PM10_VO = 101;
                PM10_Total = PM10_WTP + PM10_VO;

                //Requires an input on the input sheet
                PM25_WTP = pathwayResults.LifeCycleEmissions().ElementAt(4).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                PM25_VO = 101;
                PM25_Total = PM25_WTP + PM25_VO;

                //Requires an input on the input sheet
                SOx_WTP = pathwayResults.LifeCycleEmissions().ElementAt(5).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                SOx_VO = 101;
                SOx_Total = SOx_WTP + SOx_VO;

                CH4_WTP = pathwayResults.LifeCycleEmissions().ElementAt(6).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                CH4_VO = 101;
                CH4_Total = CH4_WTP + CH4_VO;

                CO2_WTP = pathwayResults.LifeCycleEmissions().ElementAt(7).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                double gramsOfFuel = ((1 / (resourceUsed.LowerHeatingValue.GreetValue * (3.5878781 / 1000000))) * 1000000 * te.MMBTUinperTrip) * ((resourceUsed.Density.GreetValue * 3.78541178) / 1000);
                double carbonPercentage = resourceUsed.CarbonRatio.GreetValue;
                CO2_VO = ((carbonPercentage * (gramsOfFuel / te.MMBTUinperTrip)) * te.MMBTUinperTrip) * (44 / 12);
                CO2_Total = CO2_WTP + CO2_VO;

                N2O_WTP = 101;
                N2O_VO = 101;
                N2O_Total = N2O_WTP + N2O_VO;

                GHG_WTP = pathwayResults.LifeCycleEmissionsGroups(data).ElementAt(0).Value.Value * 1000000000000 * te.MMBTUinperTrip;
            }
            setLabels();
        }
        #endregion

        #region Setting Labels, and Generating new Graph
        public void setLabels()
        {
            /* 
            * Column 1 -- Well to Pump
            */
            // Total Energy
            label24.Text = (TE_WTP).ToString("#.##") + " mmbtu/trip";

            /***************
             * EMISSIONS
             ***************/

            label30.Text = (VOC_WTP).ToString("#.##") + " g/trip";  // VOC
            label31.Text = (CO_WTP).ToString("#.##") + " g/trip";   // CO
            label32.Text = (NOx_WTP).ToString("#.##") + " g/trip";  // NOx
            label33.Text = (PM10_WTP).ToString("#.##") + " g/trip"; // PM10
            label34.Text = (PM25_WTP).ToString("#.##") + " g/trip"; // PM2.5
            label35.Text = (SOx_WTP).ToString("#.##") + " g/trip";  // SOx
            label36.Text = (CH4_WTP).ToString("#.##") + " g/trip";  // CH4
            label37.Text = (CO2_WTP).ToString("#.##") + " g/trip";  // CO2
            label38.Text = (N2O_WTP).ToString("#.##") + " g/trip";  // N2O

            /*
             * Column 2 -- Vessel Operation
             */

            label42.Text = (TE_VO).ToString("#.##") + " mmbtu/trip";  // Total Energy

            /***************
             * EMISSIONS
             ***************/

            label48.Text = (VOC_VO).ToString();     // VOC
            label49.Text = (CO_VO).ToString();      // CO
            label50.Text = (NOx_VO).ToString();     // NOx
            label51.Text = (PM10_VO).ToString();    // PM10
            label52.Text = (PM25_VO).ToString();    // PM2.5
            label53.Text = (SOx_VO).ToString();     // SOx
            label54.Text = (CH4_VO).ToString();     // CH4
            label55.Text = (CO2_VO).ToString();     // CO2
            label56.Text = (N2O_VO).ToString();     // N2O

            /*
             * Column 3 -- Total
             */

            label60.Text = (TE_Total).ToString("#.##") + " mmbtu/trip";   // Total Energy
            label61.Text = (FF_Total).ToString("#.##") + " mmbtu/trip";   // Fossil Fuel
            label62.Text = (CF_Total).ToString("#.##") + " mmbtu/trip";   // Coal Fuel
            label63.Text = (NGF_Total).ToString("#.##") + " mmbtu/trip";  // Natural Gas Fuel
            label64.Text = (PF_Total).ToString("#.##") + " mmbtu/trip";   // Petroleum Fuel

            /***************
             * EMISSIONS
             ***************/

            label66.Text = (VOC_Total).ToString();      // VOC
            label67.Text = (CO_Total).ToString();       // CO
            label68.Text = (NOx_Total).ToString();      // NOx
            label69.Text = (PM10_Total).ToString();     // PM10
            label70.Text = (PM25_Total).ToString();     // PM2.5
            label71.Text = (SOx_Total).ToString();      // SOx
            label72.Text = (CH4_Total).ToString();      // CH4
            label73.Text = (CO2_Total).ToString();      // CO2
            label74.Text = (N2O_Total).ToString();      // N2O

            //Title
            label1.Text = fuelUsed;

            //Setting the stacked bar chart information
            double[] total_energy = { (TE_WTP), (TE_VO) };  //Resource 0
            double[] fossil_fuels = { 10, 20 };             //Resource 1
            double[] petroleum = { 15, 25 };                //Resource 2
            double[] co2 = { (CO2_WTP), (CO2_VO) };         //Resource 3
            double[] ch4 = { (CH4_WTP), (CH4_VO) };         //Resource 4
            double[] n2o = { (N2O_WTP), (N2O_VO) };         //Resource 5
            double[] ghgs = { 90, 4.5 };                    //Resource 6
            double[] voc = { (VOC_WTP), (VOC_VO) };         //Resource 7
            double[] co = { (CO_WTP), (CO_VO) };            //Resource 8
            double[] nox = { (NOx_WTP), (NOx_VO) };         //Resource 9
            double[] pm10 = { (PM10_WTP), (PM10_VO) };      //Resource 10
            double[] sox = { (SOx_WTP), (SOx_VO) };         //Resource 11
            double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };

            //Generate the graph using the resources set and seriesArray.
            Generate_Graph(resources, stacked_graph);
        }
        #endregion
        #region TreeView 1 Setup
        public void BuildingTreeView1()
        {
            treeView1.Nodes.Clear();
            IGDataDictionary<int, IResource> resources = ResultsAccess.controler.CurrentProject.Data.Resources;
            IGDataDictionary<int, IPathway> pathways = ResultsAccess.controler.CurrentProject.Data.Pathways;
            IGDataDictionary<int, IMix> mixes = ResultsAccess.controler.CurrentProject.Data.Mixes;

            //Adds pathways and mixes to the list so the user can select one
            //Conventional Diesel Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 27))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode("Pathway: " + pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }

            //Residual Oil pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 33))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode("Pathway: " + pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }
            //Low Sulfur Diesel pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 30))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode("Pathway: " + pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }
            //Liquid Natural Gas Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 41))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode("Pathway: " + pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }
            //Biodiesel pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 44))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode("Pathway: " + pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }

                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }
            //Fischer Tropsch Diesel Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 45))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode("Pathway: " + pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }

                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }
        }
        #endregion
        #region Generating Bar Chart
        /// <summary>
        /// Generates the specified graph for display to the user.
        /// </summary>
        /// <param name="resources">A collection of the 12 resources to be modeled by the graph with values: { %upstream%, %vesseloperation% }</param>
        /// <param name="graph">The graph to be generated. Note that this should always be the graph from the designer, 'stacked_graph'.
        /// If you wish to generate another graph, you will need to do more than pass the graph in as a parameter.</param>
        /// <param name="title">The title of the graph to be displayed. These are taken from and match the titles from the graphs in the original TEAMS spreadsheet ~v1.4</param>
        private void Generate_Graph(double[][] resources, Chart graph)
        {
            //Matches the series collection already outlined in the designer.
            string[] seriesArray = { "Upstream", "VesselOperation" };
            //Set the title of the graph to the passed in string title.
            graph.Titles[0].Text = "Your Vessel using " + fuelUsed + " \nContribution of Each Stage";
            //Iterate through each of the three series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Clears points to ensure working with a new graph.
                graph.Series[i].Points.Clear();

                //Add each resource value to the respective series from the parent loop.
                for (int r = 0; r < resources.Length; r++)
                {
                    graph.Series[seriesArray[i]].Points.AddY(resources[r][i]);
                }
            }
        }
        #endregion

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        //Saving for the excel sheet
        private void button1_Click_1(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //add data 
            xlWorkSheet.Cells[1, 1] = "Results Shown Per Trip";
            xlWorkSheet.Cells[1, 2] = "Well To Pump";
            xlWorkSheet.Cells[1, 3] = "Vessel Operation";
            xlWorkSheet.Cells[1, 4] = "Total";

            xlWorkSheet.Cells[2, 1] = "Total Energy";
            xlWorkSheet.Cells[2, 2] = TE_WTP;
            xlWorkSheet.Cells[2, 3] = TE_VO;
            xlWorkSheet.Cells[2, 4] = TE_Total;

            xlWorkSheet.Cells[3, 1] = "Fossil Fuel";
            xlWorkSheet.Cells[3, 2] = "";
            xlWorkSheet.Cells[3, 3] = "";
            xlWorkSheet.Cells[3, 4] = FF_Total;

            xlWorkSheet.Cells[4, 1] = "Coal Fuel";
            xlWorkSheet.Cells[4, 2] = "";
            xlWorkSheet.Cells[4, 3] = "";
            xlWorkSheet.Cells[4, 4] = CF_Total;

            xlWorkSheet.Cells[5, 1] = "Natural Gas Fuel";
            xlWorkSheet.Cells[5, 2] = "";
            xlWorkSheet.Cells[5, 3] = "";
            xlWorkSheet.Cells[5, 4] = NGF_Total;

            xlWorkSheet.Cells[6, 1] = "Petroleum Fuel";
            xlWorkSheet.Cells[6, 2] = "";
            xlWorkSheet.Cells[6, 3] = "";
            xlWorkSheet.Cells[6, 4] = PF_Total;

            xlWorkSheet.Cells[7, 1] = "Emissions";
            xlWorkSheet.Cells[7, 2] = "";
            xlWorkSheet.Cells[7, 3] = "";
            xlWorkSheet.Cells[7, 4] = "";

            xlWorkSheet.Cells[8, 1] = "VOC";
            xlWorkSheet.Cells[8, 2] = VOC_WTP;
            xlWorkSheet.Cells[8, 3] = VOC_VO;
            xlWorkSheet.Cells[8, 4] = VOC_Total;

            xlWorkSheet.Cells[9, 1] = "CO";
            xlWorkSheet.Cells[9, 2] = CO_WTP;
            xlWorkSheet.Cells[9, 3] = CO_VO;
            xlWorkSheet.Cells[9, 4] = CO_Total;

            xlWorkSheet.Cells[10, 1] = "NOx";
            xlWorkSheet.Cells[10, 2] = NOx_WTP;
            xlWorkSheet.Cells[10, 3] = NOx_VO;
            xlWorkSheet.Cells[10, 4] = NOx_Total;

            xlWorkSheet.Cells[11, 1] = "PM10";
            xlWorkSheet.Cells[11, 2] = PM10_WTP;
            xlWorkSheet.Cells[11, 3] = PM10_VO;
            xlWorkSheet.Cells[11, 4] = PM10_Total;

            xlWorkSheet.Cells[12, 1] = "PM 2.5";
            xlWorkSheet.Cells[12, 2] = PM25_WTP;
            xlWorkSheet.Cells[12, 3] = PM25_VO;
            xlWorkSheet.Cells[12, 4] = PM25_Total;

            xlWorkSheet.Cells[13, 1] = "SOx";
            xlWorkSheet.Cells[13, 2] = SOx_WTP;
            xlWorkSheet.Cells[13, 3] = SOx_VO;
            xlWorkSheet.Cells[13, 4] = SOx_Total;

            xlWorkSheet.Cells[14, 1] = "CH4";
            xlWorkSheet.Cells[14, 2] = CH4_WTP;
            xlWorkSheet.Cells[14, 3] = CH4_VO;
            xlWorkSheet.Cells[14, 4] = CH4_Total;

            xlWorkSheet.Cells[15, 1] = "CO2";
            xlWorkSheet.Cells[15, 2] = CO2_WTP;
            xlWorkSheet.Cells[15, 3] = CO2_VO;
            xlWorkSheet.Cells[15, 4] = CO2_Total;

            xlWorkSheet.Cells[16, 1] = "N2O";
            xlWorkSheet.Cells[16, 2] = N2O_WTP;
            xlWorkSheet.Cells[16, 3] = N2O_VO;
            xlWorkSheet.Cells[16, 4] = N2O_Total;

            xlWorkBook.SaveAs("TEAMS-Results.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("FIle saved, TEAMS-Results.xls should be in your Documents folder");
        }
    }
}
