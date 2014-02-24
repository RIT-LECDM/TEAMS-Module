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
        TEAMS te;

        //Variables for the results 
        #region Table 1 Variables in the form of lists, the lists will each be a different collumn of the spreadsheet on table 1
        List<double> ROone = new List<double>();
        List<double> CDone = new List<double>();
        List<double> LSDone = new List<double>();
        List<double> LNGone = new List<double>();
        List<double> BDone = new List<double>();
        List<double> FTone = new List<double>();

        #endregion
        public ResultsSheet(TEAMS t)
        {
            te = t;
            InitializeComponent();
            populateListsWithResults();
            correctNumbersDisplayed();
        }

        public void populateListsWithResults()
        {
            //The numbers being added are just placeholders for the results that will actually be populating those spaces
            ROone.Add(0);
            ROone.Add(1);
            ROone.Add(2);
            ROone.Add(3);
            ROone.Add(4);
            ROone.Add(5);
            ROone.Add(6);
            ROone.Add(7);
            ROone.Add(8);
            ROone.Add(9);
            ROone.Add(10);
            ROone.Add(11);
            ROone.Add(12);

            CDone.Add(0);
            CDone.Add(1);
            CDone.Add(2);
            CDone.Add(3);
            CDone.Add(4);
            CDone.Add(5);
            CDone.Add(6);
            CDone.Add(7);
            CDone.Add(8);
            CDone.Add(9);
            CDone.Add(10);
            CDone.Add(11);
            CDone.Add(12);

            LSDone.Add(0);
            LSDone.Add(1);
            LSDone.Add(2);
            LSDone.Add(3);
            LSDone.Add(4);
            LSDone.Add(5);
            LSDone.Add(6);
            LSDone.Add(7);
            LSDone.Add(8);
            LSDone.Add(9);
            LSDone.Add(10);
            LSDone.Add(11);
            LSDone.Add(12);

            LNGone.Add(0);
            LNGone.Add(1);
            LNGone.Add(2);
            LNGone.Add(3);
            LNGone.Add(4);
            LNGone.Add(5);
            LNGone.Add(6);
            LNGone.Add(7);
            LNGone.Add(8);
            LNGone.Add(9);
            LNGone.Add(10);
            LNGone.Add(11);
            LNGone.Add(12);

            BDone.Add(0);
            BDone.Add(1);
            BDone.Add(2);
            BDone.Add(3);
            BDone.Add(4);
            BDone.Add(5);
            BDone.Add(6);
            BDone.Add(7);
            BDone.Add(8);
            BDone.Add(9);
            BDone.Add(10);
            BDone.Add(11);
            BDone.Add(12);

            FTone.Add(0);
            FTone.Add(1);
            FTone.Add(2);
            FTone.Add(3);
            FTone.Add(4);
            FTone.Add(5);
            FTone.Add(6);
            FTone.Add(7);
            FTone.Add(8);
            FTone.Add(9);
            FTone.Add(10);
            FTone.Add(11);
            FTone.Add(12);
        }
        public void correctNumbersDisplayed()
        {
            numericUpDown1.Value = (decimal)ROone.ElementAt(0);
            numericUpDown12.Value = (decimal)ROone.ElementAt(1);
            numericUpDown18.Value = (decimal)ROone.ElementAt(2);
            numericUpDown24.Value = (decimal)ROone.ElementAt(3);
            numericUpDown30.Value = (decimal)ROone.ElementAt(4);
            numericUpDown36.Value = (decimal)ROone.ElementAt(5);
            numericUpDown42.Value = (decimal)ROone.ElementAt(6);
            numericUpDown48.Value = (decimal)ROone.ElementAt(7);
            numericUpDown54.Value = (decimal)ROone.ElementAt(8);
            numericUpDown60.Value = (decimal)ROone.ElementAt(9);
            numericUpDown66.Value = (decimal)ROone.ElementAt(10);
            numericUpDown72.Value = (decimal)ROone.ElementAt(11);
            numericUpDown78.Value = (decimal)ROone.ElementAt(12);

            numericUpDown2.Value = (decimal)CDone.ElementAt(0);
            numericUpDown11.Value = (decimal)CDone.ElementAt(1);
            numericUpDown17.Value = (decimal)CDone.ElementAt(2);
            numericUpDown23.Value = (decimal)CDone.ElementAt(3);
            numericUpDown29.Value = (decimal)CDone.ElementAt(4);
            numericUpDown35.Value = (decimal)CDone.ElementAt(5);
            numericUpDown41.Value = (decimal)CDone.ElementAt(6);
            numericUpDown47.Value = (decimal)CDone.ElementAt(7);
            numericUpDown53.Value = (decimal)CDone.ElementAt(8);
            numericUpDown59.Value = (decimal)CDone.ElementAt(9);
            numericUpDown65.Value = (decimal)CDone.ElementAt(10);
            numericUpDown71.Value = (decimal)CDone.ElementAt(11);
            numericUpDown77.Value = (decimal)CDone.ElementAt(12);

            numericUpDown3.Value = (decimal)LSDone.ElementAt(0);
            numericUpDown10.Value = (decimal)LSDone.ElementAt(1);
            numericUpDown16.Value = (decimal)LSDone.ElementAt(2);
            numericUpDown22.Value = (decimal)LSDone.ElementAt(3);
            numericUpDown28.Value = (decimal)LSDone.ElementAt(4);
            numericUpDown34.Value = (decimal)LSDone.ElementAt(5);
            numericUpDown40.Value = (decimal)LSDone.ElementAt(6);
            numericUpDown46.Value = (decimal)LSDone.ElementAt(7);
            numericUpDown52.Value = (decimal)LSDone.ElementAt(8);
            numericUpDown58.Value = (decimal)LSDone.ElementAt(9);
            numericUpDown64.Value = (decimal)LSDone.ElementAt(10);
            numericUpDown70.Value = (decimal)LSDone.ElementAt(11);
            numericUpDown76.Value = (decimal)LSDone.ElementAt(12);

            numericUpDown4.Value = (decimal)LNGone.ElementAt(0);
            numericUpDown9.Value = (decimal)LNGone.ElementAt(1);
            numericUpDown15.Value = (decimal)LNGone.ElementAt(2);
            numericUpDown21.Value = (decimal)LNGone.ElementAt(3);
            numericUpDown27.Value = (decimal)LNGone.ElementAt(4);
            numericUpDown33.Value = (decimal)LNGone.ElementAt(5);
            numericUpDown39.Value = (decimal)LNGone.ElementAt(6);
            numericUpDown45.Value = (decimal)LNGone.ElementAt(7);
            numericUpDown51.Value = (decimal)LNGone.ElementAt(8);
            numericUpDown57.Value = (decimal)LNGone.ElementAt(9);
            numericUpDown63.Value = (decimal)LNGone.ElementAt(10);
            numericUpDown69.Value = (decimal)LNGone.ElementAt(11);
            numericUpDown75.Value = (decimal)LNGone.ElementAt(12);

            numericUpDown5.Value = (decimal)BDone.ElementAt(0);
            numericUpDown8.Value = (decimal)BDone.ElementAt(1);
            numericUpDown14.Value = (decimal)BDone.ElementAt(2);
            numericUpDown20.Value = (decimal)BDone.ElementAt(3);
            numericUpDown26.Value = (decimal)BDone.ElementAt(4);
            numericUpDown32.Value = (decimal)BDone.ElementAt(5);
            numericUpDown38.Value = (decimal)BDone.ElementAt(6);
            numericUpDown44.Value = (decimal)BDone.ElementAt(7);
            numericUpDown50.Value = (decimal)BDone.ElementAt(8);
            numericUpDown56.Value = (decimal)BDone.ElementAt(9);
            numericUpDown62.Value = (decimal)BDone.ElementAt(10);
            numericUpDown68.Value = (decimal)BDone.ElementAt(11);
            numericUpDown74.Value = (decimal)BDone.ElementAt(12);

            numericUpDown6.Value = (decimal)FTone.ElementAt(0);
            numericUpDown7.Value = (decimal)FTone.ElementAt(1);
            numericUpDown13.Value = (decimal)FTone.ElementAt(2);
            numericUpDown19.Value = (decimal)FTone.ElementAt(3);
            numericUpDown25.Value = (decimal)FTone.ElementAt(4);
            numericUpDown31.Value = (decimal)FTone.ElementAt(5);
            numericUpDown37.Value = (decimal)FTone.ElementAt(6);
            numericUpDown43.Value = (decimal)FTone.ElementAt(7);
            numericUpDown49.Value = (decimal)FTone.ElementAt(8);
            numericUpDown55.Value = (decimal)FTone.ElementAt(9);
            numericUpDown61.Value = (decimal)FTone.ElementAt(10);
            numericUpDown67.Value = (decimal)FTone.ElementAt(11);
            numericUpDown73.Value = (decimal)FTone.ElementAt(12);
        }
        public string selectFuelType()
        {
            if (te.AuxiliaryEngineFuelType == 1)
            {
                return "Conventional Diesel";
            }
            else if (te.AuxiliaryEngineFuelType == 2)
            {
                return "Residual Oil";
            }
            else if (te.AuxiliaryEngineFuelType == 3)
            {
                return "Low Sulfur Diesel";
            }
            else if (te.AuxiliaryEngineFuelType == 4)
            {
                return "Natural Gas";
            }
            else if (te.AuxiliaryEngineFuelType == 5)
            {
                return "Biodiesel";
            }
            else if (te.AuxiliaryEngineFuelType == 6)
            {
                return "Fischer Tropsch Diesel";
            }
            else
                return " You must have broken it somewhere";
        }

        public void correctTextForInputs()
        {
            //Loading the correct text for the results sheet, based on the inputs
            label175.Text = selectFuelType();
            label61.Text = selectFuelType();
            label64.Text = selectFuelType();
            label86.Text = selectFuelType();
            label108.Text = selectFuelType();
            label130.Text = selectFuelType();
            label152.Text = selectFuelType();
            label54.Text = te.VesselTypeID;
            label67.Text = te.VesselTypeID;
            label89.Text = te.VesselTypeID;
            label154.Text = te.VesselTypeID;
            label111.Text = te.VesselTypeID;
            label133.Text = te.VesselTypeID;
            label154.Text = te.VesselTypeID;
            label155.Text = te.VesselTypeID;
        }
        //This is the sheet that will display all of the numeric results from the simulation, as opposed to the graphical ones which will be on another sheet that comes up at the same time
        private void ResultsSheet_Load(object sender, EventArgs e)
        {
            correctTextForInputs();
        }
    }
}
