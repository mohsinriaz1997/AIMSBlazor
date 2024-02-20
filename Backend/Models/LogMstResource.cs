using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class LogMstResource
    {
        public int Id { get; set; }
        public int DocNum { get; set; }
        public string ResrListName { get; set; } = null!;
        public DateTime DocDate { get; set; }
        public decimal ExchangeRate { get; set; }
        public int FkcostTypeId { get; set; }
        public bool FlgDefaultResrMst { get; set; }
        public bool FlgActive { get; set; }
        public string LogUser { get; set; } = null!;
        public DateTime LogDate { get; set; }
        public int SourceId { get; set; }
    }
}
