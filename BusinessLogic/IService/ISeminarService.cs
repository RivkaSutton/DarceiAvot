using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IService
{
    public interface ISeminarService
    {
        public Task<SeminarDetail> AddSeminar(SeminarDetail seminar);
        public Task<SeminarDetail> UpdateSeminar(int id, SeminarDetail seminar);
        public Task<List<SeminarParticipant>> GetParticipantsBySeminar(int seminarId);
        public Task<List<SeminarDetail>> GetSeminars();
        public  Task<List<SeminarDetail>> GetSeminarDetailsByParams(int SeminarId = -1);
        public Task GetEmail(string email, int id);
        public Task SetProgram(int seminarId, string fileName);
        public Task UploadFile(int seminarId, IFormFile userfile);





    }
}
