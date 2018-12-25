using HtmlAgilityPack;
using System;

namespace TestHAP
{
class Program
{
    static void Main(string[] args)
    {
        string Url = "http://ets.aeso.ca/ets_web/ip/Market/Reports/CSDReportServlet";

        HtmlWeb web = new HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc = web.Load(Url);
    // /html/body/table[4]/tbody/tr/td[1]/table/tbody/tr[1]/th/center/b
        var SpanNodes = doc.DocumentNode.SelectNodes("//table");
        // if (SpanNodes != null)
        //     {
        //         Console.WriteLine(SpanNodes.InnerText);
        //     }
        foreach (var node in SpanNodes)
            {
                if (node.NodeType == HtmlNodeType.Element)
                {
                    Console.WriteLine(node.InnerText);
                }
            }
    }
}
}