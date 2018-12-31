using System;
using Scouter.Classes.DataFormatters;
using System.Collections.Generic;
using System.Linq;
using Scouter.Structs;
using Scouter.Classes.ScrapeHandler;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
namespace Scouter.Classes.DataFormatters
{
    public class GasTable: FuelTable
    {
        public HtmlNode GasDataRaw { get; set; }
        public List<Dictionary<string, List<string>>> GetRawGasData()
        {
            var innerGas = GasDataRaw.Descendants("tr").ToList();
            Dictionary<string, List<string>> SimpleOutput =
                new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> CogenerationOutput =
                new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> CombinedOutput =
                new Dictionary<string, List<string>>();
            List<Dictionary<string, List<string>>> GasOutput =
                new List<Dictionary<string, List<string>>>();
            var status = 0;
            for (var i = 0; i < innerGas.Count; i++)
            {
                if 
                (
                    innerGas[i].InnerText == "Simple Cycle" || 
                    innerGas[i].InnerText == "Cogeneration" || 
                    innerGas[i].InnerText == "Combined Cycle"
                )
                {
                    i += 2;
                    status++;
                }
                switch (status)
                {

                    case 1:
                        List<HtmlNode> current = innerGas[i].Descendants("td").ToList();
                        List<string> tempList = new List<string>
                        {
                            current[1].InnerText,
                            current[2].InnerText,
                            current[3].InnerText
                        };
                        SimpleOutput.Add(current[0].InnerText, tempList);
                        break;
                    case 2:
                        List<HtmlNode> current1 = innerGas[i].Descendants("td").ToList();
                        List<string> tempList1 = new List<string>
                        {
                            current1[1].InnerText,
                            current1[2].InnerText,
                            current1[3].InnerText
                        };
                        CogenerationOutput.Add(current1[0].InnerText, tempList1);
                        break;
                    case 3:
                        List<HtmlNode> current2 = innerGas[i].Descendants("td").ToList();
                        List<string> tempList2 = new List<string>
                        {
                            current2[1].InnerText,
                            current2[2].InnerText,
                            current2[3].InnerText
                        };
                        CombinedOutput.Add(current2[0].InnerText, tempList2);
                        break;
                }
            }
            GasOutput.Add(SimpleOutput);
            GasOutput.Add(CogenerationOutput);
            GasOutput.Add(CombinedOutput);
            return GasOutput;
        }
    }
}
