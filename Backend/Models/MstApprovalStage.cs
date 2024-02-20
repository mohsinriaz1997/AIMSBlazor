using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class MstApprovalStage
    {
        public int Id { get; set; }
        public int? FkstageId { get; set; }
        public string? FkstageName { get; set; }
        public int? FkapprovalId { get; set; }
        public int? ApprovalPriority { get; set; }

        public virtual MstApprovalSetup? Fkapproval { get; set; }
    }
}
