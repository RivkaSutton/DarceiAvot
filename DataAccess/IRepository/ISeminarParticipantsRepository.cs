using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IRepository
{
    public interface ISeminarParticipantsRepository
    {
        public Task DeleteParticipantFromSeminar(SeminarParticipant seminarParticipant);



        //public Task DeleteParticipantFromSeminar(int Id = -1, int SeminarId = -1, string Name = "default");
        public Task<SeminarParticipant> AddParticipantToSeminar(SeminarParticipant seminarParticipant);

    }
}
  