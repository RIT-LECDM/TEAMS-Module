using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAMSModule;
using TEAMS_Plugin;
using Greet.DataStructureV3.Interfaces;
using Greet.Model.Interfaces;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

namespace TEAMSModule
{
    public partial class GREETFormattedResults : Form
    {
        #region Constants

        // Joules per 1 MMBTU
        private const double JOULES_PER_MMBTU           =   1055870000.0;
        // Grams per 1 Kilogram
        private const double GRAMS_PER_KILOGRAM         =   1000.0;
        // Kilowatt-hours per 1 Horsepower-hour
        private const double KWHRS_PER_HPHR             =   0.745699871;
        // Gallons per 1 cubic meter
        private const double GALLONS_PER_CUBIC_METER    =   264.172;
        // Grams Sulfur Oxide to Grams Sulfur Ratio
        private const double GRAMS_SOX_PER_GRAMS_S      =   64 / 32;

        // Resource ID Numbers
        private const int CONVENTIONAL_DIESEL_ID = 27;
        private const int RESIDUAL_OIL_ID = 33;
        private const int LOW_SULFUR_DIESEL_ID = 30;
        private const int LIQUID_NATURAL_GAS_ID = 41;
        private const int BIODIESEL_ID = 44;
        private const int FISCHER_TROPSCH_ID = 45;

        #endregion

        // Collection of resource id numbers for use in the tree building selections
        private int[] resource_ids     = new int[6] { CONVENTIONAL_DIESEL_ID, RESIDUAL_OIL_ID, LOW_SULFUR_DIESEL_ID, 
                                                      LIQUID_NATURAL_GAS_ID, BIODIESEL_ID, FISCHER_TROPSCH_ID };

        // API Controller
        private APIcalls APIcontroller = new APIcalls();

        // These are values for the string of text showing what fuel is used
        private string MainfuelUsed       =   "None Selected";
        private string auxFuelUsed        =   "None Selected";

        // The input sheet we are pulling from
        private TEAMS teams_sheet;

        /// <summary>
        /// These are all of the variables for values on the results sheet itself, they are being set to a default of 0
        /// </summary>
        #region All Needed Results Variables

        // Main Engine Variables
        public double TE_WTP     =   0;
        public double TE_VO      =   0;
        public double TE_Total   =   0;
        public double FF_WTP     =   0;
        public double FF_VO      =   0;
        public double FF_Total   =   0;
        public double PF_WTP     =   0;
        public double PF_VO      =   0; 
        public double PF_Total   =   0;
        public double VOC_WTP    =   0;
        public double VOC_VO     =   0;
        public double VOC_Total  =   0;
        public double CO_WTP     =   0;
        public double CO_VO      =   0;
        public double CO_Total   =   0;
        public double NOx_WTP    =   0;
        public double NOx_VO     =   0;
        public double NOx_Total  =   0;
        public double PM10_WTP   =   0;
        public double PM10_VO    =   0;
        public double PM10_Total =   0;
        public double PM25_WTP   =   0;
        public double PM25_VO    =   0;
        public double PM25_Total =   0;
        public double SOx_WTP    =   0;
        public double SOx_VO     =   0;
        public double SOx_Total  =   0;
        public double CH4_WTP    =   0;
        public double CH4_VO     =   0;
        public double CH4_Total  =   0;
        public double CO2_WTP    =   0;
        public double CO2_VO     =   0;
        public double CO2_Total  =   0;
        public double N2O_WTP    =   0;
        public double N2O_VO     =   0;
        public double N2O_Total  =   0;

        // Auxillary Engine Variables
        public double AUX_TE_WTP     =   0;
        public double AUX_TE_VO      =   0;
        public double AUX_FF_WTP     =   0;
        public double AUX_FF_VO      =   0;
        public double AUX_PF_WTP     =   0;
        public double AUX_PF_VO      =   0;
        public double AUX_VOC_WTP    =   0;
        public double AUX_VOC_VO     =   0;
        public double AUX_CO_WTP     =   0;
        public double AUX_CO_VO      =   0;
        public double AUX_NOx_WTP    =   0;
        public double AUX_NOx_VO     =   0;
        public double AUX_PM10_WTP   =   0;
        public double AUX_PM10_VO    =   0;
        public double AUX_PM25_WTP   =   0;
        public double AUX_PM25_VO    =   0;
        public double AUX_SOx_WTP    =   0;
        public double AUX_SOx_VO     =   0;
        public double AUX_CH4_WTP    =   0;
        public double AUX_CH4_VO     =   0;
        public double AUX_CO2_WTP    =   0;
        public double AUX_CO2_VO     =   0;
        public double AUX_N2O_WTP    =   0;
        public double AUX_N2O_VO     =   0;

        public double Total_GHG_WTP  =   0;
        public double Total_GHG_VO   =   0;

        #endregion

        /// <summary>
        /// Constructor for the form
        /// </summary>
        /// <param name="sheet">Must be passed a valid TEAMS object to manipulate and work with.</param>
        public GREETFormattedResults(TEAMS sheet)
        {
            // We will use this teams object to pull the GREET values into the TEAMS class, and then reference them here so they can be displayed
            teams_sheet = sheet;
            InitializeComponent();
            setDefaults();
        }

        /// <summary>
        /// Function that sets everything up at the beginning so that the values are a pleasent default to work on
        /// </summary>
        private void setDefaults()
        {
            tree_Main_Fuel_Pathways.Select();
            tree_Aux_Fuel_Pathways.Select();
            BuildingFuelPathways();
        }

        /// <summary>
        /// Setup for both engine fuel selectors
        /// </summary>
        #region Fuel Pathways Setup
        private void BuildingFuelPathways()
        {
            tree_Main_Fuel_Pathways.Nodes.Clear();
            tree_Aux_Fuel_Pathways.Nodes.Clear();
            TreeView[] FuelTrees = new TreeView[2] { tree_Main_Fuel_Pathways, tree_Aux_Fuel_Pathways };

            // Adds pathways and mixes to the list so the user can select one
            foreach (TreeView tree in FuelTrees)
            {
                foreach (int id in resource_ids)
                {
                    foreach (IResource resource in APIcontroller.getSpecificResources(id))
                    {
                        TreeNode resourceTreeNode = new TreeNode(resource.Name);
                        resourceTreeNode.Tag = resource;

                        foreach (IPathway pathway in APIcontroller.getSpecificPathways(id))
                        {
                            TreeNode pathwayNode = new TreeNode(pathway.Name);
                            pathwayNode.Tag = pathway;
                            resourceTreeNode.Nodes.Add(pathwayNode);
                        }
                        if (resourceTreeNode.Nodes.Count > 0)
                            tree.Nodes.Add(resourceTreeNode);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Pulls the needed GREET data, and makes final results calculations
        /// </summary>
        #region Final results calculation
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Object tag = tree_Main_Fuel_Pathways.SelectedNode.Tag;
            if (tag is IPathway)
            {
                IData data = APIcontroller.getData();

                IPathway path = tag as IPathway;
                IResource resourceUsed = APIcontroller.getResourceUsed(path);

                // Grabs the fuel used in the main engine to display to the user.
                MainfuelUsed = APIcontroller.getFuelUsed(path);

                IResults pathwayResults = APIcontroller.getPathwayResults(data, path);

                teams_sheet.GALLONperTrip = APIcontroller.getGallonsPerMMBTU(resourceUsed) * teams_sheet.MMBTUinperTrip;

                //These numbers will be used in calculations below, and are based on whether or not the user has edited GREET resource variables
                double resourceDensity              =   APIcontroller.getResourceDensity(resourceUsed);
                double resourceSulfurRatio          =   APIcontroller.getResourceSulfurRatio(resourceUsed);
                double resourceLowerHeatingValue    =   APIcontroller.getResourceLowerHeatingValue(resourceUsed);
                double resourceCarbonRatio          =   APIcontroller.getResourceCarbonRatio(resourceUsed);


                double[] main_fuel_type = new double[7];

                if (MainfuelUsed.Equals("Conventional Diesel"))
                {
                    Array.Copy(teams_sheet.Diesel, main_fuel_type, teams_sheet.Diesel.Length);
                }
                else if (MainfuelUsed.Equals("Residual Oil"))
                {
                    Array.Copy(teams_sheet.Residual_Oil, main_fuel_type, teams_sheet.Residual_Oil.Length);
                }
                else if (MainfuelUsed.Equals("Low-Sulfur Diesel"))
                {
                    Array.Copy(teams_sheet.Ult_Low_Sulf, main_fuel_type, teams_sheet.Ult_Low_Sulf.Length);
                }
                else if (MainfuelUsed.Equals("Liquefied Natural Gas"))
                {
                    Array.Copy(teams_sheet.Natural_Gas, main_fuel_type, teams_sheet.Natural_Gas.Length);
                }
                else if (MainfuelUsed.Equals("Biodiesel"))
                {
                    Array.Copy(teams_sheet.Biodiesel, main_fuel_type, teams_sheet.Biodiesel.Length);
                }
                else
                {
                    Array.Copy(teams_sheet.Fischer, main_fuel_type, teams_sheet.Fischer.Length);
                }

                //These should be relatively accurate no matter what, since it's a total energy and not the different engines
                //Total Energy Well To Pump = mmbtu of fuel put into the engine * all sections of energy for what it took to create 1 mmbtu of fuel - the 1 mmbtu of fuel

                TE_WTP = teams_sheet.MMBTUinperTrip * APIcontroller.getSumAllLifeCycleResources(pathwayResults) - 1 - teams_sheet.MMBTUinperTrip;

                //Total Energy Vessel Operation = mmbtu needed to put into the ship
                TE_VO = teams_sheet.MMBTUinperTrip;
                //Total Energy = Vessel Operation + Well to pump + aux vessel operation + aux well to pump
                TE_Total = TE_WTP + TE_VO + AUX_TE_WTP + AUX_TE_VO;

                // TODO: Implement Fossil Fuels and Petroleum Fuels
                // Fossil Fuels in WTP =  mmbtuin * a greet energy WTP value
                //FF_WTP = teams_sheet.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(0).Value.Value;
                //FF_Total = FF_WTP + FF_VO + AUX_FF_WTP + AUX_FF_VO;
                FF_WTP = 0;
                FF_Total = 0;

                // Petroleum Fuel in WTP =  mmbtuin * a greet energy WTP value
                //PF_WTP = teams_sheet.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;
                //PF_Total = PF_WTP + PF_VO + AUX_PF_WTP + AUX_PF_VO;
                PF_WTP = 0;
                PF_Total = 0;

                // Volatile Organic Compounds
                VOC_WTP     =   APIcontroller.getResourceWTPEmissions(pathwayResults, 0) * teams_sheet.MMBTUinperTrip;
                VOC_VO      =   main_fuel_type[0] * (1 / KWHRS_PER_HPHR) * teams_sheet.KWHOutperTrip;
                VOC_Total   =   VOC_WTP + VOC_VO + AUX_VOC_WTP + AUX_VOC_VO;

                // Carbon Monoxide
                CO_WTP      =   APIcontroller.getResourceWTPEmissions(pathwayResults, 1) * teams_sheet.MMBTUinperTrip;
                CO_VO       =   (main_fuel_type[1] * (1 / KWHRS_PER_HPHR) * teams_sheet.KWHOutperTrip);
                CO_Total    =   CO_WTP + CO_VO + AUX_CO_WTP + AUX_CO_VO;

                // Nitrogen Dioxide
                NOx_WTP     =   APIcontroller.getResourceWTPEmissions(pathwayResults, 2) * teams_sheet.MMBTUinperTrip;
                NOx_VO      =   main_fuel_type[2] * (1 / KWHRS_PER_HPHR) * teams_sheet.KWHOutperTrip;
                NOx_Total   =   NOx_WTP + NOx_VO + AUX_NOx_WTP + AUX_NOx_VO;

                // Particulate Matter 10
                PM10_WTP    =   APIcontroller.getResourceWTPEmissions(pathwayResults, 3) * teams_sheet.MMBTUinperTrip;
                PM10_VO     =   main_fuel_type[3] * (1 / KWHRS_PER_HPHR) * teams_sheet.KWHOutperTrip;
                PM10_Total  =   PM10_WTP + PM10_VO + AUX_PM10_WTP + AUX_PM10_VO;

                // Particulate Matter 25
                PM25_WTP    =   APIcontroller.getResourceWTPEmissions(pathwayResults, 4) * teams_sheet.MMBTUinperTrip;
                PM25_VO     =   main_fuel_type[4] * (1 / KWHRS_PER_HPHR) * teams_sheet.KWHOutperTrip;
                PM25_Total  =   PM25_WTP + PM25_VO + AUX_PM25_WTP + AUX_PM25_VO;

                // Sulfur Oxides
                SOx_WTP     =   APIcontroller.getResourceWTPEmissions(pathwayResults, 5) * teams_sheet.MMBTUinperTrip;
                SOx_VO      =   resourceDensity * resourceSulfurRatio * GRAMS_PER_KILOGRAM * (1 / GALLONS_PER_CUBIC_METER) * GRAMS_SOX_PER_GRAMS_S * teams_sheet.GALLONperTrip;
                SOx_Total   =   SOx_WTP + SOx_VO + AUX_SOx_WTP + AUX_SOx_VO;

                // Methane
                CH4_WTP     =   APIcontroller.getResourceWTPEmissions(pathwayResults, 6) * teams_sheet.MMBTUinperTrip;
                CH4_VO      =   main_fuel_type[5] * (1 / KWHRS_PER_HPHR) * teams_sheet.KWHOutperTrip;
                CH4_Total   =   CH4_WTP + CH4_VO + AUX_CH4_WTP + AUX_CH4_VO;

                // Carbon Dioxide
                double gramsOfFuel  =   (1 / resourceLowerHeatingValue) * resourceDensity * JOULES_PER_MMBTU * GRAMS_PER_KILOGRAM * teams_sheet.MMBTUinperTrip;
                CO2_WTP     =   APIcontroller.getResourceWTPEmissions(pathwayResults, 8) * teams_sheet.MMBTUinperTrip;
                CO2_VO      =   gramsOfFuel * resourceCarbonRatio * (44 / 12);
                CO2_Total   =   CO2_WTP + CO2_VO + AUX_CO2_WTP + AUX_CO2_VO;

                //Nitrous Oxide
                N2O_WTP     =   APIcontroller.getResourceWTPEmissions(pathwayResults, 7) * teams_sheet.MMBTUinperTrip;
                N2O_VO      =   main_fuel_type[6] * (1 / KWHRS_PER_HPHR) * teams_sheet.KWHOutperTrip;
                N2O_Total   =   N2O_WTP + N2O_VO + AUX_N2O_WTP + AUX_N2O_VO;
            }
            setLabels();
        }
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Object tag = tree_Aux_Fuel_Pathways.SelectedNode.Tag;
            if (tag is IPathway)
            {
                IData data               =   APIcontroller.getData();
                IPathway path            =   tag as IPathway;
                IResource resourceUsed   =   APIcontroller.getResourceUsed(path);

                // Gets the fuel used in the auxiliary engine to display to the user.
                auxFuelUsed              =   APIcontroller.getFuelUsed(path);

                IResults pathwayResults  =   APIcontroller.getPathwayResults(data, path);

                // These numbers will be used in calculations below, and are based on whether or not the user has tried to edit GREET resource variables
                double resourceDensity              =   APIcontroller.getResourceDensity(resourceUsed);
                double resourceSulfurRatio          =   APIcontroller.getResourceSulfurRatio(resourceUsed);
                double resourceLowerHeatingValue    =   APIcontroller.getResourceLowerHeatingValue(resourceUsed);
                double resourceCarbonRatio          =   APIcontroller.getResourceCarbonRatio(resourceUsed);

                double[] aux_fuel_type   =   new double[7];

                if (auxFuelUsed.Equals("Conventional Diesel"))
                {
                    Array.Copy(teams_sheet.Aux_Diesel, aux_fuel_type, teams_sheet.Aux_Diesel.Length);
                }
                else if (auxFuelUsed.Equals("Residual Oil"))
                {
                    Array.Copy(teams_sheet.Aux_Residual_Oil, aux_fuel_type, teams_sheet.Aux_Residual_Oil.Length);
                }
                else if (auxFuelUsed.Equals("Low-Sulfur Diesel"))
                {
                    Array.Copy(teams_sheet.Aux_Ult_Low_Sulf, aux_fuel_type, teams_sheet.Aux_Ult_Low_Sulf.Length);
                }
                else if (auxFuelUsed.Equals("Liquefied Natural Gas"))
                {
                    Array.Copy(teams_sheet.Aux_Natural_Gas, aux_fuel_type, teams_sheet.Aux_Natural_Gas.Length);
                }
                else if (auxFuelUsed.Equals("Biodiesel"))
                {
                    Array.Copy(teams_sheet.Aux_Biodiesel, aux_fuel_type, teams_sheet.Aux_Biodiesel.Length);
                }
                else
                {
                    Array.Copy(teams_sheet.Aux_Fischer, aux_fuel_type, teams_sheet.Aux_Fischer.Length);
                }

                teams_sheet.AuxEngineGALLONperTrip = (1 / resourceLowerHeatingValue) * GALLONS_PER_CUBIC_METER * JOULES_PER_MMBTU * teams_sheet.AuxEngineMMBTUinperTrip;

                AUX_TE_WTP = teams_sheet.AuxEngineMMBTUinperTrip * APIcontroller.getSumAllLifeCycleResources(pathwayResults) - 1 - teams_sheet.AuxEngineMMBTUinperTrip;

                AUX_TE_VO    =   teams_sheet.AuxEngineMMBTUinperTrip;
                TE_Total     =   TE_WTP + TE_VO + AUX_TE_WTP + AUX_TE_VO;
                
                // TODO: Implement Fossil Fuels and Petroleum Fuels
                // Fossil Fuels in WTP =  mmbtuin * a greet energy WTP value
                //AUX_FF_WTP = teams_sheet.AuxEngineMMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(0).Value.Value;
                //FF_Total = FF_WTP + FF_VO + AUX_FF_WTP + AUX_FF_VO;
                AUX_FF_WTP = 0;
                FF_Total = 0;

                // Petroleum Fuel in WTP =  mmbtuin * a greet energy WTP value
                //AUX_PF_WTP = teams_sheet.AuxEngineMMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;
                //PF_Total = PF_WTP + PF_VO + AUX_PF_WTP + AUX_PF_VO;              
                AUX_PF_WTP = 0;
                PF_Total = 0;

                AUX_VOC_WTP  =   APIcontroller.getResourceWTPEmissions(pathwayResults, 0) * teams_sheet.MMBTUinperTrip;
                AUX_VOC_VO   =   aux_fuel_type[0] * ( 1 / KWHRS_PER_HPHR ) * teams_sheet.AuxEngineKWHoutperTrip;
                VOC_Total    =   VOC_WTP + VOC_VO + AUX_VOC_WTP + AUX_VOC_VO;

                AUX_CO_WTP   =   APIcontroller.getResourceWTPEmissions(pathwayResults, 1) * teams_sheet.MMBTUinperTrip;
                AUX_CO_VO    =   aux_fuel_type[1] * ( 1 / KWHRS_PER_HPHR ) * teams_sheet.AuxEngineKWHoutperTrip;
                CO_Total     =   CO_WTP + CO_VO + AUX_CO_WTP + AUX_CO_VO;

                AUX_NOx_WTP  =   APIcontroller.getResourceWTPEmissions(pathwayResults, 2) * teams_sheet.MMBTUinperTrip;
                AUX_NOx_VO   =   aux_fuel_type[2] * ( 1 / KWHRS_PER_HPHR ) * teams_sheet.AuxEngineKWHoutperTrip;
                NOx_Total    =   NOx_WTP + NOx_VO + AUX_NOx_WTP + AUX_NOx_VO;

                AUX_PM10_WTP =   APIcontroller.getResourceWTPEmissions(pathwayResults, 3) * teams_sheet.MMBTUinperTrip;
                AUX_PM10_VO  =   aux_fuel_type[3] * ( 1 / KWHRS_PER_HPHR ) * teams_sheet.AuxEngineKWHoutperTrip;
                PM10_Total   =   PM10_WTP + PM10_VO + AUX_PM10_WTP + AUX_PM10_VO;

                AUX_PM25_WTP =   APIcontroller.getResourceWTPEmissions(pathwayResults, 4) * teams_sheet.MMBTUinperTrip;
                AUX_PM25_VO  =   aux_fuel_type[4] * ( 1 / KWHRS_PER_HPHR ) * teams_sheet.AuxEngineKWHoutperTrip;
                PM25_Total   =   PM25_WTP + PM25_VO + AUX_PM25_WTP + AUX_PM25_VO;

                AUX_SOx_WTP  =   APIcontroller.getResourceWTPEmissions(pathwayResults, 5) * teams_sheet.MMBTUinperTrip;
                AUX_SOx_VO   =   resourceDensity * resourceSulfurRatio * GRAMS_PER_KILOGRAM * ( 1 / GALLONS_PER_CUBIC_METER ) * GRAMS_SOX_PER_GRAMS_S * teams_sheet.AuxEngineGALLONperTrip;
                SOx_Total    =   SOx_WTP + SOx_VO + AUX_SOx_WTP + AUX_SOx_VO;

                AUX_CH4_WTP  =   APIcontroller.getResourceWTPEmissions(pathwayResults, 6) * teams_sheet.MMBTUinperTrip;
                AUX_CH4_VO   =   aux_fuel_type[5] * ( 1 / KWHRS_PER_HPHR ) * teams_sheet.AuxEngineKWHoutperTrip;
                CH4_Total    =   CH4_WTP + CH4_VO + AUX_CH4_WTP + AUX_CH4_VO;

                double gramsOfFuel   =   (1 / resourceLowerHeatingValue) * resourceDensity * JOULES_PER_MMBTU * GRAMS_PER_KILOGRAM * teams_sheet.AuxEngineMMBTUinperTrip;
                AUX_CO2_WTP  =   APIcontroller.getResourceWTPEmissions(pathwayResults, 8) * teams_sheet.MMBTUinperTrip;
                AUX_CO2_VO   =   gramsOfFuel * resourceCarbonRatio * (44 / 12);
                CO2_Total    =   CO2_WTP + CO2_VO + AUX_CO2_WTP + AUX_CO2_VO;

                AUX_N2O_WTP  =   APIcontroller.getResourceWTPEmissions(pathwayResults, 7) * teams_sheet.MMBTUinperTrip;
                AUX_N2O_VO   =   aux_fuel_type[6] * ( 1 / KWHRS_PER_HPHR ) * teams_sheet.AuxEngineKWHoutperTrip;
                N2O_Total    =   N2O_WTP + N2O_VO + AUX_N2O_WTP + AUX_N2O_VO;
            }
            setLabels();
        }

        /// <summary>
        /// Parses a double to a string with 2 significant figures after the decimal
        /// </summary>
        /// <param name="resource">The value to be parsed</param>
        /// <returns>The parsed string</returns>
        private String parseResourceToString(double resource)
        {
            if (resource != 0) { return (resource).ToString("#.##"); }
            else { return "0.00"; }
        }

        #endregion

        /// <summary>
        /// Sets the labels and makes a new graph
        /// </summary>
        #region Set Labels, Make new Graph
        private void setLabels()
        {
            /* 
            * Column 1 -- Well to Pump
            */
            // Total Energy
            label_Main_TE_WTP.Text = parseResourceToString(TE_WTP) + " mmbtu/trip";

            /***********************************************************
             * TODO: Re-implement Fossil Fuel and Petroleum Fuel Results
             ***********************************************************/

            // Fossil Fuel
            //label_Main_FF_WTP.Text = parseResourceToString(FF_WTP) + " mmbtu/trip";
            label_Fossil_Fuels.Text = "";
            label_Main_FF_WTP.Text = "";

            // Petroleum Fuel
            //label_Main_PF_WTP.Text = parseResourceToString(PF_WTP) + " mmbtu/trip";
            label_Petroleum_Fuel.Text = "";
            label_Main_PF_WTP.Text = "";


            /***************
             * EMISSIONS
             ***************/

            label_Main_VOC_WTP.Text    =   parseResourceToString(VOC_WTP) + " g/trip";   // VOC
            label_Main_CO_WTP.Text     =   parseResourceToString(CO_WTP) + " g/trip";     // CO
            label_Main_NOx_WTP.Text    =   parseResourceToString(NOx_WTP) + " g/trip";   // NOx
            label_Main_PM10_WTP.Text   =   parseResourceToString(PM10_WTP) + " g/trip"; // PM10
            label_Main_PM25_WTP.Text   =   parseResourceToString(PM25_WTP) + " g/trip"; // PM2.5
            label_Main_SOx_WTP.Text    =   parseResourceToString(SOx_WTP) + " g/trip";   // SOx
            label_Main_CH4_WTP.Text    =   parseResourceToString(CH4_WTP) + " g/trip";   // CH4
            label_Main_CO2_WTP.Text    =   parseResourceToString(CO2_WTP) + " g/trip";   // CO2
            label_Main_N2O_WTP.Text    =   parseResourceToString(N2O_WTP) + " g/trip";   // N2O

            /*
             * Column 2 -- Vessel Operation
             */

            label_Main_TE_VO.Text      =   parseResourceToString(TE_VO) + " mmbtu/trip";  // Total Energy

            /***************
             * EMISSIONS
             ***************/

            label_Main_VOC_VO.Text    =   parseResourceToString(VOC_VO) + " g/trip";     // VOC
            label_Main_CO_VO.Text     =   parseResourceToString(CO_VO) + " g/trip";      // CO
            label_Main_NOx_VO.Text    =   parseResourceToString(NOx_VO) + " g/trip";     // NOx
            label_Main_PM10_VO.Text   =   parseResourceToString(PM10_VO) + " g/trip";    // PM10
            label_Main_PM25_VO.Text   =   parseResourceToString(PM25_VO) + " g/trip";    // PM2.5
            label_Main_SOx_VO.Text    =   parseResourceToString(SOx_VO) + " g/trip";     // SOx
            label_Main_CH4_VO.Text    =   parseResourceToString(CH4_VO) + " g/trip";     // CH4
            label_Main_CO2_VO.Text    =   parseResourceToString(CO2_VO) + " g/trip";     // CO2
            label_Main_N2O_VO.Text    =   parseResourceToString(N2O_VO) + " g/trip";     // N2O


            // Column 3 -- Aux Engine WTP
            label_Aux_TE_WTP.Text     =   parseResourceToString(AUX_TE_WTP) + " mmbtu/trip";
            label_Aux_VOC_WTP.Text    =   parseResourceToString(AUX_VOC_WTP) + " g/trip";
            label_Aux_CO_WTP.Text     =   parseResourceToString(AUX_CO_WTP) + " g/trip";
            label_Aux_NOx_WTP.Text    =   parseResourceToString(AUX_NOx_WTP) + " g/trip";
            label_Aux_PM10_WTP.Text   =   parseResourceToString(AUX_PM10_WTP) + " g/trip";
            label_Aux_PM25_WTP.Text   =   parseResourceToString(AUX_PM25_WTP) + " g/trip";
            label_Aux_SOx_WTP.Text    =   parseResourceToString(AUX_SOx_WTP) + " g/trip";
            label_Aux_CH4_WTP.Text    =   parseResourceToString(AUX_CH4_WTP) + " g/trip";
            label_Aux_CO2_WTP.Text    =   parseResourceToString(AUX_CO2_WTP) + " g/trip";
            label_Aux_N2O_WTP.Text    =   parseResourceToString(AUX_N2O_WTP) + " g/trip";

            /***********************************************************
             * TODO: Re-implement Fossil Fuel and Petroleum Fuel Results
             ***********************************************************/

            // Fossil Fuel Aux WTP
            //label_Aux_FF_WTP.Text     =   parseResourceToString(AUX_FF_WTP) + " mmbtu/trip";
            label_Aux_FF_WTP.Text = "";

            // Petroleum Fuel Total
            //label_Aux_PF_WTP.Text     =   parseResourceToString(AUX_PF_WTP) + " mmbtu/trip";
            label_Aux_PF_WTP.Text = "";

            // Column 4 -- Aux Engine Vessel Operations
            label_Aux_TE_VO.Text      =   parseResourceToString(AUX_TE_VO) + " mmbtu/trip";
            label_Aux_VOC_VO.Text     =   parseResourceToString(AUX_VOC_VO) + " g/trip";
            label_Aux_CO_VO.Text      =   parseResourceToString(AUX_CO_VO) + " g/trip";
            label_Aux_NOx_VO.Text     =   parseResourceToString(AUX_NOx_VO) + " g/trip";
            label_Aux_PM10_VO.Text    =   parseResourceToString(AUX_PM10_VO) + " g/trip";
            label_Aux_PM25_VO.Text    =   parseResourceToString(AUX_PM25_VO) + " g/trip";
            label_Aux_SOx_VO.Text     =   parseResourceToString(AUX_SOx_VO) + " g/trip";
            label_Aux_CH4_VO.Text     =   parseResourceToString(AUX_CH4_VO) + " g/trip";
            label_Aux_CO2_VO.Text     =   parseResourceToString(AUX_CO2_VO) + " g/trip";
            label_Aux_N2O_VO.Text     =   parseResourceToString(AUX_N2O_VO) + " g/trip";
            /*
             * Column 5 -- Total
             */

            // Total Energy
            label_TE_Total.Text     =   parseResourceToString(TE_Total) + " mmbtu/trip";


            /***********************************************************
             * TODO: Re-implement Fossil Fuel and Petroleum Fuel Results
             ***********************************************************/
            // Fossil Fuel Total
            //label_FF_Total.Text     =   parseResourceToString(FF_Total) + " mmbtu/trip";
            label_FF_Total.Text = "";

            // Petroleum Fuel Total
            //label_PF_Total.Text     =   parseResourceToString(PF_Total) + " mmbtu/trip";
            label_PF_Total.Text = "";

            /***************
             * EMISSIONS
             ***************/

            label_VOC_Total.Text     =   parseResourceToString(VOC_Total) + " g/trip";
            label_CO_Total.Text      =   parseResourceToString(CO_Total) + " g/trip";
            label_NOx_Total.Text     =   parseResourceToString(NOx_Total) + " g/trip";
            label_PM10_Total.Text    =   parseResourceToString(PM10_Total) + " g/trip";
            label_PM25_Total.Text    =   parseResourceToString(PM25_Total) + " g/trip";
            label_SOx_Total.Text     =   parseResourceToString(SOx_Total) + " g/trip";
            label_CH4_Total.Text     =   parseResourceToString(CH4_Total) + " g/trip";
            label_CO2_Total.Text     =   parseResourceToString(CO2_Total) + " g/trip";
            label_N2O_Total.Text     =   parseResourceToString(N2O_Total) + " g/trip";

            // Title
            label_Main_Fuel_Type.Text   =   MainfuelUsed;
            label_Aux_Fuel_Type.Text    =   auxFuelUsed;

            // Calculating greenhouse gas using Global Warming Potential
            Total_GHG_WTP    =   (CO2_WTP * teams_sheet.CO2_GWP) + (CH4_WTP * teams_sheet.CH4_GWP) + (N2O_WTP * teams_sheet.N2O_GWP) + (VOC_WTP * teams_sheet.VOC_GWP) + (CO_WTP * teams_sheet.CO_GWP) + (NOx_WTP * teams_sheet.NO2_GWP);
            Total_GHG_VO     =   (CO2_VO * teams_sheet.CO2_GWP) + (CH4_VO * teams_sheet.CH4_GWP) + (N2O_VO * teams_sheet.N2O_GWP) + (VOC_VO * teams_sheet.VOC_GWP) + (CO_VO * teams_sheet.CO_GWP) + (NOx_VO * teams_sheet.NO2_GWP);

            // Preparing the stacked bar chart information
            double[] total_energy    =   { (TE_WTP + AUX_TE_WTP), (TE_VO + AUX_TE_VO) };     // Resource 0
            /* TODO: Re-implement fossil_fuels and petroleum calculations
             * double[] fossil_fuels = { 10, 20 };             // Resource xx
             * double[] petroleum = { 15, 25 };                // Resource xx
             * */
            double[] co2     =   { (CO2_WTP + AUX_CO2_WTP), (CO2_VO + AUX_CO2_VO) };         // Resource 1
            double[] ch4     =   { (CH4_WTP + AUX_CH4_WTP), (CH4_VO + AUX_CH4_VO) };         // Resource 2
            double[] n2o     =   { (N2O_WTP + AUX_N2O_WTP), (N2O_VO + AUX_N2O_VO) };         // Resource 3
            double[] ghgs    =   { Total_GHG_WTP, Total_GHG_VO };                            // Resource 4
            double[] voc     =   { (VOC_WTP + AUX_VOC_WTP), (VOC_VO + AUX_VOC_VO) };         // Resource 5
            double[] co      =   { (CO_WTP + AUX_CO_WTP), (CO_VO + AUX_CO_VO) };             // Resource 6
            double[] nox     =   { (NOx_WTP + AUX_NOx_WTP), (NOx_VO + AUX_NOx_VO) };         // Resource 7
            double[] pm10    =   { (PM10_WTP + AUX_PM10_WTP), (PM10_VO + AUX_PM10_VO) };     // Resource 8
            double[] sox     =   { (SOx_WTP + AUX_SOx_WTP), (SOx_VO + AUX_SOx_VO) };         // Resource 9

            double[][] resources     =   { total_energy, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };

            // Generate the graph using the resources set and seriesArray.
            Generate_Graph(resources, graph_VO_vs_WTP);
        }
        #endregion


        /// <summary>
        /// Generates the bar chart at the bottom of the form
        /// </summary>
        #region Generating Bar Chart
        /// <summary>
        /// Generates the specified graph for display to the user.
        /// </summary>
        /// <param name="resources">A collection of the resources to be modeled by the graph with values: { %upstream%, %vesseloperation% }</param>
        /// <param name="graph">The graph to be generated. Note that this should always be the graph from the designer, 'stacked_graph'.
        ///                     If you wish to generate another graph, you will need to do more than pass the graph in as a parameter.</param>
        /// <param name="title">The title of the graph to be displayed.</param>
        private void Generate_Graph(double[][] resources, Chart graph)
        {
            // Matches the series collection already outlined in the designer.
            string[] seriesArray     =   { "WellToPump", "VesselOperation" };

            // Set the title of the graph to the passed in string title.
            graph.Titles[0].Text     =   teams_sheet.VesselTypeID + "\nMain Engine: " + MainfuelUsed + "\nAuxiliary Engine: " + auxFuelUsed;

            // Iterate through both of the series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Clears points to ensure working with a new graph.
                graph.Series[i].Points.Clear();

                // Add each resource value to the respective series from the parent loop.
                for (int r = 0; r < resources.Length; r++)
                {
                    graph.Series[seriesArray[i]].Points.AddY(resources[r][i]);
                }
            }
        }
        #endregion

        /// <summary>
        /// Saves values to an excel sheet, and lets the user pick the file path and name
        /// </summary>
        #region Saving for the excel sheet

        // For use during export to excel sheet. Prevents system crashing and gives error source to user.
        private void exception_Handling(Exception exception)
        {
            MessageBox.Show("An error occurred while trying to save the file. Ensure it is not being used by another program and try again.\n" +
                            "Exception message: " + exception.Message);
            
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            // Create the new file to be saved, use Save Dialog Box.
            SaveFile.Filter   =   "Excel File|.xlsx";
            SaveFile.Title    =   "Save TEAMS Results to an Excel File";
            DialogResult save_result =   SaveFile.ShowDialog();

            string filePath  =   SaveFile.FileName;

            // If user cancels the save, do nothing
            if (save_result == DialogResult.Cancel)
            {
                return;
            }

            // Error proofing
            if (filePath == "")
            {
                MessageBox.Show("File name cannot be blank.");
                return;
            }

            // Handling for when the file exists and is being used by another program.
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch ( Exception exception)
                {
                    exception_Handling(exception);
                    return;
                }

                File.Delete(filePath);
                
            }

            // If the file does not previously exist, but for whatever reason cannot be created,
            // handle the exception and cancel the export.
            FileInfo newFile     =   null;
            try
            {
                newFile  =   new FileInfo(filePath);
            }
            catch (Exception exception)
            {
                exception_Handling(exception);
                return;
            }

            // If the file could not be created or accessed, return the user to the save menu.
            if (newFile == null) { ExportButton_Click(sender, e); }

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // Add a new Worksheet to the empty workbook
                ExcelWorksheet worksheet     =   package.Workbook.Worksheets.Add("TEAMS Results");
                
                // Add the headers
                worksheet.Cells[1, 1].Value              =   "Vessel name";
                worksheet.Cells[1, 1].Style.Font.Bold    =   true;
                worksheet.Cells[1, 2].Value              =   teams_sheet.VesselTypeID;

                worksheet.Cells[2, 2].Value                      =   "Main Engine";
                worksheet.Cells[2, 2].Style.Font.Bold            =   true;
                worksheet.Cells[2, 2].Style.HorizontalAlignment  =   ExcelHorizontalAlignment.Center;
                worksheet.Cells[2, 2, 2, 3].Merge                =   true;

                worksheet.Cells[2, 4].Value                      =   "Auxiliary Engine";
                worksheet.Cells[2, 4].Style.Font.Bold            =   true;
                worksheet.Cells[2, 4].Style.HorizontalAlignment  =   ExcelHorizontalAlignment.Center;
                worksheet.Cells[2, 4, 2, 5].Merge                =   true;

                worksheet.Cells[3, 1].Value  =   "Results Shown Per Trip";
                worksheet.Cells[3, 2].Value  =   "Well To Pump";
                worksheet.Cells[3, 3].Value  =   "Vessel Operation";
                worksheet.Cells[3, 4].Value  =   "Well To Pump";
                worksheet.Cells[3, 5].Value  =   "Vessel Operation";
                worksheet.Cells[3, 6].Value  =   "Total";

                worksheet.Cells["A3:F3"].Style.HorizontalAlignment   =   ExcelHorizontalAlignment.Center;
                worksheet.Cells["A3:F3"].Style.Border.Bottom.Style   =   ExcelBorderStyle.Thin;

                // Add the data

                worksheet.Cells[4, 1].Value  =   "Total Energy";
                worksheet.Cells[4, 2].Value  =   TE_WTP;
                worksheet.Cells[4, 3].Value  =   TE_VO;
                worksheet.Cells[4, 4].Value  =   AUX_TE_WTP;
                worksheet.Cells[4, 5].Value  =   AUX_TE_VO;
                worksheet.Cells[4, 6].Value  =   TE_Total;

                // TODO: Implement Fossil Fuel
                // worksheet.Cells[5, 1].Value = "Fossil Fuel";
                worksheet.Cells[5, 2].Value  =   FF_WTP;
                worksheet.Cells[5, 4].Value  =   AUX_FF_WTP;
                worksheet.Cells[5, 6].Value  =   FF_Total;
                
                // TODO: Implement Petroleum Fuel
                // worksheet.Cells[6, 1].Value = "Petroleum Fuel";
                worksheet.Cells[6, 2].Value  =   PF_WTP;
                worksheet.Cells[6, 4].Value  =   AUX_PF_WTP;
                worksheet.Cells[6, 6].Value  =   PF_Total;

                worksheet.Cells[9, 1].Value  =   "Emissions";

                worksheet.Cells[10, 1].Value     =   "VOC";
                worksheet.Cells[10, 2].Value     =   VOC_WTP;
                worksheet.Cells[10, 3].Value     =   VOC_VO;
                worksheet.Cells[10, 4].Value     =   AUX_VOC_WTP;
                worksheet.Cells[10, 5].Value     =   AUX_VOC_VO;
                worksheet.Cells[10, 6].Value     =   VOC_Total;

                worksheet.Cells[11, 1].Value     =   "CO";
                worksheet.Cells[11, 2].Value     =   CO_WTP;
                worksheet.Cells[11, 3].Value     =   CO_VO;
                worksheet.Cells[11, 4].Value     =   AUX_CO_WTP;
                worksheet.Cells[11, 5].Value     =   AUX_CO_VO;
                worksheet.Cells[11, 6].Value     =   CO_Total;

                worksheet.Cells[12, 1].Value     =   "NOx";
                worksheet.Cells[12, 2].Value     =   NOx_WTP;
                worksheet.Cells[12, 3].Value     =   NOx_VO;
                worksheet.Cells[12, 4].Value     =   AUX_NOx_WTP;
                worksheet.Cells[12, 5].Value     =   AUX_NOx_VO;
                worksheet.Cells[12, 6].Value     =   NOx_Total;

                worksheet.Cells[13, 1].Value     =   "PM10";
                worksheet.Cells[13, 2].Value     =   PM10_WTP;
                worksheet.Cells[13, 3].Value     =   PM10_VO;
                worksheet.Cells[13, 4].Value     =   AUX_PM10_WTP;
                worksheet.Cells[13, 5].Value     =   AUX_PM10_VO;
                worksheet.Cells[13, 6].Value     =   PM10_Total;

                worksheet.Cells[14, 1].Value     =   "PM 2.5";
                worksheet.Cells[14, 2].Value     =   PM25_WTP;
                worksheet.Cells[14, 3].Value     =   PM25_VO;
                worksheet.Cells[14, 4].Value     =   AUX_PM25_WTP;
                worksheet.Cells[14, 5].Value     =   AUX_PM25_VO;
                worksheet.Cells[14, 6].Value     =   PM25_Total;

                worksheet.Cells[15, 1].Value     =   "SOx";
                worksheet.Cells[15, 2].Value     =   SOx_WTP;
                worksheet.Cells[15, 3].Value     =   SOx_VO;
                worksheet.Cells[15, 4].Value     =   AUX_SOx_WTP;
                worksheet.Cells[15, 5].Value     =   AUX_SOx_VO;
                worksheet.Cells[15, 6].Value     =   SOx_Total;

                worksheet.Cells[16, 1].Value     =   "CH4";
                worksheet.Cells[16, 2].Value     =   CH4_WTP;
                worksheet.Cells[16, 3].Value     =   CH4_VO;
                worksheet.Cells[16, 4].Value     =   AUX_CH4_WTP;
                worksheet.Cells[16, 5].Value     =   AUX_CH4_VO;
                worksheet.Cells[16, 6].Value     =   CH4_Total;

                worksheet.Cells[17, 1].Value     =   "CO2";
                worksheet.Cells[17, 2].Value     =   CO2_WTP;
                worksheet.Cells[17, 3].Value     =   CO2_VO;
                worksheet.Cells[17, 4].Value     =   AUX_CO2_WTP;
                worksheet.Cells[17, 5].Value     =   AUX_CO2_VO;
                worksheet.Cells[17, 6].Value     =   CO2_Total;

                worksheet.Cells[18, 1].Value     =   "N2O";
                worksheet.Cells[18, 2].Value     =   N2O_WTP;
                worksheet.Cells[18, 3].Value     =   N2O_VO;
                worksheet.Cells[18, 4].Value     =   AUX_N2O_WTP;
                worksheet.Cells[18, 5].Value     =   AUX_N2O_VO;
                worksheet.Cells[18, 6].Value     =   N2O_Total;

                worksheet.Cells[20, 1].Value             =   "Main Engine Fuel Type:";
                worksheet.Cells[20, 1].Style.Font.Bold   =   true;
                worksheet.Cells[20, 2].Value             =   MainfuelUsed;

                worksheet.Cells[21, 1].Value             =   "Auxiliary Engine Fuel Type:";
                worksheet.Cells[21, 1].Style.Font.Bold   =   true;
                worksheet.Cells[21, 2].Value             =   auxFuelUsed;

                // Resize the columns to fit the values
                worksheet.Cells["A1:F22"].AutoFitColumns();

                // Save the file
                package.Save();

                MessageBox.Show("Excel spreadsheet saved successfully.", "File Saved");
            }

            
        }
        #endregion

        /// <summary>
        /// Reloads the form to default inputs.
        /// </summary>
        /// <param name="sender">Any object - UNUSED PARAMETER</param>
        /// <param name="e">Any event arguments - UNUSED PARAMETER</param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            DialogResult result     =   MessageBox.Show("Are you sure you wish to reset the form?", "Reset Results", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
                GREETFormattedResults newWindow     =   new GREETFormattedResults(teams_sheet);
                newWindow.Show();
            }

        }

    }
}