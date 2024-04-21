using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediConnectSuiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        IAppointmentsService _appointmentsService;
        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }
        //[HttpGet(Name = "GetAppointment")]
        //public async Task<IActionResult> GetAppointment()
        //{
        //    var app = _appointmentsService.GetAppointment();
        //    return Ok(app);
        //}

        [HttpGet(Name = "GetAllAppointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var patient = await _appointmentsService.GetAllAppointments();

            return Ok(patient);
        }

        [HttpPost(Name = "CreateAppointment")]
        public async Task<IActionResult> CreateAppointment()
        {
            var app = await _appointmentsService.CreateAppointment();
            return Ok(app);
        }



        //[HttpGet(Name = "CreatePatientsome")]
        //public async Task<IActionResult> CreatePatient()
        //{
        //    await _appointmentsService.CreatePatient();
        //    var data = 10;
        //    return Ok(data);
        //}
    }
}
