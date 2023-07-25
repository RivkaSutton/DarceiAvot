using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Status
    {
        public Status()
        {
            Histories = new HashSet<History>();
            StudentDetails = new HashSet<StudentDetail>();
        }

        public int StatusId { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<StudentDetail> StudentDetails { get; set; }
    }
}
