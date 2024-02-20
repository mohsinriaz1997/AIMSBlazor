using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class MstSalesPriceListDetail
    {
        public int Id { get; set; }
        public int Fkid { get; set; }
        public string ProductCode { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public decimal PerUnitSalesPrice { get; set; }

        public virtual MstSalesPriceList Fk { get; set; } = null!;
    }
}
