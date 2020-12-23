using System;
using System.Net;
using System.IO;

namespace QIRoss{
    class Program{
        static int Main(string[] arg){
            if (arg.Length != 3){
                Console.WriteLine(
                    "Use: ./Program <Active stock to monitor> <Price to sell (xx.xx)> <Price to buy (xx.xx)>"
                    );
                return 1;
            }
            if(arg[1][arg[1].Length-3]!='.' || arg[2][arg[2].Length-3]!='.'){
                Console.WriteLine("Error: Active price format: <xx.xx>");
                return 2;
            }
            Api connection = new Api(arg[0],float.Parse(arg[1]),float.Parse(arg[2]));
            if(!connection.getPrice()){
                Console.WriteLine("Error: something went wrong.");
            }
            return 0;
        }
    }    
}