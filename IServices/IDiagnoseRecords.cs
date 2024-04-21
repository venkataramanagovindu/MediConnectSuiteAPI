using IServices.DTO;
using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IDiagnoseRecords
    {
        public Task<DiagnoseRecordDTO> GetDiagnoseRecord(int id);
        public Task<List<DiagnoseRecordDTO>> GetAllDiagnoseRecord();
        public Task<int> CreateDiagnoseRecord(DiagnoseRecord patient);
    }
}
