using System;
using System.Net;
using System.IO;
class Api{
    private string url = "https://api.hgbrasil.com/finance/stock_price?key=818e18b0&symbol=";
    private float toBuy;
    private float toSell;
    private Api(string active,float toBuy, float toSell){
        url = String.Concat(url,active);
    }
    public getPrice(){

    }
}