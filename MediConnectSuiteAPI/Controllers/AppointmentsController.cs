using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediConnectSuiteAPI.Controllers
{
    [Route("api/Appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        IAppointmentsService _appointmentsService;
        public AppointmentsController(IAppointmentsService appointmentsService) 
        {
            _appointmentsService = appointmentsService;
        }
        [HttpGet(Name = "GetAppointment")]
        public async Task<IActionResult> GetAppointment()
        {
            var app = _appointmentsService.GetAppointment();
            //var app = await _appointmentsService.GetPatient();
            //return Ok(await dbContext.Contacts.ToListAsync());

            //await _appointmentsService.CreatePatient()/*;*/
            return Ok("Hello");


            //var paitent = await _appointmentsService.GetPatient();

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
