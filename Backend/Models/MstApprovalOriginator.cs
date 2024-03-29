﻿using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class MstApprovalOriginator
    {
        public int Id { get; set; }
        public int? FkApprovalId { get; set; }
        public int? OriginatorId { get; set; }

        public virtual MstApprovalSetup? FkApproval { get; set; }
    }
}
