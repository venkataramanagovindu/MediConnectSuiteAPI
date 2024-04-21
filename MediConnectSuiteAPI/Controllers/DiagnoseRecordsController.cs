using IServices;
using IServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MediConnectSuiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnoseRecordsController : ControllerBase
    {
        IDiagnoseRecords _records;
        public DiagnoseRecordsController(IDiagnoseRecords records)
        {
            _records = records;
        }

        [HttpGet("{id}", Name = "GetRecordsHistory")]
        public async Task<IActionResult> GetRecordsHistory(int id)
        {
            var patient = await _records.GetDiagnoseRecord(id);

            return Ok(patient);
        }
        [HttpGet(Name = "GetAllRecordsHistory")]
        public async Task<IActionResult> GetAllRecordsHistory()
        {
            var patient = await _records.GetAllDiagnoseRecord();

            return Ok(patient);
        }
        [HttpPost(Name = "AddRecordsHistory")]
        public async Task<ActionResult> AddRecordsHistory(DiagnoseRecord record)
        {
            var _patient = await _records.CreateDiagnoseRecord(record);
            return Ok(_patient);
        }
    }
}
