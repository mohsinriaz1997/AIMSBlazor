﻿using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class MstSalesPriceList
    {
        public MstSalesPriceList()
        {
            MstSalesPriceListDetails = new HashSet<MstSalesPriceListDetail>();
        }

        public int Id { get; set; }
        public string CustomerCode { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string Plname { get; set; } = null!;
        public bool FlgDefult { get; set; }

        public virtual ICollection<MstSalesPriceListDetail> MstSalesPriceListDetails { get; set; }
    }
}
