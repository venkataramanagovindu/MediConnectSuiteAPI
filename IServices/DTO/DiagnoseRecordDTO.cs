using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.DTO
{
    public class DiagnoseRecordDTO
    {


            public int Id { get; set; }

            public int? PatientId { get; set; }

            public int? DoctorId { get; set; }
            public string DoctorName {  get; set; }

            public DateOnly? AppointmentDate { get; set; }

            public string? Treatment { get; set; }

            public string? Diagnosis { get; set; }

            public string? Notes { get; set; }

            public string? Status { get; set; }
    }
}
