using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class MstGroupSetup
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Type { get; set; }
        public bool FlgActive { get; set; }
    }
}
