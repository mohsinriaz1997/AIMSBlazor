using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class TrnsVohdyesAndMoldDetail
    {
        public int Id { get; set; }
        public int Fkid { get; set; }
        public string ProductCode { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public decimal DyesAndMoldVohrate { get; set; }
        public decimal DyesAndMoldVohamount { get; set; }

        public virtual TrnsVoh Fk { get; set; } = null!;
    }
}
