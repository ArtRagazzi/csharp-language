using System.Net;
using System.Net.Mail;

namespace Blog.Services;

public class EmailService{

    public bool Send(
        string toName,
        string toEmail,
        string subject,
        string body,
        string fromName = "Equipe da TIzinha",
        string fromEmail = "email@arturdocsharp.com"
        ){
        
        var smtpClient = new SmtpClient(Configuration.Smtp.Host, Configuration.Smtp.Port);
        smtpClient.Credentials = new NetworkCredential(Configuration.Smtp.Username, Configuration.Smtp.Password);
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;

        var email = new MailMessage();
        email.From = new MailAddress(fromEmail, fromName);
        email.To.Add(new MailAddress(toEmail,toName));
        email.Subject = subject;
        email.Body = body;
        email.IsBodyHtml = true;


        try{
            smtpClient.Send(email);
            return true;
        }
        catch (Exception e){
            Console.WriteLine(e);
            return false;
        }
    }
}