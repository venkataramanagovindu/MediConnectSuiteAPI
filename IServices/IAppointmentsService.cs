using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAppointmentsService
    {
        public Task<Appointment> GetAppointment();
        public Task<Appointment> CreateAppointment();
        public Task<int> CreatePatient();
    }
}
