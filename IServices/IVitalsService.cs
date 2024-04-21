using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IVitalsService
    {
        public Task<List<Vital>> GetAllVitals();
        public Task<int> CreateVital(Vital vital);
    }
}
