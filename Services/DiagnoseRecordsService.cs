using IServices;
using IServices.DTO;
using IServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DiagnoseRecordsService : IDiagnoseRecords
    {
        MediConnectSuiteApiContext _context;

        public DiagnoseRecordsService(MediConnectSuiteApiContext context)
        {
            _context = context;
        }

        public async Task<int> CreateDiagnoseRecord(DiagnoseRecord record)
        {
            try
            {
                _context.DiagnoseRecords.Add(record);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return record.Id;
        }

        public async Task<DiagnoseRecordDTO> GetDiagnoseRecord(int id)
        {

            var data = await _context.DiagnoseRecords
            .Include(d => d.Doctor) // Include the Doctor navigation property
            .Select(d => new DiagnoseRecordDTO
            {
                Id = d.Id,
                PatientId = d.PatientId,
                DoctorId = d.DoctorId,
                DoctorName = d.Doctor != null ? d.Doctor.Name : null,
                AppointmentDate = d.AppointmentDate,
                Treatment = d.Treatment,
                Diagnosis = d.Diagnosis,
                Notes = d.Notes,
                Status = d.Status
            })

            .FirstOrDefaultAsync(p => p.Id == id);

                    return data;



            //var data = await _context.DiagnoseRecords.FirstOrDefaultAsync(p => p.Id == id);
            //return data;
        }

        public async Task<List<DiagnoseRecordDTO>> GetAllDiagnoseRecord()
        {

            var data = await _context.DiagnoseRecords
            .Include(d => d.Doctor) // Include the Doctor navigation property
            .Select(d => new DiagnoseRecordDTO
            {
                Id = d.Id,
                PatientId = d.PatientId,
                DoctorId = d.DoctorId,
                DoctorName = d.Doctor != null ? d.Doctor.Name : null,
                AppointmentDate = d.AppointmentDate,
                Treatment = d.Treatment,
                Diagnosis = d.Diagnosis,
                Notes = d.Notes,
                Status = d.Status
            }).ToListAsync();




            return data;
        }

    }
}
