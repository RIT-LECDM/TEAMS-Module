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
using PlugInsInterfaces.DataTypes.Technology;
using TEAMSModule;

namespace TEAMS_Plugin
{
    public partial class TEAMS : Form
    {
        //Input Variables - These are used to do the calculations for the model
        #region Main Engine
        //5.1 Main Engine Variables
        public string VesselTypeID;
        public int NumberOfEngines;
        public int SingleEngineHP;
        public int TotalOnboardHP;
        //Constants (These are units of measurement)
        public double KWperHP;
        public double GALperBBL;
        public double BBLperTONNE;
        public double BTUperKWH;

        //5.2 Trip Distance and Time
        public double TotalTripDistanceInMiles;
        public double TripTimeHours;
        public double TripTimeMinutes;
        public double TotalTripTimeHours;

        //5.3 Engine Charicterization Per Mode
        //POT - Percent Of Trip, Time in mode is measured in hours HPLF - Horse Power Load Factor (Single engine). HPPE = Horse Power Per Engine EP = Energy Production in KWH for all engines
        public double POTIdle;
        public double POTManeuvering;
        public double POTPrecautionary;
        public double POTSlowCruise;
        public double POTFullCruise;
        public double TimeInIdle;
        public double TimeInManeuvering;
        public double TimeInPrecautionary;
        public double TimeInSlowCruise;
        public double TimeInFullCruise;
        public double HPLFIdle;
        public double HPLFManeuvering;
        public double HPLFPrecautionary;
        public double HPLFSlowCruise;
        public double HPLFFullCruise;
        public double HPPEIdle;
        public double HPPEManeuvering;
        public double HPPEPrecautionary;
        public double HPPESlowCruise;
        public double HPPEFullCruise;
        public double EPIdle;
        public double EPManeuvering;
        public double EPPrecautionary;
        public double EPSlowCruise;
        public double EPFullCruise;
        public double EPTotal;

        //5.4b Calculation of Fuel Use Using Conventional Diesel as Baseline Fuel
        public double EngineEfficiency;
        public double KWHOutperTrip;
        public double MMBTUoutperTrip;
        public double MMBTUinperTrip;
        public double GALLONperTrip;

        //Emissions Factor Variables
        public double NOX_gphphr_out;
        public double CO_gphphr_out;
        public double VOC_gphphr_out;
        public double PM10_gphphr_out;
        public double PM25_gphphr_out;
        public double N2O_gphphr_out;
        public double CH4_gphphr_out;

        #endregion
        #region Auxiliary Engine(s)

        //6.2 Auxiliary Engine Variables
        public int NumberOfOnBoarAuxiliaryEngines;
        public int NumberOfAuxiliaryEnginesInUse;
        public int AuxiliaryEnginesRatedHPperEngine;
        public int TotalOnboardAUxHP;

        //6.3 Auxiliary Engine Characterization (Conventional Diesel as Baseline Fuel)
        public double PercentOfTripAuxiliaryIsActive;
        public double TimeAuxActiveHours;
        public double HPLoadFactorSingleEngine;
        public double ActiveHPPerAuxEngine;
        public double TotalAuxEnergyProduction;


        //6.4b Calculation of Auxiliary Engine Fuel use Using Conventional Diesel as Baseline Fuel
        public double AuxiliaryEngineEfficiency;
        public double AuxEngineKWHoutperTrip;
        public double AuxEngineMMBTUoutperTrip;
        public double AuxEngineMMBTUinperTrip;
        public double AuxEngineGALLONperTrip;

        public double AUX_NOX_gphphr_out;
        public double AUX_CO_gphphr_out;
        public double AUX_VOC_gphphr_out;
        public double AUX_PM10_gphphr_out;
        public double AUX_PM25_gphphr_out;
        public double AUX_N2O_gphphr_out;
        public double AUX_CH4_gphphr_out;
        #endregion

        //Results variables - These are used to store calculated values later on, as well as the actual results that come from another round of calculations
        #region Results Variables
        public double CD_WTP_TE;
        public double CD_WTP_FF;
        public double CD_WTP_CF;
        public double CD_WTP_NG;
        public double CD_WTP_PF;
        public double CD_WTP_VOC;
        public double CD_WTP_CO;
        public double CD_WTP_NOX;
        public double CD_WTP_PM10;
        public double CD_WTP_PM25;
        public double CD_WTP_SOX;
        public double CD_WTP_CH4;
        public double CD_WTP_CO2;
        public double CD_WTP_N2O;
        public double CD_WTP_PM10_TBW;
        public double CD_WTP_PM25_TBW;
        public double CD_WTP_PM25_CO2Biogenic;

        public double CD_VO_TE;
        public double CD_VO_FF;
        public double CD_VO_CF;
        public double CD_VO_NG;
        public double CD_VO_PF;
        public double CD_VO_VOC;
        public double CD_VO_CO;
        public double CD_VO_NOX;
        public double CD_VO_PM10;
        public double CD_VO_PM25;
        public double CD_VO_SOX;
        public double CD_VO_CH4;
        public double CD_VO_CO2;
        public double CD_VO_N2O;
        public double CD_VO_PM10_TBW;
        public double CD_VO_PM25_TBW;
        public double CD_VO_PM25_CO2Biogenic;

        public double CD_Total_TE;
        public double CD_Total_FF;
        public double CD_Total_CF;
        public double CD_Total_NG;
        public double CD_Total_PF;
        public double CD_Total_VOC;
        public double CD_Total_CO;
        public double CD_Total_NOX;
        public double CD_Total_PM10;
        public double CD_Total_PM25;
        public double CD_Total_SOX;
        public double CD_Total_CH4;
        public double CD_Total_CO2;
        public double CD_Total_N2O;
        public double CD_Total_PM10_TBW;
        public double CD_Total_PM25_TBW;
        public double CD_Total_PM25_CO2Biogenic;

        public double RO_WTP_TE;
        public double RO_WTP_FF;
        public double RO_WTP_CF;
        public double RO_WTP_NG;
        public double RO_WTP_PF;
        public double RO_WTP_VOC;
        public double RO_WTP_CO;
        public double RO_WTP_NOX;
        public double RO_WTP_PM10;
        public double RO_WTP_PM25;
        public double RO_WTP_SOX;
        public double RO_WTP_CH4;
        public double RO_WTP_CO2;
        public double RO_WTP_N2O;
        public double RO_WTP_PM10_TBW;
        public double RO_WTP_PM25_TBW;
        public double RO_WTP_PM25_CO2Biogenic;

        public double RO_VO_TE;
        public double RO_VO_FF;
        public double RO_VO_CF;
        public double RO_VO_NG;
        public double RO_VO_PF;
        public double RO_VO_VOC;
        public double RO_VO_CO;
        public double RO_VO_NOX;
        public double RO_VO_PM10;
        public double RO_VO_PM25;
        public double RO_VO_SOX;
        public double RO_VO_CH4;
        public double RO_VO_CO2;
        public double RO_VO_N2O;
        public double RO_VO_PM10_TBW;
        public double RO_VO_PM25_TBW;
        public double RO_VO_PM25_CO2Biogenic;

        public double RO_Total_TE;
        public double RO_Total_FF;
        public double RO_Total_CF;
        public double RO_Total_NG;
        public double RO_Total_PF;
        public double RO_Total_VOC;
        public double RO_Total_CO;
        public double RO_Total_NOX;
        public double RO_Total_PM10;
        public double RO_Total_PM25;
        public double RO_Total_SOX;
        public double RO_Total_CH4;
        public double RO_Total_CO2;
        public double RO_Total_N2O;
        public double RO_Total_PM10_TBW;
        public double RO_Total_PM25_TBW;
        public double RO_Total_PM25_CO2Biogenic;

        public double LSD_WTP_TE;
        public double LSD_WTP_FF;
        public double LSD_WTP_CF;
        public double LSD_WTP_NG;
        public double LSD_WTP_PF;
        public double LSD_WTP_VOC;
        public double LSD_WTP_CO;
        public double LSD_WTP_NOX;
        public double LSD_WTP_PM10;
        public double LSD_WTP_PM25;
        public double LSD_WTP_SOX;
        public double LSD_WTP_CH4;
        public double LSD_WTP_CO2;
        public double LSD_WTP_N2O;
        public double LSD_WTP_PM10_TBW;
        public double LSD_WTP_PM25_TBW;
        public double LSD_WTP_PM25_CO2Biogenic;

        public double LSD_VO_TE;
        public double LSD_VO_FF;
        public double LSD_VO_CF;
        public double LSD_VO_NG;
        public double LSD_VO_PF;
        public double LSD_VO_VOC;
        public double LSD_VO_CO;
        public double LSD_VO_NOX;
        public double LSD_VO_PM10;
        public double LSD_VO_PM25;
        public double LSD_VO_SOX;
        public double LSD_VO_CH4;
        public double LSD_VO_CO2;
        public double LSD_VO_N2O;
        public double LSD_VO_PM10_TBW;
        public double LSD_VO_PM25_TBW;
        public double LSD_VO_PM25_CO2Biogenic;

        public double LSD_Total_TE;
        public double LSD_Total_FF;
        public double LSD_Total_CF;
        public double LSD_Total_NG;
        public double LSD_Total_PF;
        public double LSD_Total_VOC;
        public double LSD_Total_CO;
        public double LSD_Total_NOX;
        public double LSD_Total_PM10;
        public double LSD_Total_PM25;
        public double LSD_Total_SOX;
        public double LSD_Total_CH4;
        public double LSD_Total_CO2;
        public double LSD_Total_N2O;
        public double LSD_Total_PM10_TBW;
        public double LSD_Total_PM25_TBW;
        public double LSD_Total_PM25_CO2Biogenic;

        public double NG_WTP_TE;
        public double NG_WTP_FF;
        public double NG_WTP_CF;
        public double NG_WTP_NG;
        public double NG_WTP_PF;
        public double NG_WTP_VOC;
        public double NG_WTP_CO;
        public double NG_WTP_NOX;
        public double NG_WTP_PM10;
        public double NG_WTP_PM25;
        public double NG_WTP_SOX;
        public double NG_WTP_CH4;
        public double NG_WTP_CO2;
        public double NG_WTP_N2O;
        public double NG_WTP_PM10_TBW;
        public double NG_WTP_PM25_TBW;
        public double NG_WTP_PM25_CO2Biogenic;

        public double NG_VO_TE;
        public double NG_VO_FF;
        public double NG_VO_CF;
        public double NG_VO_NG;
        public double NG_VO_PF;
        public double NG_VO_VOC;
        public double NG_VO_CO;
        public double NG_VO_NOX;
        public double NG_VO_PM10;
        public double NG_VO_PM25;
        public double NG_VO_SOX;
        public double NG_VO_CH4;
        public double NG_VO_CO2;
        public double NG_VO_N2O;
        public double NG_VO_PM10_TBW;
        public double NG_VO_PM25_TBW;
        public double NG_VO_PM25_CO2Biogenic;

        public double NG_Total_TE;
        public double NG_Total_FF;
        public double NG_Total_CF;
        public double NG_Total_NG;
        public double NG_Total_PF;
        public double NG_Total_VOC;
        public double NG_Total_CO;
        public double NG_Total_NOX;
        public double NG_Total_PM10;
        public double NG_Total_PM25;
        public double NG_Total_SOX;
        public double NG_Total_CH4;
        public double NG_Total_CO2;
        public double NG_Total_N2O;
        public double NG_Total_PM10_TBW;
        public double NG_Total_PM25_TBW;
        public double NG_Total_PM25_CO2Biogenic;

        public double BD_WTP_TE;
        public double BD_WTP_FF;
        public double BD_WTP_CF;
        public double BD_WTP_NG;
        public double BD_WTP_PF;
        public double BD_WTP_VOC;
        public double BD_WTP_CO;
        public double BD_WTP_NOX;
        public double BD_WTP_PM10;
        public double BD_WTP_PM25;
        public double BD_WTP_SOX;
        public double BD_WTP_CH4;
        public double BD_WTP_CO2;
        public double BD_WTP_N2O;
        public double BD_WTP_PM10_TBW;
        public double BD_WTP_PM25_TBW;
        public double BD_WTP_PM25_CO2Biogenic;

        public double BD_VO_TE;
        public double BD_VO_FF;
        public double BD_VO_CF;
        public double BD_VO_NG;
        public double BD_VO_PF;
        public double BD_VO_VOC;
        public double BD_VO_CO;
        public double BD_VO_NOX;
        public double BD_VO_PM10;
        public double BD_VO_PM25;
        public double BD_VO_SOX;
        public double BD_VO_CH4;
        public double BD_VO_CO2;
        public double BD_VO_N2O;
        public double BD_VO_PM10_TBW;
        public double BD_VO_PM25_TBW;
        public double BD_VO_PM25_CO2Biogenic;

        public double BD_Total_TE;
        public double BD_Total_FF;
        public double BD_Total_CF;
        public double BD_Total_NG;
        public double BD_Total_PF;
        public double BD_Total_VOC;
        public double BD_Total_CO;
        public double BD_Total_NOX;
        public double BD_Total_PM10;
        public double BD_Total_PM25;
        public double BD_Total_SOX;
        public double BD_Total_CH4;
        public double BD_Total_CO2;
        public double BD_Total_N2O;
        public double BD_Total_PM10_TBW;
        public double BD_Total_PM25_TBW;
        public double BD_Total_PM25_CO2Biogenic;

        public double FTD_WTP_TE;
        public double FTD_WTP_FF;
        public double FTD_WTP_CF;
        public double FTD_WTP_NG;
        public double FTD_WTP_PF;
        public double FTD_WTP_VOC;
        public double FTD_WTP_CO;
        public double FTD_WTP_NOX;
        public double FTD_WTP_PM10;
        public double FTD_WTP_PM25;
        public double FTD_WTP_SOX;
        public double FTD_WTP_CH4;
        public double FTD_WTP_CO2;
        public double FTD_WTP_N2O;
        public double FTD_WTP_PM10_TBW;
        public double FTD_WTP_PM25_TBW;
        public double FTD_WTP_PM25_CO2Biogenic;

        public double FTD_VO_TE;
        public double FTD_VO_FF;
        public double FTD_VO_CF;
        public double FTD_VO_NG;
        public double FTD_VO_PF;
        public double FTD_VO_VOC;
        public double FTD_VO_CO;
        public double FTD_VO_NOX;
        public double FTD_VO_PM10;
        public double FTD_VO_PM25;
        public double FTD_VO_SOX;
        public double FTD_VO_CH4;
        public double FTD_VO_CO2;
        public double FTD_VO_N2O;
        public double FTD_VO_PM10_TBW;
        public double FTD_VO_PM25_TBW;
        public double FTD_VO_PM25_CO2Biogenic;

        public double FTD_Total_TE;
        public double FTD_Total_FF;
        public double FTD_Total_CF;
        public double FTD_Total_NG;
        public double FTD_Total_PF;
        public double FTD_Total_VOC;
        public double FTD_Total_CO;
        public double FTD_Total_NOX;
        public double FTD_Total_PM10;
        public double FTD_Total_PM25;
        public double FTD_Total_SOX;
        public double FTD_Total_CH4;
        public double FTD_Total_CO2;
        public double FTD_Total_N2O;
        public double FTD_Total_PM10_TBW;
        public double FTD_Total_PM25_TBW;
        public double FTD_Total_PM25_CO2Biogenic;

        public double conventionalDieselBTUperGal;

        #endregion

        //Conventional Diesel Path ID - Just used for estimation of fuel gallons for input, does not appear on the results sheet.
        public const int CD_PATH_ID = 40;

        //The results sheet
        public GREETFormattedResults gfr;

        public TEAMS()
        {
            InitializeComponent();
            pullFromGREET();
            useDefaults();
            changeResults();
        }
        /// <summary>
        /// Grabs the data needed to calculate the Conventional Diesel btu/gal
        /// </summary>
        #region Conventional Diesel Pull From GREET
        public void pullFromGREET()
        {
            //All this function is doing now is pulling the BTUPerGal for Conventional Diesel so it can be used to calculate the gallons per trip. (This is ultimately recalculated in the Results code)
            IGDataDictionary<int, IResource> resources = ResultsAccess.controler.CurrentProject.Data.Resources;
            IGDataDictionary<int, IPathway> pathways = ResultsAccess.controler.CurrentProject.Data.Pathways;
            IGDataDictionary<int, IMix> mixes = ResultsAccess.controler.CurrentProject.Data.Mixes;
            IPathway myPathway = pathways.ValueForKey(CD_PATH_ID);
            int productID = myPathway.MainOutputResourceID;
            // Grab the int id for the resource (the water)
            productID = myPathway.MainOutputResourceID;
            IResource ConvDiesel = resources.ValueForKey(productID);
            if (ConvDiesel.LowerHeatingValue.UserValue == 0)
            {
                conventionalDieselBTUperGal = ConvDiesel.LowerHeatingValue.GreetValue * (3.5878781 / 1000000);
            }
            else
            {
                conventionalDieselBTUperGal = ConvDiesel.LowerHeatingValue.UserValue * (3.5878781 / 1000000);
            }
        }
        #endregion

        /// <summary>
        /// Calculated values based on the current values of variables in the model
        /// </summary>
        #region Do Calculations
        public void doCalculations()
        {
            //Total Horsepower = One Engine's Horsepower * The Number of Engines
            TotalOnboardHP = SingleEngineHP * NumberOfEngines;
            //Total Trip Time = Trip Hours + (Trip Minutes / 60)
            TotalTripTimeHours = TripTimeHours + (TripTimeMinutes / 60);

            //Time in Stage of Transit = (Percent of Time as Defined by User / 100) * Total Trip Time
            TimeInIdle = (POTIdle / 100) * TotalTripTimeHours;
            TimeInManeuvering = (POTManeuvering / 100) * TotalTripTimeHours;
            TimeInPrecautionary = (POTPrecautionary / 100) * TotalTripTimeHours;
            TimeInSlowCruise = (POTSlowCruise / 100) * TotalTripTimeHours;
            TimeInFullCruise = (POTFullCruise / 100) * TotalTripTimeHours;

            //Horsepower Per Engine in a given mode = (Horsepower Load Factor in that mode / 100) * Horsepower of a single engine
            HPPEIdle = (HPLFIdle / 100) * SingleEngineHP;
            HPPEManeuvering = (HPLFManeuvering / 100) * SingleEngineHP;
            HPPEPrecautionary = (HPLFPrecautionary / 100) * SingleEngineHP;
            HPPESlowCruise = (HPLFSlowCruise / 100) * SingleEngineHP;
            HPPEFullCruise = (HPLFFullCruise / 100) * SingleEngineHP;

            //Energy Production (in KWH for all engines) in a given mode = Number of Engines * Horsepower Per Engine in that mode * Time in that mode * Kilowats per Horsepower
            EPIdle = NumberOfEngines * HPPEIdle * TimeInIdle * KWperHP;
            EPManeuvering = NumberOfEngines * HPPEManeuvering * TimeInManeuvering * KWperHP;
            EPPrecautionary = NumberOfEngines * HPPEPrecautionary * TimeInPrecautionary * KWperHP;
            EPSlowCruise = NumberOfEngines * HPPESlowCruise * TimeInSlowCruise * KWperHP;
            EPFullCruise = NumberOfEngines * HPPEFullCruise * TimeInFullCruise * KWperHP;

            //Energy Production Total = The Summation of the Energy Productions for each mode
            EPTotal = EPIdle + EPManeuvering + EPPrecautionary + EPSlowCruise + EPFullCruise;

            //Kilowat Hours out Per Trip = Energy Production Total
            KWHOutperTrip = EPTotal;

            //Million BTUs of Energy needed to power the trip = (Kilowat Hours Out per trip * BTU per Kilowat Hours) / 1000000 (The million converts from btu to mmbtu)
            MMBTUoutperTrip = (KWHOutperTrip * BTUperKWH) / 1000000;

            //Million BTUs of Energy you need to put in in order to actually get the mmbtus out you needed above = mmbtu to power the trip * (100 / Engine efficiency)
            MMBTUinperTrip = MMBTUoutperTrip * (100 / EngineEfficiency);

            //Gallons of fuel per trip if it were powered by conventional diesel = (1/ Conventional Diesel BTUs per gallon) * 100000 * million BTUs in per trip 
            GALLONperTrip = (1 / conventionalDieselBTUperGal) * 1000000 * MMBTUinperTrip;

            //Total Horsepower of Auxiliary engines = Number of Aux engines in use * Aux engine rated Horsepower per engine
            TotalOnboardAUxHP = NumberOfAuxiliaryEnginesInUse * AuxiliaryEnginesRatedHPperEngine;

            //Time auxiliary engines are active in hours = (Percent of trip aux engines active / 100) * Total Trip Time in Hours
            TimeAuxActiveHours = (PercentOfTripAuxiliaryIsActive / 100) * TotalTripTimeHours;

            //Active Horsepower per Auxiliary engine = (Horsepower Load Factor Single engine / 100) * Aux engine Rated Horsepower pwe engine
            ActiveHPPerAuxEngine = (HPLoadFactorSingleEngine / 100) * AuxiliaryEnginesRatedHPperEngine;

            //Total auxiliary engine production = number of auxiliary engines in use * Active Horsepower per Aux Engine * Time aux engines active in hours * Kilowwats per Horsepower
            TotalAuxEnergyProduction = NumberOfAuxiliaryEnginesInUse * ActiveHPPerAuxEngine * TimeAuxActiveHours * KWperHP;

            //Aux Engine Kilowat Hours out per trip = Total auxiliary engine production
            AuxEngineKWHoutperTrip = TotalAuxEnergyProduction;

            //Auxiliary Engine million BTUs of energy to power the trip = (Aux engine Kilowat Hours Per Trip * BTU per Kilowat Hours) / 1000000
            AuxEngineMMBTUoutperTrip = (AuxEngineKWHoutperTrip * BTUperKWH) / 1000000;

            //Auxiliary Engine million BTUs of energy to put in to the engine in order to get the needed energy out = Aux engine mmbtu out * (100 / Auxiliary engine efficiency)
            AuxEngineMMBTUinperTrip = AuxEngineMMBTUoutperTrip * (100 / AuxiliaryEngineEfficiency);

            //Auxiliary Engine gallons of fuel per trip if it were using conventional diesel = (1 / Diesel btu per gallon) * 1000000 * auxiliary engine mmbtu in the engine to make the trip
            AuxEngineGALLONperTrip = (1 / conventionalDieselBTUperGal) * 1000000 * AuxEngineMMBTUinperTrip;
        }
        #endregion

        /// <summary>
        /// Changes labels based on updated values from calculation/manual changes
        /// </summary>
        #region Change Resutls
        public void changeResults()
        {
            //5 
            textBox1.Text = (string)VesselTypeID;
            numericUpDown1.Value = (decimal)NOX_gphphr_out;
            numericUpDown2.Value = (decimal)CO_gphphr_out;
            numericUpDown3.Value = (decimal)VOC_gphphr_out;
            numericUpDown4.Value = (decimal)PM10_gphphr_out;
            numericUpDown5.Value = (decimal)PM25_gphphr_out;
            numericUpDown6.Value = (decimal)N2O_gphphr_out;
            numericUpDown7.Value = (decimal)CH4_gphphr_out;

            numericUpDown132.Value = (decimal)NumberOfEngines;
            numericUpDown124.Value = (decimal)SingleEngineHP;
            numericUpDown138.Value = (decimal)KWperHP;
            numericUpDown137.Value = (decimal)GALperBBL;
            numericUpDown136.Value = (decimal)BBLperTONNE;
            numericUpDown141.Value = (decimal)BTUperKWH;
            numericUpDown143.Value = (decimal)TotalTripDistanceInMiles;
            numericUpDown142.Value = (decimal)TripTimeHours;
            numericUpDown140.Value = (decimal)TripTimeMinutes;
            numericUpDown147.Value = (decimal)POTIdle;
            numericUpDown153.Value = (decimal)POTManeuvering;
            numericUpDown158.Value = (decimal)POTPrecautionary;
            numericUpDown163.Value = (decimal)POTSlowCruise;
            numericUpDown168.Value = (decimal)POTFullCruise;
            numericUpDown145.Value = (decimal)HPLFIdle;
            numericUpDown151.Value = (decimal)HPLFManeuvering;
            numericUpDown156.Value = (decimal)HPLFPrecautionary;
            numericUpDown161.Value = (decimal)HPLFSlowCruise;
            numericUpDown166.Value = (decimal)HPLFFullCruise;
            numericUpDown175.Value = (decimal)EngineEfficiency;
         
            numericUpDown228.Value = (decimal)NumberOfOnBoarAuxiliaryEngines;
            numericUpDown229.Value = (decimal)NumberOfAuxiliaryEnginesInUse;
            numericUpDown230.Value = (decimal)AuxiliaryEnginesRatedHPperEngine;
            numericUpDown232.Value = (decimal)PercentOfTripAuxiliaryIsActive;
            numericUpDown234.Value = (decimal)HPLoadFactorSingleEngine;
            numericUpDown242.Value = (decimal)AuxiliaryEngineEfficiency;

            doCalculations();
            //All Results That Needed Calculation
            numericUpDown128.Value = (decimal)TotalOnboardHP;
            numericUpDown139.Value = (decimal)TotalTripTimeHours;
            numericUpDown146.Value = (decimal)TimeInIdle;
            numericUpDown152.Value = (decimal)TimeInManeuvering;
            numericUpDown157.Value = (decimal)TimeInPrecautionary;
            numericUpDown162.Value = (decimal)TimeInSlowCruise;
            numericUpDown167.Value = (decimal)TimeInFullCruise;
            numericUpDown144.Value = (decimal)HPPEIdle;
            numericUpDown150.Value = (decimal)HPPEManeuvering;
            numericUpDown155.Value = (decimal)HPPEPrecautionary;
            numericUpDown160.Value = (decimal)HPPESlowCruise;
            numericUpDown165.Value = (decimal)HPPEFullCruise;
            numericUpDown148.Value = (decimal)EPIdle;
            numericUpDown149.Value = (decimal)EPManeuvering;
            numericUpDown154.Value = (decimal)EPPrecautionary;
            numericUpDown159.Value = (decimal)EPSlowCruise;
            numericUpDown164.Value = (decimal)EPFullCruise;
            numericUpDown169.Value = (decimal)EPTotal;
            numericUpDown174.Value = (decimal)KWHOutperTrip;
            numericUpDown173.Value = (decimal)MMBTUoutperTrip;
            numericUpDown172.Value = (decimal)MMBTUinperTrip;
            numericUpDown171.Value = (decimal)GALLONperTrip;
            
            numericUpDown231.Value = (decimal)TotalOnboardAUxHP;
            numericUpDown233.Value = (decimal)TimeAuxActiveHours;
            numericUpDown235.Value = (decimal)ActiveHPPerAuxEngine;
            numericUpDown236.Value = (decimal)TotalAuxEnergyProduction;
            numericUpDown241.Value = (decimal)AuxEngineKWHoutperTrip;
            numericUpDown240.Value = (decimal)AuxEngineMMBTUoutperTrip;
            numericUpDown239.Value = (decimal)AuxEngineMMBTUinperTrip;
            numericUpDown238.Value = (decimal)AuxEngineGALLONperTrip;

            numericUpDown14.Value = (decimal)AUX_NOX_gphphr_out;
            numericUpDown13.Value = (decimal)AUX_CO_gphphr_out;
            numericUpDown12.Value = (decimal)AUX_VOC_gphphr_out;
            numericUpDown11.Value = (decimal)AUX_PM10_gphphr_out;
            numericUpDown10.Value = (decimal)AUX_PM25_gphphr_out;
            numericUpDown9.Value = (decimal)AUX_N2O_gphphr_out;
            numericUpDown8.Value = (decimal)AUX_CH4_gphphr_out;
        }
        #endregion

        /// <summary>
        /// Sets the variables to their initial default state
        /// </summary>
        #region Use Defaults
        public void useDefaults()
        {
            #region Main Engine Variables
            //5.1 Main Engine Variables
            VesselTypeID = "Cont. Ship 6000";
            NumberOfEngines = 1;
            SingleEngineHP = 75097;
            //Constants (These are units of measurement)
            KWperHP = .7457;
            GALperBBL = 42;
            BBLperTONNE = 7.45;
            BTUperKWH = 3412;

            //5.2 Trip Distance and Time
            TotalTripDistanceInMiles = 10600.00;
            TripTimeHours = 480.00;
            TripTimeMinutes = 0.00;

            //5.3 Engine Charicterization Per Mode
            //POT - Percent Of Trip, Time in mode is measured in hours HPLF - Horse Power Load Factor (Single engine). HPPE = Horse Power Per Engine EP = Energy Production in KWH for all engines
            POTIdle = 1.25;
            POTManeuvering = 1.75;
            POTPrecautionary = 5.00;
            POTSlowCruise = 7.00;
            POTFullCruise = 85.00;
            HPLFIdle = 2.00;
            HPLFManeuvering = 8.00;
            HPLFPrecautionary = 12.00;
            HPLFSlowCruise = 50.00;
            HPLFFullCruise = 95.00;

            //5.4b Calculation of Fuel Use Using Conventional Diesel as Baseline Fuel
            EngineEfficiency = 45.00;

            NOX_gphphr_out = 7.94;
            CO_gphphr_out = 7.94;
            VOC_gphphr_out = 7.94;
            PM10_gphphr_out = 7.94;
            PM25_gphphr_out = 7.94;
            N2O_gphphr_out = 7.94;
            CH4_gphphr_out = 7.94;
            #endregion
            #region Auxiliary Engine Variables

            //6.2 Auxiliary Engine Variables
            NumberOfOnBoarAuxiliaryEngines = 4;
            NumberOfAuxiliaryEnginesInUse = 2;
            AuxiliaryEnginesRatedHPperEngine = 1400;

            //6.3 Auxiliary Engine Characterization (Conventional Diesel as Baseline Fuel)
            PercentOfTripAuxiliaryIsActive = 50.00;
            HPLoadFactorSingleEngine = 80.00;

            //6.4b Calculation of Auxiliary Engine Fuel use Using Conventional Diesel as Baseline Fuel
            AuxiliaryEngineEfficiency = 40.00;

            AUX_NOX_gphphr_out = 7.94;
            AUX_CO_gphphr_out = 7.94;
            AUX_VOC_gphphr_out = 7.94;
            AUX_PM10_gphphr_out = 7.94;
            AUX_PM25_gphphr_out = 7.94;
            AUX_N2O_gphphr_out = 7.94;
            AUX_CH4_gphphr_out = 7.94;
            #endregion
        }
        #endregion


        //Runs the simulation, and opens up the new results windows
        private void runSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gfr = new GREETFormattedResults(this);
            gfr.Show();
        }

        //This will make a new input sheet, so you can perform multiple simulations at one time
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new TEAMS();
            f.Show();
        }

        //Closes the sheets if you hit the exit button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gfr.Close();
            this.Close();
        }

        #region Submit All

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            SubmitAll();
        }

        private void SubmitAll()
        {
            if (checkValid() == false)
            {
                MessageBox.Show("Percent of Trip In Mode (time) on Main Engine tab must sum to 100%!!", "ERROR");
                return;
            }

            //5.1
            VesselTypeID = textBox1.Text;
            NumberOfEngines = (int)numericUpDown132.Value;
            SingleEngineHP = (int)numericUpDown124.Value;
            TotalOnboardHP = SingleEngineHP * NumberOfEngines;
            numericUpDown128.Value = (decimal)TotalOnboardHP;
            //Constants (These are units of measurement)
            KWperHP = (double)numericUpDown138.Value;
            GALperBBL = (double)numericUpDown137.Value;
            BBLperTONNE = (double)numericUpDown136.Value;
            BTUperKWH = (double)numericUpDown141.Value;

            //5.2
            TotalTripDistanceInMiles = (double)numericUpDown143.Value;
            TripTimeHours = (double)numericUpDown142.Value;
            TripTimeMinutes = (double)numericUpDown140.Value;
            TotalTripTimeHours = TripTimeHours + (TripTimeMinutes / 60);
            numericUpDown139.Value = (decimal)TotalTripTimeHours;
            //5.3
            POTIdle = (double)numericUpDown147.Value;
            POTManeuvering = (double)numericUpDown153.Value;
            POTPrecautionary = (double)numericUpDown158.Value;
            POTSlowCruise = (double)numericUpDown163.Value;
            POTFullCruise = (double)numericUpDown168.Value;
            TimeInIdle = (POTIdle / 100) * TotalTripTimeHours;
            numericUpDown146.Value = (decimal)TimeInIdle;
            TimeInManeuvering = (POTManeuvering / 100) * TotalTripTimeHours;
            numericUpDown152.Value = (decimal)TimeInManeuvering;
            TimeInPrecautionary = (POTPrecautionary / 100) * TotalTripTimeHours;
            numericUpDown157.Value = (decimal)TimeInPrecautionary;
            TimeInSlowCruise = (POTSlowCruise / 100) * TotalTripTimeHours;
            numericUpDown162.Value = (decimal)TimeInSlowCruise;
            TimeInFullCruise = (POTFullCruise / 100) * TotalTripTimeHours;
            numericUpDown167.Value = (decimal)TimeInFullCruise;
            HPLFIdle = (double)numericUpDown145.Value;
            HPLFManeuvering = (double)numericUpDown151.Value;
            HPLFPrecautionary = (double)numericUpDown156.Value;
            HPLFSlowCruise = (double)numericUpDown161.Value;
            HPLFFullCruise = (double)numericUpDown166.Value;

            HPPEIdle = (HPLFIdle / 100) * SingleEngineHP;
            numericUpDown144.Value = (decimal)HPPEIdle;
            HPPEManeuvering = (HPLFManeuvering / 100) * SingleEngineHP;
            numericUpDown150.Value = (decimal)HPPEManeuvering;
            HPPEPrecautionary = (HPLFPrecautionary / 100) * SingleEngineHP;
            numericUpDown155.Value = (decimal)HPPEPrecautionary;
            HPPESlowCruise = (HPLFSlowCruise / 100) * SingleEngineHP;
            numericUpDown160.Value = (decimal)HPPESlowCruise;
            HPPEFullCruise = (HPLFFullCruise / 100) * SingleEngineHP;
            numericUpDown165.Value = (decimal)HPPEFullCruise;
            EPIdle = NumberOfEngines * HPPEIdle * TimeInIdle * KWperHP;
            numericUpDown148.Value = (decimal)EPIdle;
            EPManeuvering = NumberOfEngines * HPPEManeuvering * TimeInManeuvering * KWperHP;
            numericUpDown149.Value = (decimal)EPManeuvering;
            EPPrecautionary = NumberOfEngines * HPPEPrecautionary * TimeInPrecautionary * KWperHP;
            numericUpDown154.Value = (decimal)EPPrecautionary;
            EPSlowCruise = NumberOfEngines * HPPESlowCruise * TimeInSlowCruise * KWperHP;
            numericUpDown159.Value = (decimal)EPSlowCruise;
            EPFullCruise = NumberOfEngines * HPPEFullCruise * TimeInFullCruise * KWperHP;
            numericUpDown164.Value = (decimal)EPFullCruise;
            EPTotal = EPIdle + EPManeuvering + EPPrecautionary + EPSlowCruise + EPFullCruise;
            numericUpDown169.Value = (decimal)EPTotal;

            //5.4b
            EngineEfficiency = (double)numericUpDown175.Value;
            KWHOutperTrip = EPTotal;
            numericUpDown174.Value = (decimal)KWHOutperTrip;
            MMBTUoutperTrip = (KWHOutperTrip * BTUperKWH) / 1000000;
            numericUpDown173.Value = (decimal)MMBTUoutperTrip;
            MMBTUinperTrip = MMBTUoutperTrip * (100 / EngineEfficiency);
            numericUpDown172.Value = (decimal)MMBTUinperTrip;
            //Needs to pull from the Fuel Specs page in GREET
            GALLONperTrip = (1 / conventionalDieselBTUperGal) * 1000000 * MMBTUinperTrip;
            numericUpDown171.Value = (decimal)GALLONperTrip;

            //Fuel Inputs
            NOX_gphphr_out = (double)numericUpDown1.Value;
            CO_gphphr_out = (double)numericUpDown2.Value;
            VOC_gphphr_out = (double)numericUpDown3.Value;
            PM10_gphphr_out = (double)numericUpDown4.Value;
            PM25_gphphr_out = (double)numericUpDown5.Value;
            N2O_gphphr_out = (double)numericUpDown6.Value;
            CH4_gphphr_out = (double)numericUpDown7.Value;


            //6.2
            NumberOfOnBoarAuxiliaryEngines = (int)numericUpDown228.Value;
            NumberOfAuxiliaryEnginesInUse = (int)numericUpDown229.Value;
            AuxiliaryEnginesRatedHPperEngine = (int)numericUpDown230.Value;
            TotalOnboardAUxHP = NumberOfAuxiliaryEnginesInUse * AuxiliaryEnginesRatedHPperEngine;
            numericUpDown231.Value = (decimal)TotalOnboardAUxHP;

            //6.3
            PercentOfTripAuxiliaryIsActive = (double)numericUpDown232.Value;
            TimeAuxActiveHours = (PercentOfTripAuxiliaryIsActive / 100) * TotalTripTimeHours;
            numericUpDown233.Value = (decimal)TimeAuxActiveHours;
            HPLoadFactorSingleEngine = (double)numericUpDown234.Value;
            ActiveHPPerAuxEngine = (HPLoadFactorSingleEngine / 100) * AuxiliaryEnginesRatedHPperEngine;
            numericUpDown235.Value = (decimal)ActiveHPPerAuxEngine;
            TotalAuxEnergyProduction = NumberOfAuxiliaryEnginesInUse * ActiveHPPerAuxEngine * TimeAuxActiveHours * KWperHP;
            numericUpDown236.Value = (decimal)TotalAuxEnergyProduction;

            //6.4b
            AuxiliaryEngineEfficiency = (double)numericUpDown242.Value;
            AuxEngineKWHoutperTrip = TotalAuxEnergyProduction;
            numericUpDown241.Value = (decimal)AuxEngineKWHoutperTrip;
            AuxEngineMMBTUoutperTrip = (AuxEngineKWHoutperTrip * BTUperKWH) / 1000000;

            numericUpDown240.Value = (decimal)AuxEngineMMBTUoutperTrip;
            AuxEngineMMBTUinperTrip = AuxEngineMMBTUoutperTrip * (100 / AuxiliaryEngineEfficiency);
            numericUpDown239.Value = (decimal)AuxEngineMMBTUinperTrip;
            //This one requires fuel specs from GREET
            AuxEngineGALLONperTrip = (1 / conventionalDieselBTUperGal) * 1000000 * AuxEngineMMBTUinperTrip;
            numericUpDown238.Value = (decimal)AuxEngineGALLONperTrip;

            AUX_NOX_gphphr_out = (double)numericUpDown14.Value;
            AUX_CO_gphphr_out = (double)numericUpDown13.Value;
            AUX_VOC_gphphr_out = (double)numericUpDown12.Value;
            AUX_PM10_gphphr_out = (double)numericUpDown11.Value;
            AUX_PM25_gphphr_out = (double)numericUpDown10.Value;
            AUX_N2O_gphphr_out = (double)numericUpDown9.Value;
            AUX_CH4_gphphr_out = (double)numericUpDown8.Value;
            numericUpDown14.Value = (decimal)AUX_NOX_gphphr_out;

            doCalculations();
            changeResults();
        }
        #endregion

        //Checks to see that the percentage of trip variables actually add up to 100
        private bool checkValid()
        {
            decimal sum = 0;
            sum += (numericUpDown147.Value + numericUpDown153.Value + numericUpDown158.Value + 
                numericUpDown163.Value + numericUpDown168.Value );
            if (sum != 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
