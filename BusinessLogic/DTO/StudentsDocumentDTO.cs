using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class StudentsDocumentDTO
    {
        public int DocumentId { get; set; }
        public string StudentId { get; set; } = null!;
        public byte[]? Image { get; set; }
    }
}
