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
    public class VitalsService : IVitalsService
    {
        MediConnectSuiteApiContext _context;
        public VitalsService(MediConnectSuiteApiContext context)
        {
            _context = context;
        }

        public async Task<int> CreateVital(Vital vital)
        {
            try
            {
                _context.Vitals.Add(vital);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return vital.Id;
        }

        public async Task<List<Vital>> GetAllVitals()
        {
            var data = await _context.Vitals.ToListAsync();
            return data;
        }
    }
}
