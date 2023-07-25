using BusinessLogic.DTO;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IService
{
    public interface IStudentService
    {
        public Task<StudentDetail> AddNewStudent(StudentDetail student);
        public Task<List<StudentDetail>> GetStudentDetailsByParams(string FirstName = "default", string LastName = "default", int StatusId = -1, string Id = "default");
      //  public Task DeleteStudent(int id);
        public Task<StudentDetail> UpdateStudent(string id, StudentDetail studentDetail);
        public Task<List<StudentDetail>> GetStudents();
        public Task<List<StudentDetail>> GetStudentDetailsByStatus(int StatusId = -1);
        public Task GetEmail(string email);

     

        public Task UploadFile(int studentId,IFormFile userfile);
        public Task SetPicture(int studentId,string fileName);

    }
}
