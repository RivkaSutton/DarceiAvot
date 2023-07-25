using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IService
{
    public interface ISeminarParticipantsService
    {
        // public Task DeleteParticipantFromSeminar(int Id = -1, int SeminarId = -1, string Name="default");
        public Task DeleteParticipantFromSeminar(SeminarParticipant seminarParticipant);


        public Task AddParticipantToSeminar(SeminarParticipant seminarParticipant);

    }
}
