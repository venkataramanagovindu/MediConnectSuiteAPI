using System;
using System.Collections.Generic;

namespace IServices.Models;

public partial class LinkExpiry
{
    public int Id { get; set; }

    public string? Token { get; set; }

    public int? DoctorId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? ExpiryTime { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<RecordPermission> RecordPermissions { get; set; } = new List<RecordPermission>();
}
