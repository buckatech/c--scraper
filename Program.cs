using System;
using Scouter.Classes.MainData;
namespace Primary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Data = new GetData();
            Console.WriteLine(Data.CoalData);
        }
    }
}
