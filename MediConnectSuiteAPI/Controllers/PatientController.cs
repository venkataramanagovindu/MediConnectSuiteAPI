using IServices;
using IServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediConnectSuiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}", Name = "GetPatient")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _patientService.GetPatient(id);

            return Ok(patient);
        }

        [HttpPost(Name = "AddPatient")]
        public async Task<ActionResult> AddPatient(Patient patient)
        {
            var _patient = await _patientService.CreatePatient(patient);
            return Ok(_patient);
        }
    }
}
