using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patients.Controllers.Model;

namespace Patients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly DpDataContext _context;

        public PatientsController(DpDataContext context) {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll() {

            return Ok(_context.Patients.ToList());
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient) {
            patient.TestPositiveDate = DateTime.Now.ToString("MM/dd/yyyy");
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return Created("/api/patients",patient);
        }
    }
}
