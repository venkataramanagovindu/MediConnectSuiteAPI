using IServices;
using IServices.Models;

//using IServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        public async Task<int> CreateAppointment()
        {
            Appointment appointment = new Appointment
            {
                PatientId = 2,
                DoctorId = 2,
                AppointmentDate = new DateOnly(2024, 3, 21),
                Status = "Scheduled",
                NextAppointment = new DateOnly(2024, 4, 21)
            };
            try
            {
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return appointment.Id;
        }

        public async Task<Appointment> GetAppointment()
        {
            try
            {
                var appointments = await _context.Appointments.FirstOrDefaultAsync(p => p.Id == 1);
                return new Appointment();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some");
            }
            return new Appointment();
        }

        public Task<List<Appointment>> GetAllAppointments()
        {
            var data = _context.Appointments.ToListAsync();
            return data;
        }

    }
}
