using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
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
            int iterLimit = Descendents.Count;
            for (var i = 0; i < iterLimit; i++)
            {
                SummaryOutput.Add(Descendents[i].FirstChild.InnerText, Descendents[i].LastChild.InnerText);
            }
            return SummaryOutput;
        }
    }
}
