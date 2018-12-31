using System;
using System.Collections.Generic;
using System.Linq;
using Scouter.Structs;
using Scouter.Classes.ScrapeHandler;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
namespace Scouter.Classes.DataFormatters
{
    public class InterchangeTable
    {
        public HtmlNode InterchangeDataRaw { get; set; }
        public Dictionary<string, string> GetInterchangeDataRaw()
        {
            Dictionary<string, string> InterChangeOutput =
                new Dictionary<string, string>();
            var Descendents = InterchangeDataRaw.Descendants("tr").ToList();
            Descendents.RemoveRange(0, 2);
            int IterLimit = Descendents.Count;
            for (var i = 0; i < IterLimit; i++)
            {
                InterChangeOutput.Add(Descendents[i].FirstChild.InnerText, Descendents[i].LastChild.InnerText);
            }
            return InterChangeOutput;
        }
    }
}
