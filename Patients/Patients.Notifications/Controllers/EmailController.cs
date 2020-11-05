using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patients.Notifications.Model;
using Patients.Notifications.Services;

namespace Patients.Notifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {   
        [HttpPost]
        public void SendMessage(EmailMessageRequest request) {
            EmailSender sender = new EmailSender();
            sender.SendNewUserEmail(request.EmailAddress);
        }

    }
}
