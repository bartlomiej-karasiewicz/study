using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Patients.Notifications.Services
{
    public class EmailSender
    {
        public void SendNewUserEmail(string email) {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("harry4over@gmail.com", "B@rtek123"),
                EnableSsl = true,
            };

            smtpClient.Send("harry4over@gmail.com", email, "Covid19","Wiadomosc o kwarantanie");
        }
    }
}
