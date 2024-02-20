using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class LogMstUserProfile
    {
        public int Id { get; set; }
        public string UserCode { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int FkdesignationId { get; set; }
        public int FkdeptId { get; set; }
        public string EmailId { get; set; } = null!;
        public bool FlgSuper { get; set; }
        public bool FlgActive { get; set; }
        public string LogUser { get; set; } = null!;
        public DateTime LogDate { get; set; }
        public int SourceId { get; set; }
    }
}
