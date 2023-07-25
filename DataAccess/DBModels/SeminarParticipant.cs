using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class SeminarParticipant
    {
        public int ParticipantId { get; set; }
        public int StudentId { get; set; }
        public int SeminarId { get; set; }
        public string? Name { get; set; }
        public int? Id { get; set; }
    }
}
