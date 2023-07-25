using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StudentDTO
    {

        public string StudentId { get; set; } = null!;
        [Required]
        public int StatusId { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Adress { get; set; }
        public int? ZipCode { get; set; }
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime? EntranceDate { get; set; }
        public string? School { get; set; }
        public string? ArmiUnit { get; set; }
        public string? Profession { get; set; }
        public string HomeStatus { get; set; } = null!;
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? WifeName { get; set; }
        public string? WifeLastName { get; set; }
        public string? WifePhone { get; set; }
        public string? WifeLearningPlace { get; set; }
        public string? WifeEmail { get; set; }
        public bool? WantChavruta { get; set; }
        public bool? WasInSeminar { get; set; }
        public string? Picture { get; set; }
        public string? IdCardFront { get; set; }
        public string? IdCardBack { get; set; }
        public string? IdCardAttachment { get; set; }


    }
}
