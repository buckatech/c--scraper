using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Text.RegularExpressions;
namespace MyApp
{
    public class Program {
        public static void Main(string[] args) {
            // Url to get Html from
            var targetUrl = @"http://ets.aeso.ca/ets_web/ip/Market/Reports/CSDReportServlet";
            
            HtmlWeb web = new HtmlWeb();
            // Instantiate a new generic list
            List<HtmlNode> scrapeParts = new List<HtmlNode>();
            
            var htmlDoc = web.Load(targetUrl);
            // Get the Body and all decendents from targetUrl
            var bodysOfScrapeBody = htmlDoc.DocumentNode.QuerySelectorAll("body");
            /* Add each body into scrapeParts
                scrapeParts[0] Contains Scripts/Headers
                scrapeParts[1] Contains the main data body
            */
            foreach (var bodyNode in bodysOfScrapeBody) {
                if (bodyNode.NodeType == HtmlNodeType.Element) {
                    scrapeParts.Add(bodyNode);
                }
            }
            //var testNode = scrapeParts[1].QuerySelector("tr tr");
            foreach (var nNode in scrapeParts[1].Descendants())
                {
                    if (nNode.NodeType == HtmlNodeType.Element)
                    {
                        Console.WriteLine(nNode.InnerHtml);
                    }
                }
        }
    }
}