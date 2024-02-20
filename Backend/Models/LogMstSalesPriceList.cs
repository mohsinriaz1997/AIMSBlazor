using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class LogMstSalesPriceList
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string Plname { get; set; } = null!;
        public bool FlgDefult { get; set; }
        public string LogUser { get; set; } = null!;
        public DateTime LogDate { get; set; }
        public int SourceId { get; set; }
    }
}
