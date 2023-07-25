using BusinessLogic.IRepository;
using BusinessLogic.Repository;
using DataAccess.DBModels;
using DataAccess.IService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class SeminarService: ISeminarService
    {
       
            ISeminarRepository seminarRepository;
            public SeminarService(ISeminarRepository seminarRepository)
            {
                this.seminarRepository = seminarRepository;
            }
        public async Task<SeminarDetail> AddSeminar(SeminarDetail seminar)
        {
            return await seminarRepository.AddSeminar(seminar);
        }
        public async Task<SeminarDetail> UpdateSeminar(int id, SeminarDetail seminar)
        {
            return await seminarRepository.UpdateSeminar(id, seminar);
        }
        public async Task<List<SeminarParticipant>> GetParticipantsBySeminar(int seminarId)
        {
            return await seminarRepository.GetParticipantsBySeminar(seminarId);
        }
        public async Task<List<SeminarDetail>> GetSeminars()
        {
            return await seminarRepository.GetSeminars();
        }
        public async Task<List<SeminarDetail>> GetSeminarDetailsByParams( int SeminarId = -1)
        {
            return await seminarRepository.GetSeminarDetailsByParams(SeminarId);
        }
        public Task GetEmail(string email, int id)
        {
            return seminarRepository.GetEmail(email,id);
        }
        public Task SetProgram(int seminarId, string fileName)
        {
            return seminarRepository.SetProgram(seminarId, fileName);
        }
        public Task UploadFile(int seminarId, IFormFile userfile)
        {
            return seminarRepository.UploadFile(seminarId, userfile);
        }
    }
}
