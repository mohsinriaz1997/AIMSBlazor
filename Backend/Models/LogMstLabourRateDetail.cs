using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class LogMstLabourRateDetail
    {
        public int Id { get; set; }
        public int Fkid { get; set; }
        public string Description { get; set; } = null!;
        public decimal WageRate { get; set; }
        public int FkcostTypeId { get; set; }
        public bool FlgActive { get; set; }
        public string LogUser { get; set; } = null!;
        public DateTime LogDate { get; set; }
        public int FksourceId { get; set; }
    }
}
