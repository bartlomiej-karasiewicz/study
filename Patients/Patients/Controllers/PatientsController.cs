using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patients.Controllers.Model;
using Patients.Services;

namespace Patients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly DpDataContext _context;
        private readonly ServiceBusSender _sender;

        public PatientsController(DpDataContext context, ServiceBusSender sender) {
            _context = context;
            _sender = sender;
        }
        [HttpGet]
        public IActionResult GetAll() {

            return Ok(_context.Patients.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(Patient patient) {
            patient.TestPositiveDate = DateTime.Now.ToString("MM/dd/yyyy");
            _context.Patients.Add(patient);
            _context.SaveChanges();

            //            HttpClient client = new HttpClient();
            //
            //            string emailJson = JsonSerializer.Serialize(new EmailMessageRequest() { 
            //                EmailAddress = "harry4over@gmail.com",
            //                Subject = "Test",
            //               Body = "Test"
            //            });
            //
            //            await client.PostAsync("https://localhost:5002/api/email", new StringContent(emailJson, Encoding.UTF8,
            //                "application/json")); 

            await _sender.SendMessage(new MessagePayload() { EventName = "NewUserRegistered", UserEmail = "harry4over@gmail.com" });
            return Created("/api/patients",patient);
        }
    }
 //   public class EmailMessageRequest
//    {
//        public string EmailAddress { get; set; }
//        public string Subject { get; set; }
//        public string Body { get; set; }
//    }
}
