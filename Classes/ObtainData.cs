using System.Collections.Generic;
using HtmlAgilityPack;
using Scouter.Classes.DataFormatters;
using Scouter.Classes.ScrapeHandler;
namespace Scouter.Classes.MainData
{
    public class GetData
    {
        private AesoDataFormatter InnerBodyHtml = new AesoDataFormatter();
        private SplitTargetToStruct DataFormatter = new SplitTargetToStruct();
        public Dictionary<string, string> InterchangeData;
        public Dictionary<string, string> SummaryData;
        public Dictionary<string, List<string>> HydroData;
        public Dictionary<string, List<string>> CoalData;
        public Dictionary<string, List<string>> WindData;
        public Dictionary<string, List<string>> BiomassData;
        public List<Dictionary<string, List<string>>> GasData;
        public GetData()
        {
            Dictionary<string, HtmlNode> TableData = DataFormatter.SplitToCategories(InnerBodyHtml.TargetNodes());
            InterchangeTable Interchange = new InterchangeTable
            {
                InterchangeDataRaw = TableData["InterchangeTable"]
            };
            SummaryTable Summary = new SummaryTable
            {
                SummaryDataRaw = TableData["Summary"]
            };
            FuelTable Hydro = new FuelTable
            {
                FuelDataRaw = TableData["Hydro"]
            };
            FuelTable Coal = new FuelTable
            {
                FuelDataRaw = TableData["Coal"]
            };
            FuelTable Wind = new FuelTable
            {
                FuelDataRaw = TableData["Wind"]
            };
            FuelTable Biomass = new FuelTable
            {
                FuelDataRaw = TableData["Biomass"]
            };
            GasTable Gas = new GasTable
            {
                GasDataRaw = TableData["Gas"]
            };
            InterchangeData = Interchange.GetInterchangeDataRaw();
            SummaryData = Summary.GetSummaryDataRaw();
            CoalData = Coal.GetFuelDataRaw();
            HydroData = Hydro.GetFuelDataRaw();
            WindData = Wind.GetFuelDataRaw();
            BiomassData = Biomass.GetFuelDataRaw();
            GasData = Gas.GetRawGasData();
        }
    }
}
