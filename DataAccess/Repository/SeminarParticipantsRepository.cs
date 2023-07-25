using BusinessLogic.IRepository;
using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogic.Repository
{
    public class SeminarParticipantsRepository : ISeminarParticipantsRepository
    {
        DarceiAvotContext _dbContext;

        public SeminarParticipantsRepository(DarceiAvotContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public async Task DeleteParticipantFromSeminar(int Id = -1, int SeminarId = -1, string Name = "default")
        //{
        //    SeminarParticipant seminarParticipant = _dbContext.SeminarParticipants.Where(participant => participant.Id == Id && participant.SeminarId == SeminarId && participant.Name == Name).FirstOrDefault();
        //    _dbContext.SeminarParticipants.Remove(seminarParticipant);
        //    await _dbContext.SaveChangesAsync();

        //}
        public async Task DeleteParticipantFromSeminar(SeminarParticipant seminarParticipant)
        {
            try
            {
                SeminarParticipant participant = _dbContext.SeminarParticipants.Where(participant => participant.SeminarId == seminarParticipant.SeminarId && participant.StudentId == seminarParticipant.StudentId ).FirstOrDefault();
                if (participant != null)
                {
                    _dbContext.SeminarParticipants.Remove(participant);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DeleteParticipantFromSeminar" + ex.Message);
            }

        }
        public async Task<SeminarParticipant> AddParticipantToSeminar(SeminarParticipant seminarParticipant)
        {
            try
            {
                await _dbContext.SeminarParticipants.AddAsync(seminarParticipant);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Add Participant To Seminar" + ex.Message);
            }
            return seminarParticipant;
        }

    }
}
