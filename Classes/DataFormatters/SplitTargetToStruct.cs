using System;
using System.Collections.Generic;
using Scouter.Classes.ScrapeHandler;
using HtmlAgilityPack;
namespace Scouter.Classes.DataFormatters
{
    public class SplitTargetToStruct
    {
        public List<HtmlNode> test = new AesoDataFormatter().TargetNodes();

        public Dictionary<string, HtmlNode> SplitToCategories(List<HtmlNode> targHtml)
        {
            Dictionary<string, HtmlNode> nodeDictionary =
                new Dictionary<string, HtmlNode>();
            for (var i = 0; i < targHtml.Count; i++)
            {
                switch (i)
                {
                    case 7:
                        nodeDictionary.Add("InterchangeTable", targHtml[i]);
                        break;
                    default:
                        Console.WriteLine(i);
                        break;
                }
            }
            return nodeDictionary;
        }
    }
}
