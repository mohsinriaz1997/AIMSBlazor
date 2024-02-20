using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class LogMstResourceDetail
    {
        public int Id { get; set; }
        public int Fkid { get; set; }
        public string TypeOfResr { get; set; } = null!;
        public string ResrDescription { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public decimal Rate { get; set; }
        public decimal Price { get; set; }
        public decimal LandedFactor { get; set; }
        public decimal Cost { get; set; }
        public bool FlgActive { get; set; }
        public string LogUser { get; set; } = null!;
        public DateTime LogDate { get; set; }
        public int FksourceId { get; set; }
    }
}
