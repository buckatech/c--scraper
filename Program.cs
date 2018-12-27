using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Text.RegularExpressions;
using Scrapers;
namespace Primary
{
    public class Program 
    {
        public static void IterAndAddNode(IEnumerable<HtmlNode> list, List<HtmlNode> item)
        {
            foreach (var i in list)
            {
                if (i.NodeType == HtmlNodeType.Element) 
                {
                    item.Add(i);
                }
            }
        }
        public static void LoopToFinal(List<HtmlNode> sourceList, List<McTngDcr> outputList)
        {
            for (int j = 0; j < sourceList.Count; j++)
            {
                if(sourceList[j].NodeType == HtmlNodeType.Element)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                outputList.Add(new McTngDcr{ Asset = sourceList[j].ChildNodes[i].InnerHtml });
                                break;
                            case 1:
                                outputList[j].Mc = sourceList[j].ChildNodes[i].InnerHtml;
                                break;
                            case 2:
                                outputList[j].Tng = sourceList[j].ChildNodes[i].InnerHtml;                                
                                break;
                            case 3:
                                outputList[j].Dcr = sourceList[j].ChildNodes[i].InnerHtml;
                                break;  
                            default:
                                Console.WriteLine("ERR");
                                break;
                        }
                    }
                }
                Console.WriteLine(outputList[j].Asset);
            }
        }
        public static void Main(string[] args) 
        {
            ScrapeData EtsAeso = new ScrapeData();
            TempScrapeData TmpScrapeData = new TempScrapeData();
            TableData mainTable = new TableData();
            FuelData bioTable = new FuelData();

            EtsAeso.TargetUrl = @"http://ets.aeso.ca/ets_web/ip/Market/Reports/CSDReportServlet";
            IterAndAddNode(EtsAeso.BodyData(), TmpScrapeData.scrapeParts);
            IterAndAddNode(TmpScrapeData.scrapeParts[1].Descendants("table"), mainTable.Tables);
            // Tables[3] Contains timestamp
            // Tables[5] Contains summary
            // Tables[6] Contains total table
            // Tables[10] Contains coal table
            // Tables[11] Contains gas table
            // Tables[13] Contains hydro table
            // Tables[14] Contains wind table
            // Tables[15] Contains biomass and other table
            IterAndAddNode(mainTable.Tables[15].Descendants("tr"), mainTable.BiomassTable);
            Console.WriteLine(mainTable.BiomassTable.Count);
            // BIOTABLE
            //dt[0] title
            //dt[1] css (bad)
            //dt [2]+ is data for each plant
            bioTable.FuelTitle = mainTable.BiomassTable[0].InnerText;
            mainTable.BiomassTable.RemoveRange(0, 2);
            LoopToFinal(mainTable.BiomassTable, bioTable.DataList);
        }
    }
}