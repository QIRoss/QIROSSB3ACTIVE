using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;

class Mail{
    public void SendMail(){
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587){
            Credentials = new NetworkCredential("lucasqreis@poli.ufrj.br", "KeyRox_722!"),
            EnableSsl = true
        };
        client.Send("lucasqreis@poli.ufrj.br", "lucasqreis@gmail.com", "String?", "Test again");
    }    
}