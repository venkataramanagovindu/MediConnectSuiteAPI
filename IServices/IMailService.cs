using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IMailService
    {
        public void Send(MailMessage message);
    }
}
