using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Text.RegularExpressions;
using Scrapers;
namespace Primary
{
    public class Program {
        public static void Main(string[] args) 
        {
            var EtsAeso = new ScrapeData();
            EtsAeso.TargetUrl = @"http://ets.aeso.ca/ets_web/ip/Market/Reports/CSDReportServlet";
            var TmpScrapeData = new TempScrapeData();

            foreach (var bodyNode in EtsAeso.BodyData()) 
            {
                if (bodyNode.NodeType == HtmlNodeType.Element) 
                {
                    TmpScrapeData.scrapeParts.Add(bodyNode);
                }
            }
            //var testNode = scrapeParts[1].QuerySelector("tr tr");
            foreach (var nNode in TmpScrapeData.scrapeParts[1].Descendants("b"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        TmpScrapeData.titleList.Add(nNode.InnerText);
                    }
                }
            TableData mainTable = new TableData();
            foreach (var item in TmpScrapeData.titleList)
            {
                mainTable.Title.Add(item);
            }
            // body > table:nth-child(9) > tbody > tr > td:nth-child(1) > table > tbody > tr:nth-child(2) > td:nth-child(1)
            foreach (var nNode in TmpScrapeData.scrapeParts[1].Descendants("table"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        mainTable.Tables.Add(nNode);
                    }
                }
            // Tables[3] Contains timestamp
            // Tables[5] Contains summary
            // Tables[6] Contains total table
            // Tables[10] Contains coal table
            // Tables[11] Contains gas table
            // Tables[13] Contains hydro table
            // Tables[14] Contains wind table
            // Tables[15] Contains biomass and other table
            foreach (var i in mainTable.Tables[15].Descendants("tr"))
            {
                    if (i.NodeType == HtmlNodeType.Element)
                    {
                        mainTable.DataTable.Add(i);
                    }           
            }
            //dt[0] title
            //dt[1] css (bad)
            //dt [2]+ is data for each plant
            var bioTable = new FuelData();
            bioTable.FuelTitle = mainTable.DataTable[0].InnerText;
            Console.WriteLine(bioTable.FuelTitle);
            mainTable.DataTable.RemoveRange(0, 2);
            var mcList = new List<McTngDcr>();
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
                                mcList.Add(new McTngDcr{ Asset = k[j].ChildNodes[i].InnerHtml });
                                break;
                            case 1:
                                mcList[j].Mc = k[j].ChildNodes[i].InnerHtml;
                                break;
                            case 2:
                                mcList[j].Tng = k[j].ChildNodes[i].InnerHtml;                                
                                break;
                            case 3:
                                mcList[j].Dcr = k[j].ChildNodes[i].InnerHtml;
                                break;  
                            default:
                                Console.WriteLine("ERR");
                                break;
                        }
                    }
                }
            }
        }
    }
}