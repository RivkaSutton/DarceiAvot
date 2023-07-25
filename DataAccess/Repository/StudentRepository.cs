using BusinessLogic.IRepository;
using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;

namespace BusinessLogic.Repository
{
    public class StudentRepository : IStudentRepository
    {
        DarceiAvotContext _dbContext;

        public StudentRepository(DarceiAvotContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task GetEmail(string email)
        {
            using (SmtpClient client = new SmtpClient()
            {
                Host = "smtp.office365.com",
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("darceiavot@outlook.com", "Rg123!@#"), 
                TargetName = "STARTTLS/smtp.office365.com",
                EnableSsl = true 
            })
            {

                MailMessage message = new MailMessage()
                {
                    From = new MailAddress("darceiavot@outlook.com"),
                    Subject = "הרשמה",
                    IsBodyHtml = true,
                    Body = "<h5>להרשמה לחצו על הלינק הבא:</h5><br><a href=\"http://localhost:3000/AddNewStudent\">להרשמה  לישיבה לחץ כאן</a>",
                    
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8,



            };

                message.To.Add(email);

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
          
        }
  
       
        public async Task<StudentDetail> AddNewStudent(StudentDetail student)
        {
            try
            {
                StudentDetail a = _dbContext.StudentDetails.Find(student.StudentId);
                if (a == null)
                {
                    student.EntranceDate = DateTime.Now;
                    await _dbContext.StudentDetails.AddAsync(student);
                    await _dbContext.SaveChangesAsync();
                    StudentDetail s = await _dbContext.StudentDetails.Where(data => data.StudentId.Equals(student.StudentId)).FirstOrDefaultAsync();
                    Task<History> history = converToHistory(s);
                    History history1 = history.Result;
                    _dbContext.Histories.Add(history1);
                    await _dbContext.SaveChangesAsync();

                }
                else
                {
                    throw new InvalidOperationException("The id is exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in add student" + ex.Message);
            }
            return student;
        }

        public async Task<List<StudentDetail>> GetStudentDetailsByParams(string FirstName = "default", string LastName = "default", int StatusId = -1, string Id = "default")
        {
            var students = await (from student in _dbContext.StudentDetails
                                  where (student.FirstName == FirstName || FirstName == "default") && (student.LastName == LastName || LastName == "default") &&
                                  (student.StatusId == StatusId || StatusId == -1) && (student.StudentId.Equals(Id) || Id == "default")
                                  select student).ToListAsync();
            return students;

        }
        public async Task<List<StudentDetail>> GetStudentDetailsByStatus(int StatusId = -1)
        {
            var students = await (from student in _dbContext.StudentDetails

                                  where (student.StatusId == StatusId || StatusId == -1)

                                  select student).ToListAsync();
            return students;


        }

        public async Task<History> converToHistory(StudentDetail studentDetail)
        {
            History history = new History();
            history.StudentId = studentDetail.StudentId;
            history.StatusId = studentDetail.StatusId;
            history.FirstName = studentDetail.FirstName;
            history.LastName = studentDetail.LastName;
            history.Adress = studentDetail.Adress;
            history.ZipCode = studentDetail.ZipCode;
            history.Phone = studentDetail.Phone;
            history.Email = studentDetail.Email;
            history.Birthdate = studentDetail.Birthdate;
            history.EntranceDate = DateTime.Now;
            history.School = studentDetail.School;
            history.ArmiUnit = studentDetail.ArmiUnit;
            history.Profession = studentDetail.Profession;
            history.HomeStatus = studentDetail.HomeStatus;
            history.FatherName = studentDetail.FatherName;
            history.MotherName = studentDetail.MotherName;
            history.WifeName = studentDetail.WifeName;
            history.WifeLastName = studentDetail.WifeLastName;
            history.WifePhone = studentDetail.WifePhone;
            history.WifeLearningPlace = studentDetail.WifeLearningPlace;
            history.WifeEmail = studentDetail.WifeEmail;
            history.WantChavruta = studentDetail.WantChavruta;
            history.WasInSeminar = studentDetail.WasInSeminar;
            history.Picture = studentDetail.Picture;
            return history;
        }
        public async Task<StudentDetail> UpdateStudent(string id, StudentDetail studentDetail)
        {
            try
            {
                StudentDetail student1 = await _dbContext.StudentDetails.Where(data => data.StudentId.Equals(id)).FirstOrDefaultAsync();
                if (student1 != null)
                {
                    student1.StudentId = studentDetail.StudentId;
                    student1.StatusId = studentDetail.StatusId;
                    student1.FirstName = studentDetail.FirstName;
                    student1.LastName = studentDetail.LastName;
                    student1.Adress = studentDetail.Adress;
                    student1.ZipCode = studentDetail.ZipCode;
                    student1.Phone = studentDetail.Phone;
                    student1.Email = studentDetail.Email;
                    student1.Birthdate = studentDetail.Birthdate;
                    student1.EntranceDate = DateTime.Now;
                    student1.School = studentDetail.School;
                    student1.ArmiUnit = studentDetail.ArmiUnit;
                    student1.Profession = studentDetail.Profession;
                    student1.HomeStatus = studentDetail.HomeStatus;
                    student1.FatherName = studentDetail.FatherName;
                    student1.MotherName = studentDetail.MotherName;
                    student1.WifeName = studentDetail.WifeName;
                    student1.WifeLastName = studentDetail.WifeLastName;
                    student1.WifePhone = studentDetail.WifePhone;
                    student1.WifeLearningPlace = studentDetail.WifeLearningPlace;
                    student1.WifeEmail = studentDetail.WifeEmail;
                    student1.WantChavruta = studentDetail.WantChavruta;
                    student1.WasInSeminar = studentDetail.WasInSeminar;
                    student1.Picture = studentDetail.Picture;
                    student1.StudentId.Equals(id);
                    Task<History> history = converToHistory(student1);
                    History history1 = history.Result;
                    _dbContext.Histories.Add(history1);
                    _dbContext.StudentDetails.Update(student1);
                    await _dbContext.SaveChangesAsync();
                }
                return student1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Update student" + ex.Message);
            }
        }
        public async Task<List<StudentDetail>> GetStudents()
        {
            try
            {

                return await _dbContext.StudentDetails
                    .Include(s => s.Status).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Error in Get Students" + ex.Message);
            }

        }
        public async Task SetPicture(int studentId, string fileName)
        {
            try
            {
                StudentDetail s = _dbContext.StudentDetails.Find(studentId);
                if (s != null)
                {
                    s.Picture = fileName;
                    _dbContext.Update(s);
                    await _dbContext.SaveChangesAsync();
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error in SetPicture function " + ex.Message);
            }
        }
        public async Task UploadFile( int studentId,IFormFile userfile)
        {
            try
            {
                Image image = new Image() { FilePath = "images/" + userfile.FileName, FileName = userfile.FileName };
                await _dbContext.AddAsync(image);
                await _dbContext.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception("Error in SetPicture function " + ex.Message);
            }
        }
              
    }
} 