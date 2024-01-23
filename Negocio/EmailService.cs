using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient Server;

        public EmailService()
        {
            Server = new SmtpClient();
            Server.Credentials = new NetworkCredential("hernanprograma12@gmail.com", "lumz wzxa moge qjbi");
            Server.EnableSsl = true;
            Server.Port = 25;
            Server.Host = "smtp.mailtrap.io";
        }

        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@CompraClick.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;

        }

        public void EnviarEmail()
        {
            try
            {
                Server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
