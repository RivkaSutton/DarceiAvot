using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SeminarDTO
    {
        //public int SeminarId { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Place { get; set; } = null!;
        public string? Lectures { get; set; }
        public string Crowed { get; set; } = null!;
        public string Program { get; set; } = null!;

        // public  ICollection<SeminarParticipantsDTO> SeminarParticipants { get; set; }

    }
}
