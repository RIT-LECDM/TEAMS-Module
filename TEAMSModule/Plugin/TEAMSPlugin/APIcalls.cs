using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlugInsInterfaces.DataTypes.Resource;
using PlugInsInterfaces.DataTypes;
using PlugInsInterfaces.DataTypes.Pathway;
using PlugInsInterfaces.DataTypes.Mix;
using PlugInsInterfaces.ResultTypes;
using PlugInsInterfaces.DataTypes.Technology;

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
        /// <param name="all_resources"></param>
        /// <param name="res_id"></param>
        /// <returns></returns>
        public IEnumerable<IResource> getSpecificResources(int res_id)
        {
            return getResources().AllValues.Where(item => item.Id == res_id);
        }

        public IEnumerable<IPathway> getSpecificPathways(int res_id)
        {
            return getPathways().AllValues.Where(item => item.MainOutputResourceID == res_id);
        }

        public string getFuelUsed(IPathway pathway)
        {
            return getResources().AllValues.Where(item => item.Id == pathway.MainOutputResourceID).ElementAt(0).Name;
        }

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

        public IResults getPathwayResults(IData data, IPathway pathway) { return pathway.GetUpstreamResults(data).ElementAt(0).Value; }

        public double getResourceDensity(IResource resource_used)
        {
            if (resource_used.Density.UserValue == 0)
            { return resource_used.Density.GreetValue; }
            else
            { return resource_used.Density.UserValue; }
        }

        public double getResourceSulfurRatio(IResource resource_used)
        {
            if (resource_used.SulfurRatio.UserValue == 0)
            { return resource_used.SulfurRatio.GreetValue; }
            else
            { return resource_used.SulfurRatio.UserValue; }
        }

        public double getResourceLowerHeatingValue(IResource resource_used)
        {
            if (resource_used.LowerHeatingValue.UserValue == 0)
            { return resource_used.LowerHeatingValue.GreetValue; }
            else
            { return resource_used.LowerHeatingValue.UserValue; }
        }

        public double getResourceCarbonRatio(IResource resource_used)
        {
            if (resource_used.CarbonRatio.UserValue == 0)
            { return resource_used.CarbonRatio.GreetValue; }
            else
            { return resource_used.CarbonRatio.UserValue; }
        }

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
                sum += pathway.LifeCycleResources().ElementAt(i).Value.Value;
            }
            return sum;
        }

        public double getResourceWTPEmissions(IResults pathway, int res_id)
        {
            return (pathway.LifeCycleEmissions().ElementAt(res_id).Value.Value * JOULES_PER_MMBTU * GRAMS_PER_KILOGRAM);
        }

    }
}
