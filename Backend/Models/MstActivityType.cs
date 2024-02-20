using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class MstActivityType
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool FlgActive { get; set; }
    }
}
