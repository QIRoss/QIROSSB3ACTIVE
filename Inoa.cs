using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIRoss{
    class Program{
        static int Main(string[] args){
            if (args.Length != 3){
                Console.WriteLine(
                    "Use: ./Program <Active stock to monitor> <Price to sell (xx.xx)> <Price to buy (xx.xx)>"
                    );
                return 1;
            }
            var request = WebRequest.CreateHttp(
                "http://jsonplaceholder.typicode.com/posts/1"
                );         
            request.Method = "GET";
            request.UserAgent = "QIRoss";
            using (var resposta = request.GetResponse()){
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                Console.WriteLine(objResponse.ToString());
                streamDados.Close();
                resposta.Close();
            }
            return 0;
        }
    }    
}