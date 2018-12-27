using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Text.RegularExpressions;
namespace MyApp
{
    public class TableData
    {
        public List<string> Title { get; set; }
        public List<HtmlNode> Tables { get; set; }
        public List<HtmlNode> DataTable { get; set; }
        public TableData()
        {
            Title = new List<string>();
            Tables = new List<HtmlNode>();
            DataTable = new List<HtmlNode>();
        }
    }
    public class FuelData
    {
        // Auto-implemented readonly property:
        public string FuelTitle { get; set; }
    }
    public class McTngDcr
    {
        public string Asset { get; set; }
        public string Mc { get; set; }
        public string Tng { get; set; }
        public string Dcr { get; set; }
    }
    public class Program {
        public static void Main(string[] args) 
        {
            // Url to get Html from
            var targetUrl = @"http://ets.aeso.ca/ets_web/ip/Market/Reports/CSDReportServlet";
            
            HtmlWeb web = new HtmlWeb();
            // Instantiate a new generic list
            List<HtmlNode> scrapeParts = new List<HtmlNode>();
            List<string> titleList = new List<string>();
            var htmlDoc = web.Load(targetUrl);
            // Get the Body and all decendents from targetUrl
            var bodysOfScrapeBody = htmlDoc.DocumentNode.QuerySelectorAll("body");
            /* Add each body into scrapeParts
                scrapeParts[0] Contains Scripts/Headers
                scrapeParts[1] Contains the main data body
            */
            foreach (var bodyNode in bodysOfScrapeBody) 
            {
                if (bodyNode.NodeType == HtmlNodeType.Element) 
                {
                    scrapeParts.Add(bodyNode);
                }
            }
            //var testNode = scrapeParts[1].QuerySelector("tr tr");
            foreach (var nNode in scrapeParts[1].Descendants("b"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        titleList.Add(nNode.InnerText);
                    }
                }
            TableData mainTable = new TableData();
            foreach (var item in titleList)
            {
                mainTable.Title.Add(item);
            }
            // body > table:nth-child(9) > tbody > tr > td:nth-child(1) > table > tbody > tr:nth-child(2) > td:nth-child(1)
            foreach (var nNode in scrapeParts[1].Descendants("table"))
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
            mainTable.DataTable.RemoveRange(0, 2);
            var mcList = new List<McTngDcr>();
            var k = mainTable.DataTable;
            for (int j = 0; j < k.Count; j++)
            {
                if (k[j].NodeType == HtmlNodeType.Element)
                {
                    // foreach (var item in j.ChildNodes)
                    // {
                    //     Console.WriteLine(item.InnerText);
                    // }
                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:

                                Console.WriteLine(k[j].ChildNodes[i].InnerHtml + "case1");
                                break;
                            case 1:
                                Console.WriteLine(k[j].ChildNodes[i].InnerHtml + "case2");
                                break;
                            case 2:
                                Console.WriteLine(k[j].ChildNodes[i].InnerHtml + "case3");
                                break;
                            case 3:
                                Console.WriteLine(k[j].ChildNodes[i].InnerHtml + "case4");
                                break;  
                            default:
                                Console.WriteLine("ERR");
                                break;
                        }
                    }
                }
            }
            Console.WriteLine(mcList[0].Asset);
        }
    }
}