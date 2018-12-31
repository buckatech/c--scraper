using Scouter.Classes.ScrapeHandler;
using Scouter.Classes.DataFormatters;
using System.Collections.Generic;
using HtmlAgilityPack;
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
            Dictionary<string, HtmlNode> Testdata = DataFormatter.SplitToCategories(InnerBodyHtml.TargetNodes());
            InterchangeTable Interchange = new InterchangeTable
            {
                InterchangeDataRaw = Testdata["InterchangeTable"]
            };
            SummaryTable Summary = new SummaryTable
            {
                SummaryDataRaw = Testdata["Summary"]
            };
            FuelTable Hydro = new FuelTable
            {
                FuelDataRaw = Testdata["Hydro"]
            };
            FuelTable Coal = new FuelTable
            {
                FuelDataRaw = Testdata["Coal"]
            };
            FuelTable Wind = new FuelTable
            {
                FuelDataRaw = Testdata["Wind"]
            };
            FuelTable Biomass = new FuelTable
            {
                FuelDataRaw = Testdata["Biomass"]
            };
            GasTable Gas = new GasTable
            {
                GasDataRaw = Testdata["Gas"]
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
