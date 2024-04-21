using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IGuestAccessService
    {
        public Task<int> CreateGuestAccess(int doctotId, DateTime expiryDateTime, List<int> recordIds);
        public Task<int> GetGuestAccess(string token, int doctorId);

    }
}
