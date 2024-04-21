using System;
using System.Collections.Generic;

namespace IServices.Models;

public partial class Vital
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public DateOnly? DateOfUpload { get; set; }

    public DateOnly? TestDate { get; set; }

    public string? UploadedBy { get; set; }

    public string? HospitalName { get; set; }

    public string? DocumentType { get; set; }

    public string? Status { get; set; }

    public string? Temperature { get; set; }

    public string? SpO2 { get; set; }

    public string? HeartRate { get; set; }

    public string? BloodPressure { get; set; }

    public string? BreathingRate { get; set; }

    public virtual Patient? Patient { get; set; }
}
