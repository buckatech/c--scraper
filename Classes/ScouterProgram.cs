using System;
using Scouter.Classes.ScrapeHandler;
using Scouter.Classes.DataFormatters;
using System.Collections.Generic;
using HtmlAgilityPack;
namespace Primary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var InnerBodyHtml = new AesoDataFormatter();
            var DataFormatter = new SplitTargetToStruct();
            var Testdata = DataFormatter.SplitToCategories(InnerBodyHtml.TargetNodes());
            var Interchange = new InterchangeTable
            {
                InterchangeDataRaw = Testdata["InterchangeTable"]
            };
            var Summary = new SummaryTable
            {
                SummaryDataRaw = Testdata["Summary"]
            };
            var Hydro = new FuelTable
            {
                FuelDataRaw = Testdata["Hydro"]
            };
            var Coal = new FuelTable
            {
                FuelDataRaw = Testdata["Coal"]
            };
            var Wind = new FuelTable
            {
                FuelDataRaw = Testdata["Wind"]
            };
            var Biomass = new FuelTable
            {
                FuelDataRaw = Testdata["Biomass"]
            };

            // var InterchangeData = Interchange.GetInterchangeDataRaw();
            // var SummaryData = Summary.GetSummaryDataRaw();
            // var HydroData = Hydro.GetFuelDataRaw();
            // var coalData = Coal.GetFuelDataRaw();
            var windData = Wind.GetFuelDataRaw();
            foreach (KeyValuePair<string, List<string>> kvp in windData)
            {
                Console.WriteLine(kvp.Key);
                foreach (var i in kvp.Value)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
