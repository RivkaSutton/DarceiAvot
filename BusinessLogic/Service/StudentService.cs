using BusinessLogic.DTO;
using BusinessLogic.IRepository;
using BusinessLogic.Repository;
using DataAccess.DBModels;
using DataAccess.IService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class StudentService: IStudentService
    {
        IStudentRepository studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public async Task<StudentDetail> AddNewStudent(StudentDetail student)
        {
            return await studentRepository.AddNewStudent(student);
        }
       
        public async Task<List<StudentDetail>> GetStudentDetailsByParams( string FirstName = "default", string LastName = "default", int StatusId = -1, string Id = "default")
        {
            return await studentRepository.GetStudentDetailsByParams(FirstName, LastName, StatusId, Id);
        }
        public async Task<List<StudentDetail>> GetStudentDetailsByStatus( int StatusId = -1)
        {
            return await studentRepository.GetStudentDetailsByStatus( StatusId);
        }
      
        //public async Task DeleteStudent(int id)
        //{
        //    await studentRepository.DeleteStudent(id);
        //}
        public async Task<StudentDetail> UpdateStudent(string id, StudentDetail studentDetail)
        {
            return await studentRepository.UpdateStudent(id, studentDetail);
        }
        public async Task<List<StudentDetail>> GetStudents()
        {
            return await studentRepository.GetStudents();
        }
        public Task GetEmail(string email)
        {
            return studentRepository.GetEmail(email);
        }

        public Task SetPicture(int studentId, string fileName)
        {
            return studentRepository.SetPicture( studentId,fileName);
        }
        public Task UploadFile(int studentId, IFormFile userfile)
        {
            return studentRepository.UploadFile( studentId, userfile);
        }
    }
}

