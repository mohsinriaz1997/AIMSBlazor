using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class LogMstLabourRate
    {
        public int Id { get; set; }
        public int DocNum { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string LogUser { get; set; } = null!;
        public DateTime LogDate { get; set; }
        public int SourceId { get; set; }
    }
}
