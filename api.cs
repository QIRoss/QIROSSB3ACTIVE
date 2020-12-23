using System;
using System.Net;
using System.IO;
using System.Configuration;

class Api{
    private string active;
    private string url = "https://api.hgbrasil.com/finance/stock_price?key=818e18b0&symbol=";
    private float toBuy;
    private float toSell;

    public Api(string act,float buy, float sell){
        url = String.Concat(url,active);
        this.active = act;
        this.toBuy = buy;
        this.toSell = sell;
    }

    public bool getPrice(){
        HttpWebRequest request = WebRequest.CreateHttp(this.url);
        using (var response = request.GetResponse()){
            var streamDados = response.GetResponseStream();
            StreamReader reader = new StreamReader(streamDados);
            object objResponse = reader.ReadToEnd();
            Console.WriteLine(objResponse.ToString());
            string[] parts = objResponse.ToString().Split(',');
            for(int index=0;index<parts.Length;index++){
                string[] temp = parts[index].Split(':');
                if(String.Compare("\"price\"",temp[0])==0){
                    Console.WriteLine("Price: "+temp[1]);
                    float price = float.Parse(temp[1]);
                    if(price < toBuy){
                        this.sendMail(false,temp[1]);
                    } else if(price > toSell){
                        this.sendMail(true,temp[1]);
                    }
                }
            }
            streamDados.Close();
            response.Close();
            return true;
        }
    }

    private void sendMail(bool buyOrSell, string price){
        string message = "Automatic message.\n";
        if(!buyOrSell){
            message += "Buy ";
        } else {
            message += "Sell ";
        }
        message += active + " active at price " + price + ".\n";
        Console.WriteLine(message,"a");
    }
}