using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;
using Scouter.Classes.ScrapeHandler;
using Fizzler.Systems.HtmlAgilityPack;

namespace Scouter.Classes.ScrapeHandler
{
    public class AesoDataFormatter
    {   
        public HtmlNode InnerHtmlBody;
        public List<HtmlNode> inputList = new AesoServerHandler().ScrapedHtml;
        // Constructs Dataformatter with the body containing the relevent data
        public AesoDataFormatter()
        {
            InnerHtmlBody = inputList[1];
        }
        // Seperate each table into a list
        public List<HtmlNode> TargetNodes()
        {
            return InnerHtmlBody.Descendants("table").ToList();
        }
    }
}
//namespace Scrapers
//{
//    public static class ScrapeHelper
//    {
//        public static void IterAndAddNode(IEnumerable<HtmlNode> list, List<HtmlNode> item)
//        {
//            foreach (var i in list)
//            {
//                if (i.NodeType == HtmlNodeType.Element)
//                {
//                    item.Add(i);
//                }
//            }
//        }
//        public static void LoopToFinal(List<HtmlNode> sourceList, List<McTngDcr> outputList)
//        {
//            for (int j = 0; j < sourceList.Count; j++)
//            {
//                if (sourceList[j].NodeType == HtmlNodeType.Element)
//                {
//                    for (int i = 0; i < 4; i++)
//                    {
//                        switch (i)
//                        {
//                            case 0:
//                                outputList.Add(new McTngDcr { Asset = sourceList[j].ChildNodes[i].InnerHtml });
//                                break;
//                            case 1:
//                                outputList[j].Mc = sourceList[j].ChildNodes[i].InnerHtml;
//                                break;
//                            case 2:
//                                outputList[j].Tng = sourceList[j].ChildNodes[i].InnerHtml;
//                                break;
//                            case 3:
//                                outputList[j].Dcr = sourceList[j].ChildNodes[i].InnerHtml;
//                                break;
//                            default:
//                                Console.WriteLine("ERR");
//                                break;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}


