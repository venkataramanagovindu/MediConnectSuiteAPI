using IServices;
using IServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PatientService: IPatientService
    {
        MediConnectSuiteApiContext _context;

        public PatientService(MediConnectSuiteApiContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetPatient(int id)
        {
            var data = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == id);
            return data;
        }

        public async Task<int> CreatePatient(Patient patient)
        {
            try
            {
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return patient.PatientId;
        }
    }
}
