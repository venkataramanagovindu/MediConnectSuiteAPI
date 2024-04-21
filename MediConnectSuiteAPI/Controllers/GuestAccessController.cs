using IServices;
using IServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MediConnectSuiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestAccessController : ControllerBase
    {
        private IGuestAccessService _guestAccessService;
        public GuestAccessController(IGuestAccessService guestAccessService)
        {
            _guestAccessService = guestAccessService;
        }

        [HttpGet("GetGuestAccess")]
        public async Task<ActionResult> GetGuestAccess(string token, int doctorId)
        {
            return Ok(_guestAccessService.GetGuestAccess(token, doctorId));
        }


        [HttpPost(Name = "CreateGuestAccess")]
        public async Task<ActionResult> CreateGuestAccess(int doctotId, DateTime expiryDateTime, List<int> recordIds)
        {
            var _patient = await _guestAccessService.CreateGuestAccess(doctotId, expiryDateTime, recordIds);
            return Ok(_patient);
        }
    }
}
