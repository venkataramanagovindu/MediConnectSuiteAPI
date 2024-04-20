using System;
using System.Collections.Generic;

namespace IServices.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Specialization { get; set; }

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
