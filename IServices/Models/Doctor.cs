using System;
using System.Collections.Generic;

namespace IServices.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<DiagnoseRecord> DiagnoseRecords { get; set; } = new List<DiagnoseRecord>();

    public virtual ICollection<LinkExpiry> LinkExpiries { get; set; } = new List<LinkExpiry>();
}
