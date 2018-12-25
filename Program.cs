using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System;

namespace TestHAP
{
class Program
{
    static void Main(string[] args)
    {
        string Url = "http://ets.aeso.ca/ets_web/ip/Market/Reports/CSDReportServlet";
        var web = new HtmlWeb();
        var document = web.Load(Url);
        var c = document.DocumentNode.SelectSingleNode("//td[contains(text(),'Alberta Total Net Generation')]");
        HtmlNode sibling = c.NextSibling;
        // body > table:nth-child(9) > tbody > tr > td:nth-child(1) > table > tbody > tr:nth-child(1) > th > center > b
        if(c != null)
        {
            Console.WriteLine(sibling.InnerHtml);
        }
    }
}
}