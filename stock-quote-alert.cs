using System;
using System.Net;
using System.IO;

namespace QIRoss{
    class Program{
        static int Main(string[] args){
            if (args.Length != 3){
                Console.WriteLine(
                    "Use: ./Program <Active stock to monitor> <Price to sell (xx.xx)> <Price to buy (xx.xx)>"
                    );
                return 1;
            }
            string url = "https://api.hgbrasil.com/finance/stock_price?key=818e18b0&symbol=";
            HttpWebRequest request = WebRequest.CreateHttp(
                String.Concat(url,args[0])
                );
            using (var response = request.GetResponse()){
                var streamDados = response.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                string toWrite = objResponse.ToString();
                string[] subs = toWrite.Split(',');
                for(int index=0;index<subs.Length;index++){
                    Console.WriteLine(subs[index]);
                }
                streamDados.Close();
                response.Close();
            }
            return 0;
        }
    }    
}