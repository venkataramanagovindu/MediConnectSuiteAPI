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
    public class GuestAccessService : IGuestAccessService
    {
        private MediConnectSuiteApiContext _context;

        public GuestAccessService(MediConnectSuiteApiContext context)
        {
            _context = context;
        }
        public async Task<int> CreateGuestAccess(int doctotId, DateTime expiryDateTime, List<int> recordIds)
        {
            // Check if the doctor ID exists in the Doctors table
            var doctorExists = await _context.Doctors.AnyAsync(d => d.DoctorId == doctotId);
            if (!doctorExists)
            {
                throw new ArgumentException("Doctor ID does not exist.");
            }

            var guid = Guid.NewGuid();

            // Insert a new record into the LinkTable with the generated UUID and expiryDateTime
            var linkTableEntry = new LinkExpiry
            {
                Token = guid.ToString(),
                DoctorId = doctotId,
                IsActive = true,
                ExpiryTime = expiryDateTime
            };

            // Add the new LinkTable entry to the database context and save changes
            await _context.LinkExpiries.AddAsync(linkTableEntry);
            await _context.SaveChangesAsync();

            // Insert record permissions for each record ID
            foreach (var recordId in recordIds)
            {
                var recordPermission = new RecordPermission
                {
                    DiagnoseRecordsId = recordId,
                    LinkExpiryId = linkTableEntry.Id
                };
                await _context.RecordPermissions.AddAsync(recordPermission);
            }
            await _context.SaveChangesAsync();

            return linkTableEntry.Id; // Return the ID of the newly created guest access record

        }

        public async Task<int> GetGuestAccess(string token, int doctorId)
        {
            try
            {

                //var doctorExists = await _context.Doctors.AnyAsync(d => d.DoctorId == doctotId);


                // Check if the token exists for the specified doctor and is active
                //var linkTableEntry = await _context.LinkExpiries.FirstOrDefaultAsync(l =>
                //    l.IsActive == true);



                var data = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == 1);

                var linkTableEntry = await _context.LinkExpiries.FirstOrDefaultAsync(l => l.IsActive == true);

                if (linkTableEntry == null)
                {
                    return 0;
                }

                // Retrieve record IDs associated with the link table entry
                var recordPermissions = await _context.RecordPermissions
                    .Where(rp => rp.LinkExpiryId == linkTableEntry.Id)
                    .Select(rp => rp.DiagnoseRecordsId)
                    .ToListAsync();

                // Retrieve history data using the record IDs
                var historyData = await _context.DiagnoseRecords
                    .Where(h => recordPermissions.Contains(h.Id))
                    .ToListAsync();
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return 1;
        }
    }
}
