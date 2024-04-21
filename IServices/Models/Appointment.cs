﻿using System;
using System.Collections.Generic;

namespace IServices.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public DateOnly? AppointmentDate { get; set; }

    public string? Status { get; set; }

    public DateOnly? NextAppointment { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }
}
