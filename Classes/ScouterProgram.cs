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

            // var InterchangeData = Interchange.GetInterchangeDataRaw();
            var SummaryData = Summary.GetSummaryDataRaw();
            foreach (KeyValuePair<string, string> entity in SummaryData)
            {
                Console.WriteLine(entity);
            }
        }
    }
}
