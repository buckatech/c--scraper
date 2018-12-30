using System;
using Scouter.Classes.ScrapeHandler;
using HtmlAgilityPack;
namespace Primary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var test = new AesoDataFormatter();
            Console.WriteLine(test.TargetNodes()[3].InnerHtml);
        }
    }
}
