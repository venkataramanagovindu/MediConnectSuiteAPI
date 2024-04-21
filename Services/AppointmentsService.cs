using IServices;
using IServices.Models;

//using IServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AppointmentsService : IAppointmentsService
    {
        MediConnectSuiteApiContext _context;

        public AppointmentsService(MediConnectSuiteApiContext context)
        {
            _context = context;
        }

        public Task<Appointment> CreateAppointment()
        {
            throw new NotImplementedException();
        }

        public async Task<Appointment> GetAppointment()
        {
            var data = await _context.Appointments.FirstOrDefaultAsync();
            return data;
        }
    }
}
