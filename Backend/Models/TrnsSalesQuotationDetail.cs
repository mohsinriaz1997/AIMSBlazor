using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class TrnsSalesQuotationDetail
    {
        public int Id { get; set; }
        public int Fkid { get; set; }
        public string ProductCode { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public string ProductDepartment { get; set; } = null!;
        public int FkdirectMaterialId { get; set; }
        public int? FkdirectMaterialDocNum { get; set; }
        public int Fkvohid { get; set; }
        public int? FkvohdocNum { get; set; }
        public int Fkfohid { get; set; }
        public int? FkfohdocNum { get; set; }
        public string Rmanalysis { get; set; } = null!;
        public decimal ImportCost { get; set; }
        public decimal LocalCost { get; set; }
        public decimal TotalRmcost { get; set; }
        public string Vohanalysis { get; set; } = null!;
        public string Machine { get; set; } = null!;
        public string Labour { get; set; } = null!;
        public string Electricity { get; set; } = null!;
        public string DiesAndMolds { get; set; } = null!;
        public string Tools { get; set; } = null!;
        public string Gasoline { get; set; } = null!;
        public string Packing { get; set; } = null!;
        public string Transportation { get; set; } = null!;
        public string Others { get; set; } = null!;
        public decimal TotalVohcost { get; set; }
        public decimal TotalDirectCost { get; set; }
        public decimal FohratePer { get; set; }
        public decimal Fohamount { get; set; }
        public decimal OtherFoh { get; set; }
        public decimal TotalFoh { get; set; }
        public decimal TotalUnitCost { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Margin { get; set; }
        public decimal MarginPer { get; set; }

        public virtual TrnsSalesQuotation Fk { get; set; } = null!;
    }
}
