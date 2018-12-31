using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
namespace Scouter.Classes.DataFormatters
{
    public class FuelTable
    {
        public HtmlNode FuelDataRaw { get; set; }
        public Dictionary<string, List<string>> GetFuelDataRaw()
        {
            Dictionary<string, List<string>> FuelOutput =
                new Dictionary<string, List<string>>();
            var Descend = FuelDataRaw.Descendants("tr").ToList();
            Descend.RemoveRange(0, 2);
            int iterLimit = Descend.Count;
            for (var i = 0; i <  iterLimit; i++)
            {
                List<HtmlNode> current = Descend[i].Descendants("td").ToList();
                List<string> tempList = new List<string>
                {
                    current[1].InnerText,
                    current[2].InnerText,
                    current[3].InnerText
                };
                FuelOutput.Add(current[0].InnerText, tempList);
            }
            return FuelOutput;
        }
    }
}
