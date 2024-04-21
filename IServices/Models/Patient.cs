using System;
using System.Collections.Generic;

namespace IServices.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<DiagnoseRecord> DiagnoseRecords { get; set; } = new List<DiagnoseRecord>();

    public virtual ICollection<Vital> Vitals { get; set; } = new List<Vital>();
}
