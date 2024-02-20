using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class LogMstSalesPriceListDetail
    {
        public int Id { get; set; }
        public int Fkid { get; set; }
        public string ProductCode { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public decimal PerUnitSalesPrice { get; set; }
        public string LogUser { get; set; } = null!;
        public DateTime LogDate { get; set; }
        public int FksourceId { get; set; }
    }
}
