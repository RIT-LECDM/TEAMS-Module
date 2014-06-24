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
        public IGDataDictionary<int, IPathway> getPathways() { return ResultsAccess.controler.CurrentProject.Data.Pathways; }
        public IGDataDictionary<int, IMix> getMixes() { return ResultsAccess.controler.CurrentProject.Data.Mixes; }

        public IEnumerable<IResource> getSpecificResources(IGDataDictionary<int, IResource> all_resources, int res_id)
        {
            return all_resources.AllValues.Where(item => item.Id == res_id);
        }

        public IEnumerable<IPathway> getSpecificPathways(IGDataDictionary<int, IPathway> all_pathways, int res_id)
        {
            return all_pathways.AllValues.Where(item => item.MainOutputResourceID == res_id);
        }
    }
}
