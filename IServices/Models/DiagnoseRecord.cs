using System;
using System.Collections.Generic;

namespace IServices.Models;

public partial class DiagnoseRecord
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public DateOnly? AppointmentDate { get; set; }

    public string? Treatment { get; set; }

    public string? Diagnosis { get; set; }

    public string? Notes { get; set; }

    public string? Status { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual ICollection<RecordPermission> RecordPermissions { get; set; } = new List<RecordPermission>();
}
