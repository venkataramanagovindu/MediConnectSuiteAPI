using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IPatientService
    {
        public Task<Patient> GetPatient(int id);
        public Task<int> CreatePatient(Patient patient);
    }
}
