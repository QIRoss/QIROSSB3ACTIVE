using System;
using System.Net;
using System.IO;
using System.Configuration;

namespace QIRoss{
    class Program{
        static int Main(string[] arg){
            if (arg.Length != 3){
                Console.WriteLine(
                    "Use: ./Program <Active stock to monitor> <Price to sell (xx.xx)> <Price to buy (xx.xx)>"
                    );
                return 1;
            }
            Api connection = new Api(arg[0],float.Parse(arg[1]),float.Parse(arg[2]));
            connection.getPrice();
            Mail test = new Mail();
            test.SendMail();
            return 0;
        }
    }    
}