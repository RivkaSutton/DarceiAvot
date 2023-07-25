using BusinessLogic.IRepository;
using BusinessLogic.Repository;
using DataAccess.DBModels;
using DataAccess.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class SeminarParticipantsService: ISeminarParticipantsService
    {
        ISeminarParticipantsRepository seminarParticipantsRepository;
           public SeminarParticipantsService(ISeminarParticipantsRepository seminarParticipantsRepository)
        {
            this.seminarParticipantsRepository = seminarParticipantsRepository;
        }
        //public async Task DeleteParticipantFromSeminar(int Id = -1, int SeminarId = -1, string Name = "default")
        //{
        //    await seminarParticipantsRepository.DeleteParticipantFromSeminar(Id, SeminarId,Name);
        //}
        public async Task DeleteParticipantFromSeminar(SeminarParticipant seminarParticipant)
        {
            await seminarParticipantsRepository.DeleteParticipantFromSeminar(seminarParticipant);
        }
        public async Task AddParticipantToSeminar(SeminarParticipant seminarParticipant)
        {
             await seminarParticipantsRepository.AddParticipantToSeminar(seminarParticipant);
        }
       

    }
}
