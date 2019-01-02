using System;
using Scouter.Classes.MainData;
using Scouter.Classes.DataToSql;
using Scouter.Classes;
using Scouter.Classes.PublicEndpoint;
using System.Collections.Generic;
namespace Primary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serverHanler = new ServerHandler();
            long pk = serverHanler.InsertToMainServer();
            serverHanler.SelectFromServer(pk);
            var test = new DataToJson();
            test.OutputJson();
        }
    }
}
