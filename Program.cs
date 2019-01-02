using System;
using Scouter.Classes.MainData;
using Scouter.Classes.DataToSql;
using Scouter.Classes;
using System.Collections.Generic;
namespace Primary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serverHanler = new ServerHandler();
            serverHanler.InsertToMainServer();
        }
    }
}
