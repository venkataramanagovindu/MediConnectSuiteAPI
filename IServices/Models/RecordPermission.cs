using System;
using System.Collections.Generic;

namespace IServices.Models;

public partial class RecordPermission
{
    public int Id { get; set; }

    public int? DiagnoseRecordsId { get; set; }

    public int? LinkExpiryId { get; set; }

    public virtual DiagnoseRecord? DiagnoseRecords { get; set; }

    public virtual LinkExpiry? LinkExpiry { get; set; }
}
