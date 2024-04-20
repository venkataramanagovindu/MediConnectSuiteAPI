using IServices;
using IServices.Models;
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
        MediConnectSuiteContext _context;

        public AppointmentsService(MediConnectSuiteContext context)
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

        public async Task<int> CreatePatient()
        {
            var patient = new Patient
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateOnly(1990, 5, 15),
                Gender = "Male",
                ContactNumber = "1234567890",
                Email = "johndoe@example.com",
                Address = "123 Main St",
                City = "Anytown",
                State = "SomeState",
                ZipCode = "12345",
                Username = "johndoe",
                Password = "hashed_password_here" // Remember to hash the password before storing it
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return patient.PatientId;
        }
    }
}
