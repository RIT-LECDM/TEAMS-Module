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
        public const double KWperHP = 0.745699872;
        public const double GALperBBL = 42.0;
        public const double BBLperTONNE = 7.45;
        public const double BTUperKWH = 3412.14163;

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
        public double Res_NOX_gphphr_out;   // gphphr = GramsPerHorsePowerHouR
        public double Res_CO_gphphr_out;
        public double Res_VOC_gphphr_out;
        public double Res_PM10_gphphr_out;
        public double Res_PM25_gphphr_out;
        public double Res_N2O_gphphr_out;
        public double Res_CH4_gphphr_out;

        public double Die_NOX_gphphr_out;
        public double Die_CO_gphphr_out;
        public double Die_VOC_gphphr_out;
        public double Die_PM10_gphphr_out;
        public double Die_PM25_gphphr_out;
        public double Die_N2O_gphphr_out;
        public double Die_CH4_gphphr_out;

        public double Nat_NOX_gphphr_out;
        public double Nat_CO_gphphr_out;
        public double Nat_VOC_gphphr_out;
        public double Nat_PM10_gphphr_out;
        public double Nat_PM25_gphphr_out;
        public double Nat_N2O_gphphr_out;
        public double Nat_CH4_gphphr_out;

        public double Fis_NOX_gphphr_out;
        public double Fis_CO_gphphr_out;
        public double Fis_VOC_gphphr_out;
        public double Fis_PM10_gphphr_out;
        public double Fis_PM25_gphphr_out;
        public double Fis_N2O_gphphr_out;
        public double Fis_CH4_gphphr_out;

        public double Bio_NOX_gphphr_out;
        public double Bio_CO_gphphr_out;
        public double Bio_VOC_gphphr_out;
        public double Bio_PM10_gphphr_out;
        public double Bio_PM25_gphphr_out;
        public double Bio_N2O_gphphr_out;
        public double Bio_CH4_gphphr_out;

        public double Ult_NOX_gphphr_out;
        public double Ult_CO_gphphr_out;
        public double Ult_VOC_gphphr_out;
        public double Ult_PM10_gphphr_out;
        public double Ult_PM25_gphphr_out;
        public double Ult_N2O_gphphr_out;
        public double Ult_CH4_gphphr_out;

        public double[] Residual_Oil;
        public double[] Diesel;
        public double[] Natural_Gas;
        public double[] Fischer;
        public double[] Biodiesel;
        public double[] Ult_Low_Sulf;

        //Global Warming Potential
        public double CO2_GWP;
        public double CH4_GWP;
        public double N2O_GWP;
        public double VOC_GWP;
        public double CO_GWP;
        public double NO2_GWP;
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

        public double Aux_Res_NOX_gphphr_out;
        public double Aux_Res_CO_gphphr_out;
        public double Aux_Res_VOC_gphphr_out;
        public double Aux_Res_PM10_gphphr_out;
        public double Aux_Res_PM25_gphphr_out;
        public double Aux_Res_N2O_gphphr_out;
        public double Aux_Res_CH4_gphphr_out;

        public double Aux_Die_NOX_gphphr_out;
        public double Aux_Die_CO_gphphr_out;
        public double Aux_Die_VOC_gphphr_out;
        public double Aux_Die_PM10_gphphr_out;
        public double Aux_Die_PM25_gphphr_out;
        public double Aux_Die_N2O_gphphr_out;
        public double Aux_Die_CH4_gphphr_out;

        public double Aux_Nat_NOX_gphphr_out;
        public double Aux_Nat_CO_gphphr_out;
        public double Aux_Nat_VOC_gphphr_out;
        public double Aux_Nat_PM10_gphphr_out;
        public double Aux_Nat_PM25_gphphr_out;
        public double Aux_Nat_N2O_gphphr_out;
        public double Aux_Nat_CH4_gphphr_out;

        public double Aux_Fis_NOX_gphphr_out;
        public double Aux_Fis_CO_gphphr_out;
        public double Aux_Fis_VOC_gphphr_out;
        public double Aux_Fis_PM10_gphphr_out;
        public double Aux_Fis_PM25_gphphr_out;
        public double Aux_Fis_N2O_gphphr_out;
        public double Aux_Fis_CH4_gphphr_out;

        public double Aux_Bio_NOX_gphphr_out;
        public double Aux_Bio_CO_gphphr_out;
        public double Aux_Bio_VOC_gphphr_out;
        public double Aux_Bio_PM10_gphphr_out;
        public double Aux_Bio_PM25_gphphr_out;
        public double Aux_Bio_N2O_gphphr_out;
        public double Aux_Bio_CH4_gphphr_out;

        public double Aux_Ult_NOX_gphphr_out;
        public double Aux_Ult_CO_gphphr_out;
        public double Aux_Ult_VOC_gphphr_out;
        public double Aux_Ult_PM10_gphphr_out;
        public double Aux_Ult_PM25_gphphr_out;
        public double Aux_Ult_N2O_gphphr_out;
        public double Aux_Ult_CH4_gphphr_out;

        public double[] Aux_Residual_Oil;
        public double[] Aux_Diesel;
        public double[] Aux_Natural_Gas;
        public double[] Aux_Fischer;
        public double[] Aux_Biodiesel;
        public double[] Aux_Ult_Low_Sulf;

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

            Res_NOX.Value = (decimal)Res_NOX_gphphr_out;
            Res_CO.Value = (decimal)Res_CO_gphphr_out;
            Res_VOC.Value = (decimal)Res_VOC_gphphr_out;
            Res_PM10.Value = (decimal)Res_PM10_gphphr_out;
            Res_PM25.Value = (decimal)Res_PM25_gphphr_out;
            Res_N2O.Value = (decimal)Res_N2O_gphphr_out;
            Res_CH4.Value = (decimal)Res_CH4_gphphr_out;

            Die_NOX.Value = (decimal)Die_NOX_gphphr_out;
            Die_CO.Value = (decimal)Die_CO_gphphr_out;
            Die_VOC.Value = (decimal)Die_VOC_gphphr_out;
            Die_PM10.Value = (decimal)Die_PM10_gphphr_out;
            Die_PM25.Value = (decimal)Die_PM25_gphphr_out;
            Die_N2O.Value = (decimal)Die_N2O_gphphr_out;
            Die_CH4.Value = (decimal)Die_CH4_gphphr_out;

            Nat_NOX.Value = (decimal)Nat_NOX_gphphr_out;
            Nat_CO.Value = (decimal)Nat_CO_gphphr_out;
            Nat_VOC.Value = (decimal)Nat_VOC_gphphr_out;
            Nat_PM10.Value = (decimal)Nat_PM10_gphphr_out;
            Nat_PM25.Value = (decimal)Nat_PM25_gphphr_out;
            Nat_N2O.Value = (decimal)Nat_N2O_gphphr_out;
            Nat_CH4.Value = (decimal)Nat_CH4_gphphr_out;

            Fis_NOX.Value = (decimal)Fis_NOX_gphphr_out;
            Fis_CO.Value = (decimal)Fis_CO_gphphr_out;
            Fis_VOC.Value = (decimal)Fis_VOC_gphphr_out;
            Fis_PM10.Value = (decimal)Fis_PM10_gphphr_out;
            Fis_PM25.Value = (decimal)Fis_PM25_gphphr_out;
            Fis_N2O.Value = (decimal)Fis_N2O_gphphr_out;
            Fis_CH4.Value = (decimal)Fis_CH4_gphphr_out;

            Bio_NOX.Value = (decimal)Bio_NOX_gphphr_out;
            Bio_CO.Value = (decimal)Bio_CO_gphphr_out;
            Bio_VOC.Value = (decimal)Bio_VOC_gphphr_out;
            Bio_PM10.Value = (decimal)Bio_PM10_gphphr_out;
            Bio_PM25.Value = (decimal)Bio_PM25_gphphr_out;
            Bio_N2O.Value = (decimal)Bio_N2O_gphphr_out;
            Bio_CH4.Value = (decimal)Bio_CH4_gphphr_out;

            Ult_NOX.Value = (decimal)Ult_NOX_gphphr_out;
            Ult_CO.Value = (decimal)Ult_CO_gphphr_out;
            Ult_VOC.Value = (decimal)Ult_VOC_gphphr_out;
            Ult_PM10.Value = (decimal)Ult_PM10_gphphr_out;
            Ult_PM25.Value = (decimal)Ult_PM25_gphphr_out;
            Ult_N2O.Value = (decimal)Ult_N2O_gphphr_out;
            Ult_CH4.Value = (decimal)Ult_CH4_gphphr_out;



            numericUpDown132.Value = (decimal)NumberOfEngines;
            numericUpDown124.Value = (decimal)SingleEngineHP;
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

            Aux_Res_NOX.Value = (decimal)Aux_Res_NOX_gphphr_out;
            Aux_Res_CO.Value = (decimal)Aux_Res_CO_gphphr_out;
            Aux_Res_VOC.Value = (decimal)Aux_Res_VOC_gphphr_out;
            Aux_Res_PM10.Value = (decimal)Aux_Res_PM10_gphphr_out;
            Aux_Res_PM25.Value = (decimal)Aux_Res_PM25_gphphr_out;
            Aux_Res_N2O.Value = (decimal)Aux_Res_N2O_gphphr_out;
            Aux_Res_CH4.Value = (decimal)Aux_Res_CH4_gphphr_out;

            Aux_Die_NOX.Value = (decimal)Aux_Die_NOX_gphphr_out;
            Aux_Die_CO.Value = (decimal)Aux_Die_CO_gphphr_out;
            Aux_Die_VOC.Value = (decimal)Aux_Die_VOC_gphphr_out;
            Aux_Die_PM10.Value = (decimal)Aux_Die_PM10_gphphr_out;
            Aux_Die_PM25.Value = (decimal)Aux_Die_PM25_gphphr_out;
            Aux_Die_N2O.Value = (decimal)Aux_Die_N2O_gphphr_out;
            Aux_Die_CH4.Value = (decimal)Aux_Die_CH4_gphphr_out;

            Aux_Nat_NOX.Value = (decimal)Aux_Nat_NOX_gphphr_out;
            Aux_Nat_CO.Value = (decimal)Aux_Nat_CO_gphphr_out;
            Aux_Nat_VOC.Value = (decimal)Aux_Nat_VOC_gphphr_out;
            Aux_Nat_PM10.Value = (decimal)Aux_Nat_PM10_gphphr_out;
            Aux_Nat_PM25.Value = (decimal)Aux_Nat_PM25_gphphr_out;
            Aux_Nat_N2O.Value = (decimal)Aux_Nat_N2O_gphphr_out;
            Aux_Nat_CH4.Value = (decimal)Aux_Nat_CH4_gphphr_out;

            Aux_Fis_NOX.Value = (decimal)Aux_Fis_NOX_gphphr_out;
            Aux_Fis_CO.Value = (decimal)Aux_Fis_CO_gphphr_out;
            Aux_Fis_VOC.Value = (decimal)Aux_Fis_VOC_gphphr_out;
            Aux_Fis_PM10.Value = (decimal)Aux_Fis_PM10_gphphr_out;
            Aux_Fis_PM25.Value = (decimal)Aux_Fis_PM25_gphphr_out;
            Aux_Fis_N2O.Value = (decimal)Aux_Fis_N2O_gphphr_out;
            Aux_Fis_CH4.Value = (decimal)Aux_Fis_CH4_gphphr_out;

            Aux_Bio_NOX.Value = (decimal)Aux_Bio_NOX_gphphr_out;
            Aux_Bio_CO.Value = (decimal)Aux_Bio_CO_gphphr_out;
            Aux_Bio_VOC.Value = (decimal)Aux_Bio_VOC_gphphr_out;
            Aux_Bio_PM10.Value = (decimal)Aux_Bio_PM10_gphphr_out;
            Aux_Bio_PM25.Value = (decimal)Aux_Bio_PM25_gphphr_out;
            Aux_Bio_N2O.Value = (decimal)Aux_Bio_N2O_gphphr_out;
            Aux_Bio_CH4.Value = (decimal)Aux_Bio_CH4_gphphr_out;

            Aux_Ult_NOX.Value = (decimal)Aux_Ult_NOX_gphphr_out;
            Aux_Ult_CO.Value = (decimal)Aux_Ult_CO_gphphr_out;
            Aux_Ult_VOC.Value = (decimal)Aux_Ult_VOC_gphphr_out;
            Aux_Ult_PM10.Value = (decimal)Aux_Ult_PM10_gphphr_out;
            Aux_Ult_PM25.Value = (decimal)Aux_Ult_PM25_gphphr_out;
            Aux_Ult_N2O.Value = (decimal)Aux_Ult_N2O_gphphr_out;
            Aux_Ult_CH4.Value = (decimal)Aux_Ult_CH4_gphphr_out;

            //Global Warming Potential
            numericUpDown21.Value = (decimal)CO2_GWP;
            numericUpDown20.Value = (decimal)CH4_GWP;
            numericUpDown19.Value = (decimal)N2O_GWP;
            numericUpDown18.Value = (decimal)VOC_GWP;
            numericUpDown17.Value = (decimal)CO_GWP;
            numericUpDown16.Value = (decimal)NO2_GWP;
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

            //5.4b Calculation of all Fuels
            EngineEfficiency = 45.00;

            Res_NOX_gphphr_out  =   14.015;
            Res_CO_gphphr_out   =   2.429;
            Res_VOC_gphphr_out  =   0.528;
            Res_PM10_gphphr_out =   0.415;
            Res_PM25_gphphr_out =   0.415;    // Left as same as PM10 for now, per Jamie's request
            Res_N2O_gphphr_out  =   0.011;
            Res_CH4_gphphr_out  =   0.025;

            Die_NOX_gphphr_out  =   14.015;
            Die_CO_gphphr_out   =   2.429;
            Die_VOC_gphphr_out  =   0.528;
            Die_PM10_gphphr_out =   0.415;
            Die_PM25_gphphr_out =   0.415;
            Die_N2O_gphphr_out  =   0.011;
            Die_CH4_gphphr_out  =   0.025;

            Nat_NOX_gphphr_out  =   14.015;
            Nat_CO_gphphr_out   =   1.214;
            Nat_VOC_gphphr_out  =   0.528;
            Nat_PM10_gphphr_out =   0.004;
            Nat_PM25_gphphr_out =   0.004;
            Nat_N2O_gphphr_out  =   0.011;
            Nat_CH4_gphphr_out  =   0.517;

            Fis_NOX_gphphr_out  =   14.015;
            Fis_CO_gphphr_out   =   2.429;
            Fis_VOC_gphphr_out  =   0.528;
            Fis_PM10_gphphr_out =   0.415;
            Fis_PM25_gphphr_out =   0.415;
            Fis_N2O_gphphr_out  =   0.011;
            Fis_CH4_gphphr_out  =   0.025;

            Bio_NOX_gphphr_out  =   14.015;
            Bio_CO_gphphr_out   =   2.429;
            Bio_VOC_gphphr_out  =   0.528;
            Bio_PM10_gphphr_out =   0.415;
            Bio_PM25_gphphr_out =   0.415;
            Bio_N2O_gphphr_out  =   0.022;
            Bio_CH4_gphphr_out  =   0.025;

            Ult_NOX_gphphr_out  =   14.015;
            Ult_CO_gphphr_out   =   2.429;
            Ult_VOC_gphphr_out  =   0.528;
            Ult_PM10_gphphr_out =   0.415;
            Ult_PM25_gphphr_out =   0.415;
            Ult_N2O_gphphr_out  =   0.011;
            Ult_CH4_gphphr_out  =   0.025;


            //Global Warming Potential
            CO2_GWP = 1;
            CH4_GWP = 23;
            N2O_GWP = 296;
            VOC_GWP = 0;
            CO_GWP = 0;
            NO2_GWP = 0;
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

            Aux_Res_NOX_gphphr_out = 14.015;
            Aux_Res_CO_gphphr_out = 2.429;
            Aux_Res_VOC_gphphr_out = 0.528;
            Aux_Res_PM10_gphphr_out = 0.415;
            Aux_Res_PM25_gphphr_out = 0.415;
            Aux_Res_N2O_gphphr_out = 0.011;
            Aux_Res_CH4_gphphr_out = 0.025;

            Aux_Die_NOX_gphphr_out = 14.015;
            Aux_Die_CO_gphphr_out = 2.429;
            Aux_Die_VOC_gphphr_out = 0.528;
            Aux_Die_PM10_gphphr_out = 0.415;
            Aux_Die_PM25_gphphr_out = 0.415;
            Aux_Die_N2O_gphphr_out = 0.011;
            Aux_Die_CH4_gphphr_out = 0.025;

            Aux_Nat_NOX_gphphr_out = 14.015;
            Aux_Nat_CO_gphphr_out = 1.214;
            Aux_Nat_VOC_gphphr_out = 0.528;
            Aux_Nat_PM10_gphphr_out = 0.004;
            Aux_Nat_PM25_gphphr_out = 0.004;
            Aux_Nat_N2O_gphphr_out = 0.011;
            Aux_Nat_CH4_gphphr_out = 0.517;

            Aux_Fis_NOX_gphphr_out = 14.015;
            Aux_Fis_CO_gphphr_out = 2.429;
            Aux_Fis_VOC_gphphr_out = 0.528;
            Aux_Fis_PM10_gphphr_out = 0.415;
            Aux_Fis_PM25_gphphr_out = 0.415;
            Aux_Fis_N2O_gphphr_out = 0.011;
            Aux_Fis_CH4_gphphr_out = 0.025;

            Aux_Bio_NOX_gphphr_out = 14.015;
            Aux_Bio_CO_gphphr_out = 2.429;
            Aux_Bio_VOC_gphphr_out = 0.528;
            Aux_Bio_PM10_gphphr_out = 0.415;
            Aux_Bio_PM25_gphphr_out = 0.415;
            Aux_Bio_N2O_gphphr_out = 0.022;
            Aux_Bio_CH4_gphphr_out = 0.025;

            Aux_Ult_NOX_gphphr_out = 14.015;
            Aux_Ult_CO_gphphr_out = 2.429;
            Aux_Ult_VOC_gphphr_out = 0.528;
            Aux_Ult_PM10_gphphr_out = 0.415;
            Aux_Ult_PM25_gphphr_out = 0.415;
            Aux_Ult_N2O_gphphr_out = 0.011;
            Aux_Ult_CH4_gphphr_out = 0.025;

            #endregion
        }
        #endregion


        //Runs the simulation, and opens up the new results windows
        private void runSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubmitAll();
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
            Res_NOX_gphphr_out = (double)Res_NOX.Value;
            Res_CO_gphphr_out = (double)Res_CO.Value;
            Res_VOC_gphphr_out = (double)Res_VOC.Value;
            Res_PM10_gphphr_out = (double)Res_PM10.Value;
            Res_PM25_gphphr_out = (double)Res_PM25.Value;
            Res_N2O_gphphr_out = (double)Res_N2O.Value;
            Res_CH4_gphphr_out = (double)Res_CH4.Value;
            Residual_Oil = new double[7] 
                {Res_VOC_gphphr_out, Res_CO_gphphr_out, Res_NOX_gphphr_out, 
                Res_PM10_gphphr_out, Res_PM25_gphphr_out, Res_CH4_gphphr_out, 
                Res_N2O_gphphr_out};

            Die_NOX_gphphr_out = (double)Die_NOX.Value;
            Die_CO_gphphr_out = (double)Die_CO.Value;
            Die_VOC_gphphr_out = (double)Die_VOC.Value;
            Die_PM10_gphphr_out = (double)Die_PM10.Value;
            Die_PM25_gphphr_out = (double)Die_PM25.Value;
            Die_N2O_gphphr_out = (double)Die_N2O.Value;
            Die_CH4_gphphr_out = (double)Die_CH4.Value;
            Diesel = new double[7] 
                {Die_VOC_gphphr_out, Die_CO_gphphr_out, Die_NOX_gphphr_out, 
                Die_PM10_gphphr_out, Die_PM25_gphphr_out, Die_CH4_gphphr_out, 
                Die_N2O_gphphr_out};

            Nat_NOX_gphphr_out = (double)Nat_NOX.Value;
            Nat_CO_gphphr_out = (double)Nat_CO.Value;
            Nat_VOC_gphphr_out = (double)Nat_VOC.Value;
            Nat_PM10_gphphr_out = (double)Nat_PM10.Value;
            Nat_PM25_gphphr_out = (double)Nat_PM25.Value;
            Nat_N2O_gphphr_out = (double)Nat_N2O.Value;
            Nat_CH4_gphphr_out = (double)Nat_CH4.Value;
            Natural_Gas = new double[7] 
                {Nat_VOC_gphphr_out, Nat_CO_gphphr_out, Nat_NOX_gphphr_out, 
                Nat_PM10_gphphr_out, Nat_PM25_gphphr_out, Nat_CH4_gphphr_out, 
                Nat_N2O_gphphr_out};

            Fis_NOX_gphphr_out = (double)Fis_NOX.Value;
            Fis_CO_gphphr_out = (double)Fis_CO.Value;
            Fis_VOC_gphphr_out = (double)Fis_VOC.Value;
            Fis_PM10_gphphr_out = (double)Fis_PM10.Value;
            Fis_PM25_gphphr_out = (double)Fis_PM25.Value;
            Fis_N2O_gphphr_out = (double)Fis_N2O.Value;
            Fis_CH4_gphphr_out = (double)Fis_CH4.Value;
            Fischer = new double[7] 
                {Fis_VOC_gphphr_out, Fis_CO_gphphr_out, Fis_NOX_gphphr_out, 
                Fis_PM10_gphphr_out, Fis_PM25_gphphr_out, Fis_CH4_gphphr_out, 
                Fis_N2O_gphphr_out};

            Bio_NOX_gphphr_out = (double)Bio_NOX.Value;
            Bio_CO_gphphr_out = (double)Bio_CO.Value;
            Bio_VOC_gphphr_out = (double)Bio_VOC.Value;
            Bio_PM10_gphphr_out = (double)Bio_PM10.Value;
            Bio_PM25_gphphr_out = (double)Bio_PM25.Value;
            Bio_N2O_gphphr_out = (double)Bio_N2O.Value;
            Bio_CH4_gphphr_out = (double)Bio_CH4.Value;
            Biodiesel = new double[7] 
                {Bio_VOC_gphphr_out, Bio_CO_gphphr_out, Bio_NOX_gphphr_out, 
                Bio_PM10_gphphr_out, Bio_PM25_gphphr_out, Bio_CH4_gphphr_out, 
                Bio_N2O_gphphr_out};

            Ult_NOX_gphphr_out = (double)Ult_NOX.Value;
            Ult_CO_gphphr_out = (double)Ult_CO.Value;
            Ult_VOC_gphphr_out = (double)Ult_VOC.Value;
            Ult_PM10_gphphr_out = (double)Ult_PM10.Value;
            Ult_PM25_gphphr_out = (double)Ult_PM25.Value;
            Ult_N2O_gphphr_out = (double)Ult_N2O.Value;
            Ult_CH4_gphphr_out = (double)Ult_CH4.Value;
            Ult_Low_Sulf = new double[7] 
                {Ult_VOC_gphphr_out, Ult_CO_gphphr_out, Ult_NOX_gphphr_out, 
                Ult_PM10_gphphr_out, Ult_PM25_gphphr_out, Ult_CH4_gphphr_out, 
                Ult_N2O_gphphr_out};


            //Global Warming Potential
            CO2_GWP = (double)numericUpDown21.Value;
            CH4_GWP = (double)numericUpDown20.Value;
            N2O_GWP = (double)numericUpDown19.Value;
            VOC_GWP = (double)numericUpDown18.Value;
            CO_GWP = (double)numericUpDown17.Value;
            NO2_GWP = (double)numericUpDown16.Value;
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



            Aux_Res_NOX_gphphr_out = (double)Aux_Res_NOX.Value;
            Aux_Res_CO_gphphr_out = (double)Aux_Res_CO.Value;
            Aux_Res_VOC_gphphr_out = (double)Aux_Res_VOC.Value;
            Aux_Res_PM10_gphphr_out = (double)Aux_Res_PM10.Value;
            Aux_Res_PM25_gphphr_out = (double)Aux_Res_PM25.Value;
            Aux_Res_N2O_gphphr_out = (double)Aux_Res_N2O.Value;
            Aux_Res_CH4_gphphr_out = (double)Aux_Res_CH4.Value;
            Aux_Residual_Oil = new double[7] 
                {Aux_Res_VOC_gphphr_out, Aux_Res_CO_gphphr_out, Aux_Res_NOX_gphphr_out, 
                Aux_Res_PM10_gphphr_out, Aux_Res_PM25_gphphr_out, Aux_Res_CH4_gphphr_out, 
                Aux_Res_N2O_gphphr_out};

            Aux_Die_NOX_gphphr_out = (double)Aux_Die_NOX.Value;
            Aux_Die_CO_gphphr_out = (double)Aux_Die_CO.Value;
            Aux_Die_VOC_gphphr_out = (double)Aux_Die_VOC.Value;
            Aux_Die_PM10_gphphr_out = (double)Aux_Die_PM10.Value;
            Aux_Die_PM25_gphphr_out = (double)Aux_Die_PM25.Value;
            Aux_Die_N2O_gphphr_out = (double)Aux_Die_N2O.Value;
            Aux_Die_CH4_gphphr_out = (double)Aux_Die_CH4.Value;
            Aux_Diesel = new double[7] 
                {Aux_Die_VOC_gphphr_out, Aux_Die_CO_gphphr_out, Aux_Die_NOX_gphphr_out, 
                Aux_Die_PM10_gphphr_out, Aux_Die_PM25_gphphr_out, Aux_Die_CH4_gphphr_out, 
                Aux_Die_N2O_gphphr_out};

            Aux_Nat_NOX_gphphr_out = (double)Aux_Nat_NOX.Value;
            Aux_Nat_CO_gphphr_out = (double)Aux_Nat_CO.Value;
            Aux_Nat_VOC_gphphr_out = (double)Aux_Nat_VOC.Value;
            Aux_Nat_PM10_gphphr_out = (double)Aux_Nat_PM10.Value;
            Aux_Nat_PM25_gphphr_out = (double)Aux_Nat_PM25.Value;
            Aux_Nat_N2O_gphphr_out = (double)Aux_Nat_N2O.Value;
            Aux_Nat_CH4_gphphr_out = (double)Aux_Nat_CH4.Value;
            Aux_Natural_Gas = new double[7] 
                {Aux_Nat_VOC_gphphr_out, Aux_Nat_CO_gphphr_out, Aux_Nat_NOX_gphphr_out, 
                Aux_Nat_PM10_gphphr_out, Aux_Nat_PM25_gphphr_out, Aux_Nat_CH4_gphphr_out, 
                Aux_Nat_N2O_gphphr_out};

            Aux_Fis_NOX_gphphr_out = (double)Aux_Fis_NOX.Value;
            Aux_Fis_CO_gphphr_out = (double)Aux_Fis_CO.Value;
            Aux_Fis_VOC_gphphr_out = (double)Aux_Fis_VOC.Value;
            Aux_Fis_PM10_gphphr_out = (double)Aux_Fis_PM10.Value;
            Aux_Fis_PM25_gphphr_out = (double)Aux_Fis_PM25.Value;
            Aux_Fis_N2O_gphphr_out = (double)Aux_Fis_N2O.Value;
            Aux_Fis_CH4_gphphr_out = (double)Aux_Fis_CH4.Value;
            Aux_Fischer = new double[7] 
                {Aux_Fis_VOC_gphphr_out, Aux_Fis_CO_gphphr_out, Aux_Fis_NOX_gphphr_out, 
                Aux_Fis_PM10_gphphr_out, Aux_Fis_PM25_gphphr_out, Aux_Fis_CH4_gphphr_out, 
                Aux_Fis_N2O_gphphr_out};

            Aux_Bio_NOX_gphphr_out = (double)Aux_Bio_NOX.Value;
            Aux_Bio_CO_gphphr_out = (double)Aux_Bio_CO.Value;
            Aux_Bio_VOC_gphphr_out = (double)Aux_Bio_VOC.Value;
            Aux_Bio_PM10_gphphr_out = (double)Aux_Bio_PM10.Value;
            Aux_Bio_PM25_gphphr_out = (double)Aux_Bio_PM25.Value;
            Aux_Bio_N2O_gphphr_out = (double)Aux_Bio_N2O.Value;
            Aux_Bio_CH4_gphphr_out = (double)Aux_Bio_CH4.Value;
            Aux_Biodiesel = new double[7] 
                {Aux_Bio_VOC_gphphr_out, Aux_Bio_CO_gphphr_out, Aux_Bio_NOX_gphphr_out, 
                Aux_Bio_PM10_gphphr_out, Aux_Bio_PM25_gphphr_out, Aux_Bio_CH4_gphphr_out, 
                Aux_Bio_N2O_gphphr_out};

            Aux_Ult_NOX_gphphr_out = (double)Aux_Ult_NOX.Value;
            Aux_Ult_CO_gphphr_out = (double)Aux_Ult_CO.Value;
            Aux_Ult_VOC_gphphr_out = (double)Aux_Ult_VOC.Value;
            Aux_Ult_PM10_gphphr_out = (double)Aux_Ult_PM10.Value;
            Aux_Ult_PM25_gphphr_out = (double)Aux_Ult_PM25.Value;
            Aux_Ult_N2O_gphphr_out = (double)Aux_Ult_N2O.Value;
            Aux_Ult_CH4_gphphr_out = (double)Aux_Ult_CH4.Value;
            Aux_Ult_Low_Sulf = new double[7] 
                {Aux_Ult_VOC_gphphr_out, Aux_Ult_CO_gphphr_out, Aux_Ult_NOX_gphphr_out, 
                Aux_Ult_PM10_gphphr_out, Aux_Ult_PM25_gphphr_out, Aux_Ult_CH4_gphphr_out, 
                Aux_Ult_N2O_gphphr_out};

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

        private void Reset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to reset the form back to default values?", "Reset Input", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
                TEAMS newWindow = new TEAMS();
                newWindow.Show();
            }
        }


    }
}
