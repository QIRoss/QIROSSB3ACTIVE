using System;
using System.Threading.Tasks;
using System.Net.Mail;

class Mail{
    public void CreateTestMessage2(){
        string to = "lucasqreis@poli.ufrj.br";
        string from = "lucasqreis@poli.ufrj.br";
        MailMessage message = new MailMessage(from, to);
        message.Subject = "Using the new SMTP client.";
        message.Body = @"Using this new feature, you can send an email message from an application very easily.";
        SmtpClient client = new SmtpClient("smtp.sendgrid.net",587);
        client.Credentials = new System.Net.NetworkCredential("apikey","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");
        try{
            client.Send(message);
        }
        catch (Exception ex){
            Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                ex.ToString());
        }
    }    
}