using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HistoryDTO
    {
        public int HistoryId { get; set; }
        public string StudentId { get; set; } = null!;
        public string StatusId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Adress { get; set; }
        public int? ZipCode { get; set; }
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime EntranceDate { get; set; }
        public string? School { get; set; }
        public string? ArmiUnit { get; set; }
        public string? Profession { get; set; }
        public string HomeStatus { get; set; } = null!;
        public string FatherName { get; set; } = null!;
        public string MotherName { get; set; } = null!;
        public string? WifeName { get; set; }
        public string? WifeLastName { get; set; }
        public string? WifePhone { get; set; }
        public string? WifeLearningPlace { get; set; }
        public string? WifeEmail { get; set; }
        public bool? WantChavruta { get; set; }
        public bool? WasInSeminar { get; set; }
        public string? Picture { get; set; }


    }
}
