using System;
using System.Collections.Generic;
using System.Linq;
using Scouter.Structs;
using Scouter.Classes.ScrapeHandler;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
namespace Scouter.Classes.DataFormatters
{
    public class SummaryTable
    {
        public HtmlNode SummaryDataRaw { get; set; }
        public Dictionary<string, string> GetSummaryDataRaw()
        {
            Dictionary<string, string> SummaryOutput =
                new Dictionary<string, string>();
            var Descendents = SummaryDataRaw.Descendants("tr").ToList();
            Descendents.RemoveAt(0);
            for (var i = 0; i < Descendents.Count; i++)
            {
                SummaryOutput.Add(Descendents[i].FirstChild.InnerText, Descendents[i].LastChild.InnerText);
            }
            return SummaryOutput;
        }
    }
}
