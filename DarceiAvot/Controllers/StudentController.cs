using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.DBModels;
using DataAccess.IService;
using DataAccess.Service;
using DTO;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DarceiAvot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService studentService;
        IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            _mapper = mapper;
        }

        [HttpPost, Route("AddNewStudent")]
        public async Task AddNewStudent(StudentDTO student)
        {
            StudentDetail studentDetail = _mapper.Map<StudentDetail>(student);
             await studentService.AddNewStudent(studentDetail);
        }
     
        [HttpGet, Route("GetStudentDetailsByParams")]

        public async Task<ActionResult<List<StudentDTO>>> GetStudentDetailsByParams(string? FirstName="default",string? LastName= "default",int StatusId= -1, string Id = "default")
        {
           List<StudentDetail> studentDetails = await studentService.GetStudentDetailsByParams(FirstName, LastName, StatusId, Id);
           
            return studentDetails.Count() > 0 ? Ok(_mapper.Map<List<StudentDTO>>(studentDetails)) : NotFound();
        }
        [HttpGet, Route("GetStudentDetailsByStatus")]

        public async Task<ActionResult<List<StudentDTO>>> GetStudentDetailsByStatus(int StatusId = -1)
        {
            List<StudentDetail> studentDetails = await studentService.GetStudentDetailsByStatus(StatusId);

            return studentDetails.Count() > 0 ? Ok(_mapper.Map<List<StudentDTO>>(studentDetails)) : NotFound();
        }
        [HttpPut, Route("UpdateStudent")]
        public async Task<StudentDTO> UpdateStudent(string id, StudentDTO student)
        {
            StudentDetail studentDetail = _mapper.Map<StudentDetail>(student);
            StudentDTO resStudent= _mapper.Map<StudentDTO>( await studentService.UpdateStudent(id, studentDetail));
            return resStudent;
        }
        [HttpGet, Route("GetStudents")]
        public async Task<List<StudentAndStatusDTO>> GetStudents()
        {
            List<StudentDetail> list = await studentService.GetStudents();
            List<StudentAndStatusDTO> studentAndStatusDTO = _mapper.Map<List<StudentDetail>, List<StudentAndStatusDTO>>(list);

            return studentAndStatusDTO;
        }
        [HttpGet, Route("GetEmail")]
        public Task GetEmail([FromQuery] string email)
        {
         return studentService.GetEmail(email);
        }

        [HttpPost, Route("UploadImage")]
        public async Task UploadFile(int studentId, IFormFile userfile)
        {

            try
            {
                studentService.UploadFile( studentId,userfile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                string filename = userfile.FileName;
                filename = Path.GetFileName(filename);
                string uploadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", filename);
                await using var stream = new FileStream(uploadFilePath, FileMode.Create);
                await userfile.CopyToAsync(stream);
                SetPicture( studentId,userfile.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        [HttpPut("SetPicture")]

        public Task SetPicture(int studentId,string Filename)
        {
            return studentService.SetPicture( studentId, Filename);
        }


        [HttpPost("UplaodExcel")]
        public async Task UplaodExcel(IFormFile data)
         {
            StudentDTO s = new();
            try
            {
                if (data == null || data.Length <= 0)
                {
                    throw new Exception();
                }
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using var stream = data.OpenReadStream();
                using var reader = ExcelReaderFactory.CreateReader(stream);
                int sheetCount = 1;
                do
                {
                    while (reader.Read())
                    {
                        if (sheetCount > 1)
                        {
                            //var strStudentId = reader.GetValue(0).ToString();
                            //s.StudentId= reader.GetValue(0).ToString();
                            s.StudentId = reader.GetValue(0).ToString();
                            var strStatusId = reader.GetValue(1).ToString();
                            s.StatusId  = Int32.Parse(strStatusId);
                            s.FirstName =reader.GetValue(2).ToString();
                            s.LastName  =reader.GetValue(3).ToString();
                            s.Adress    =reader.GetValue(4).ToString();
                            var strZipCode = reader.GetValue(5).ToString();
                            s.ZipCode   = Int32.Parse(strZipCode);
                            s.Phone     =reader.GetValue(6).ToString();
                            s.Email     =reader.GetValue(7).ToString();
                            var strBirthdate = reader.GetValue(8).ToString();
                            s.Birthdate = DateTime.Parse(strBirthdate);
                           // var strEntranceDate = reader.GetValue(9).ToString();
                            //s.EntranceDate = DateTime.Parse(strEntranceDate);
                            s.School = reader.GetValue(9).ToString();
                            s.ArmiUnit   = reader.GetValue(10).ToString();
                            s.Profession = reader.GetValue(11).ToString();
                            s.HomeStatus = reader.GetValue(12).ToString();
                            s.FatherName = reader.GetValue(13).ToString();
                            s.MotherName = reader.GetValue(14).ToString();
                            s.WifeName   = reader.GetValue(15).ToString();
                            s.WifeLastName =reader.GetValue(16).ToString();
                            s.WifePhone    = reader.GetValue(17).ToString();
                            s.WifeLearningPlace = reader.GetValue(18).ToString();
                            s.WifeEmail    = reader.GetValue(19).ToString();
                            var strWantChavruta = reader.GetValue(20).ToString();
                            s.WantChavruta = bool.Parse(strWantChavruta);
                            var strWasInSeminar = reader.GetValue(21).ToString();
                            s.WasInSeminar = bool.Parse(strWasInSeminar);
                            s.Picture= reader.GetValue(22).ToString();
                            //s.StudentId = studentId;

                            await AddNewStudent(s);
                        }
                        sheetCount++;
                    }
                } while (reader.NextResult());
            }
            catch (Exception ex)
            {
                throw new Exception("Error in function " + ex.Message);
            }
        }
    }
}
