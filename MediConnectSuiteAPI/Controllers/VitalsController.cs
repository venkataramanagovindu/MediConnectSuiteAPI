using IServices;
using IServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediConnectSuiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalsController : ControllerBase
    {
        IVitalsService _vitals;

        public VitalsController(IVitalsService vitals)
        {
            _vitals = vitals;
        }

        [HttpGet(Name = "GetVitals")]
        public async Task<IActionResult> GetVitals()
        {
            var vitals = await _vitals.GetAllVitals();

            return Ok(vitals);
        }
        [HttpPost(Name = "AddVitals")]
        public async Task<ActionResult> AddVitals(Vital vital)
        {
            var createdVital = await _vitals.CreateVital(vital);
            return Ok(createdVital);
        }
    }
}
