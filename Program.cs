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
        public static void UseParams(IEnumerable<HtmlNode> list, List<HtmlNode> item)
        {
            foreach (var i in list)
            {
                if (i.NodeType == HtmlNodeType.Element) 
                {
                    item.Add(i);
                }
            }
        }
        public static void Main(string[] args) 
        {
            ScrapeData EtsAeso = new ScrapeData();
            EtsAeso.TargetUrl = @"http://ets.aeso.ca/ets_web/ip/Market/Reports/CSDReportServlet";
            TempScrapeData TmpScrapeData = new TempScrapeData();
            UseParams(EtsAeso.BodyData(), TmpScrapeData.scrapeParts);
            TableData mainTable = new TableData();
            UseParams(TmpScrapeData.scrapeParts[1].Descendants("table"), mainTable.Tables);
            // Tables[3] Contains timestamp
            // Tables[5] Contains summary
            // Tables[6] Contains total table
            // Tables[10] Contains coal table
            // Tables[11] Contains gas table
            // Tables[13] Contains hydro table
            // Tables[14] Contains wind table
            // Tables[15] Contains biomass and other table
            UseParams(mainTable.Tables[15].Descendants("tr"), mainTable.DataTable);
            //dt[0] title
            //dt[1] css (bad)
            //dt [2]+ is data for each plant
            var bioTable = new FuelData();
            bioTable.FuelTitle = mainTable.DataTable[0].InnerText;
            mainTable.DataTable.RemoveRange(0, 2);
            var k = mainTable.DataTable;
            for (int j = 0; j < k.Count; j++)
            {
                if (k[j].NodeType == HtmlNodeType.Element)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                bioTable.DataList.Add(new McTngDcr{ Asset = k[j].ChildNodes[i].InnerHtml });
                                break;
                            case 1:
                                bioTable.DataList[j].Mc = k[j].ChildNodes[i].InnerHtml;
                                break;
                            case 2:
                                bioTable.DataList[j].Tng = k[j].ChildNodes[i].InnerHtml;                                
                                break;
                            case 3:
                                bioTable.DataList[j].Dcr = k[j].ChildNodes[i].InnerHtml;
                                break;  
                            default:
                                Console.WriteLine("ERR");
                                break;
                        }
                    }
                }          
            Console.WriteLine(bioTable.DataList[j].Asset);
            }
        }
    }
}