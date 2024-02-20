using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class LogMstDesignation
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool FlgActive { get; set; }
        public string LogUser { get; set; } = null!;
        public DateTime LogDate { get; set; }
        public int SourceId { get; set; }
    }
}
