using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greet.DataStructureV3.Interfaces;
using Greet.Model.Interfaces;
namespace TEAMS_Plugin
{
    public class APIcalls
    {
        #region Constants

        // Conventional Diesel Path ID - Used for estimation of fuel gallons for input, does not appear on the results sheet.
        private const int CD_PATH_ID = 40;
        // Gallons per 1 m^3
        private const double GALLONS_PER_CUBIC_METER = 264.172;
        // Joules per 1 Btu
        private const double JOULES_PER_BTU = 1055.05585;
        // Joules per 1 MMBTU
        private const double JOULES_PER_MMBTU           =   1055870000.0;
        // Grams per 1 Kilogram
        private const double GRAMS_PER_KILOGRAM         =   1000.0;
        // Kilowatt-hours per 1 Horsepower-hour
        private const double KWHRS_PER_HPHR             =   0.745699871;
        // Grams Sulfur Oxide to Grams Sulfur Ratio
        private const double GRAMS_SOX_PER_GRAMS_S      =   64 / 32;

        #endregion

        public APIcalls() { }

        /// <summary>
        /// This function is pulling the BTUPerGal for Conventional Diesel so it can be used to calculate the gallons per trip. (This is ultimately recalculated in the Results code)
        /// </summary>
        /// <returns> The total BTUs per Gallon of conventional diesel </returns>
        public double getApproxBTUperGAL()
        {
            IGDataDictionary<int, IResource> resources = ResultsAccess.controler.CurrentProject.Data.Resources;
            IGDataDictionary<int, IPathway> pathways = ResultsAccess.controler.CurrentProject.Data.Pathways;
            IGDataDictionary<int, IMix> mixes = ResultsAccess.controler.CurrentProject.Data.Mixes;
            IPathway myPathway = pathways.ValueForKey(CD_PATH_ID);
            int productID = myPathway.MainOutputResourceID;
            productID = myPathway.MainOutputResourceID;
            IResource ConvDiesel = resources.ValueForKey(productID);

            if (ConvDiesel.LowerHeatingValue.UserValue == 0)
            { return (ConvDiesel.LowerHeatingValue.GreetValue) * (1 / GALLONS_PER_CUBIC_METER) * (1 / JOULES_PER_BTU); }
            else
            { return (ConvDiesel.LowerHeatingValue.UserValue) * (1 / GALLONS_PER_CUBIC_METER) * (1 / JOULES_PER_BTU); }
        }

        public IGDataDictionary<int, IResource> getResources() { return ResultsAccess.controler.CurrentProject.Data.Resources; }

        /// <summary>
        /// Gets all of the Pathways available from GREET
        /// </summary>
        /// <returns>IGDataDictionary containing all of the pathways in GREET</returns>
        public IGDataDictionary<int, IPathway> getPathways() { return ResultsAccess.controler.CurrentProject.Data.Pathways; }

        /// <summary>
        /// Gets all of the Mixes available from GREET
        /// </summary>
        /// <returns>IGDataDictionary containing all of the Mixes in GREET</returns>
        public IGDataDictionary<int, IMix> getMixes() { return ResultsAccess.controler.CurrentProject.Data.Mixes; }

        /// <summary>
        /// Gets the entire GREET project's database
        /// </summary>
        /// <returns>The GREET project's database</returns>
        public IData getData() { return ResultsAccess.controler.CurrentProject.Data; }

        /// <summary>
        /// Pulls the main product resource from using a specific pathway
        /// </summary>
        /// <param name="path">The specific pathway you are getting the resource for</param>
        /// <returns>The product of the pathway it was passed</returns>
        public IResource getResourceUsed(IPathway path) { return ResultsAccess.controler.CurrentProject.Data.Resources.ValueForKey(path.MainOutputResourceID); }

        /// <summary>
        /// Grabs all of the specific types of resources from all resources in GREET that match the main resource ID it is passed
        /// </summary>
        /// <param name="res_id">The Id of the resource for which you want the specifics</param>
        /// <returns>An enumerable collection of the specific IResources</returns>
        public IEnumerable<IResource> getSpecificResources(int res_id)
        {
            return getResources().AllValues.Where(item => item.Id == res_id);
        }

        /// <summary>
        /// Grabs all of the specific pathways that have a specific resource as their product
        /// </summary>
        /// <param name="res_id">The Id of the resource for which you want the specific pathways</param>
        /// <returns>An enumerable collection ofthe specific IPathways</returns>
        public IEnumerable<IPathway> getSpecificPathways(int res_id)
        {
            return getPathways().AllValues.Where(item => item.MainOutputResourceID == res_id);
        }

        /// <summary>
        /// Gets the main, general fuel used after a specific pathway is selected. i.e. "Conventional Diesel"
        /// </summary>
        /// <param name="pathway">The specific pathway selected</param>
        /// <returns>A strong of the general fuel used</returns>
        public string getFuelUsed(IPathway pathway)
        {
            return getResources().AllValues.Where(item => item.Id == pathway.MainOutputResourceID).ElementAt(0).Name;
        }

        /// <summary>
        /// Gets preliminary gallons per mmbtu of a resource 
        /// </summary>
        /// <param name="resource_used">The resource being used</param>
        /// <returns>A double representing the gallons per 1 mmbtu of energy</returns>
        public double getGallonsPerMMBTU(IResource resource_used)
        {
            double api_value;
            double conversions = GALLONS_PER_CUBIC_METER * JOULES_PER_MMBTU;

            if (resource_used.LowerHeatingValue.UserValue == 0)
            { api_value = resource_used.LowerHeatingValue.GreetValue; }
            else
            { api_value = resource_used.LowerHeatingValue.UserValue; }

            return ( (1 / api_value) * conversions );
        }

        /// <summary>
        /// Gets the IResults of a specified pathway from a specified data set.
        /// </summary>
        /// <param name="data">A specific data set</param>
        /// <param name="pathway">The pathway to grab results from</param>
        /// <returns>IResults from the specified pathway</returns>
        public IResults getPathwayResults(IData data, IPathway pathway) { return pathway.GetUpstreamResults(data).ElementAt(0).Value; }

        /// <summary>
        /// Grabs the fuel density of the specified resource
        /// </summary>
        /// <param name="resource_used">The specified resource</param>
        /// <returns>A double indicating the density of the resource</returns>
        public double getResourceDensity(IResource resource_used)
        {
            if (resource_used.Density.UserValue == 0)
            { return resource_used.Density.GreetValue; }
            else
            { return resource_used.Density.UserValue; }
        }

        /// <summary>
        /// Grabs the sulfur ratio of the specified resource
        /// </summary>
        /// <param name="resource_used">The specified resource</param>
        /// <returns>A double indicating the sulfur ratio of the resource</returns>
        public double getResourceSulfurRatio(IResource resource_used)
        {
            if (resource_used.SulfurRatio.UserValue == 0)
            { return resource_used.SulfurRatio.GreetValue; }
            else
            { return resource_used.SulfurRatio.UserValue; }
        }

        /// <summary>
        /// Grabs the lower heating value of the specified resource
        /// </summary>
        /// <param name="resource_used">The specified resource</param>
        /// <returns>A double indicating the lower heating value of the resource</returns>
        public double getResourceLowerHeatingValue(IResource resource_used)
        {
            if (resource_used.LowerHeatingValue.UserValue == 0)
            { return resource_used.LowerHeatingValue.GreetValue; }
            else
            { return resource_used.LowerHeatingValue.UserValue; }
        }

        /// <summary>
        /// Grabs the carbon ratio of the specified resource
        /// </summary>
        /// <param name="resource_used">The specified resource</param>
        /// <returns>A double indicating the carbon ratio of the resource</returns>
        public double getResourceCarbonRatio(IResource resource_used)
        {
            if (resource_used.CarbonRatio.UserValue == 0)
            { return resource_used.CarbonRatio.GreetValue; }
            else
            { return resource_used.CarbonRatio.UserValue; }
        }

        /// <summary>
        /// Sums the total mmbtu amounts of all upstream resources from a specified pathway
        /// </summary>
        /// <param name="pathway">The specified pathway</param>
        /// <returns>A double indicating the sum of all of the emissions.</returns>
        public double getSumAllLifeCycleResources(IResults pathway)
        {

            // 13 - Nuclear Energy
            // 12 - SKIPPED!!
            // 11 - Renewable (Solar, Hydro, Wind, Geothermal
            // 10 - Wind Power
            //  9 - Geothermal                
            //  8 - Hydroelectric                
            //  7 - Solar
            //  6 - Forest Residue
            //  5 - Farmed Trees or Switchgrass -- unconfirmed which is which
            //  4 - Farmed Trees or Switchgrass -- unconfirmed which is which
            //  3 - Coal Average
            //  2 - Bituminous Oil
            //  1 - Crude Oil
            //  0 - Natural Gas

            double sum = 0;
            for (int i = 0; i <= 13; i++ )
            {
                if (i == 12) { continue; }
               sum += pathway.WellToProductResources().ElementAt(i).Value.Value;
            }
            return sum;
        }

        /// <summary>
        /// Grabs the entire WTP emissions total of a resource in a pathway per 1 mmbtu
        /// </summary>
        /// <param name="pathway">The specified pathway</param>
        /// <param name="res_id">The specified resource ID</param>
        /// <returns>A double with units g/mmbtu</returns>
        public double getResourceWTPEmissions(IResults pathway, int res_id)
        {
            return (pathway.WellToProductEmissions().ElementAt(res_id).Value.Value * JOULES_PER_MMBTU * GRAMS_PER_KILOGRAM);
        }

    }
}
