using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class StudentsDocument
    {
        public int DocumentId { get; set; }
        public string StudentId { get; set; } = null!;
        public byte[]? Image { get; set; }

        public virtual StudentDetail Student { get; set; } = null!;
    }
}
