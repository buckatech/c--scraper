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
            var InterchangeData = Interchange.GetInterchangeDataRaw();
            foreach (KeyValuePair<string, string> entry in InterchangeData)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
