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
        public ResultsSheet(TEAMS t)
        {
            te = t;
            InitializeComponent();
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
            label81.Text = selectFuelType();
            label86.Text = selectFuelType();
            label108.Text = selectFuelType();
            label130.Text = selectFuelType();
            label152.Text = selectFuelType();
            label54.Text = te.VesselTypeID;
            label84.Text = te.VesselTypeID;
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
