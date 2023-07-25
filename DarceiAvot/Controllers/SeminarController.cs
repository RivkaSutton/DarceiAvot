
using AutoMapper;
using DataAccess.DBModels;
using DataAccess.IService;
using DataAccess.Service;
using DTO;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DarceiAvot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarController : ControllerBase
    {
        ISeminarService seminarService;
        IMapper _mapper;

        public SeminarController(ISeminarService seminarService, IMapper mapper)
        {
            this.seminarService = seminarService;
            _mapper = mapper;
        }
        [HttpPost,Route ("AddSeminar")]

        public async Task<SeminarDetail> AddSeminar(SeminarDTO seminar)
        {
            SeminarDetail seminar1 = _mapper.Map<SeminarDetail>(seminar);
            return await seminarService.AddSeminar(seminar1);
        }

        [HttpPut, Route("UpdateSeminar")]
        public async Task<SeminarDetail> UpdateSeminar(int id, SeminarDTO seminar)
        {
            SeminarDetail seminar1 = _mapper.Map<SeminarDetail>(seminar);
            return await seminarService.UpdateSeminar(id, seminar1);
        }
        [HttpGet, Route("GetParticipantsBySeminar")]
        public async Task<List<SeminarParticipantsDTO>> GetParticipantsBySeminar(int seminarId)
        {
            List<SeminarParticipant> seminarParticipant = await seminarService.GetParticipantsBySeminar(seminarId);
            List<SeminarParticipantsDTO> seminarParticipantsDto = _mapper.Map<List<SeminarParticipant>, List<SeminarParticipantsDTO>>(seminarParticipant);
            return seminarParticipantsDto;
        }

        [HttpGet, Route("GetSeminars")]
        public async Task<List<SeminarDetail>> GetSeminars()
        {
            return await seminarService.GetSeminars();
        }

        [HttpGet, Route("GetSeminarDetailsByParams")]

        public async Task<ActionResult<List<SeminarDTO>>> GetSeminarDetailsByParams(int SeminarId = -1)
        {
            List<SeminarDetail> seminarDetails = await seminarService.GetSeminarDetailsByParams(SeminarId);
            return seminarDetails.Count()>0?Ok(_mapper.Map<List<SeminarDTO>>(seminarDetails)) : NotFound();
        }
        [HttpGet, Route("GetEmail")]
        public Task GetEmail([FromQuery] string email, [FromQuery]int id)
        {
            return seminarService.GetEmail(email,id);
        }
        [HttpPost, Route("UploadImage")]
        public async Task UploadFile(int seminarId, IFormFile userfile)
        {

            try
            {
                seminarService.UploadFile(seminarId, userfile);
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
                SetProgram(seminarId, userfile.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        [HttpPut("SetProgram")]

        public Task SetProgram(int seminarId, string Filename)
        {
            return seminarService.SetProgram(seminarId, Filename);
        }
    }
}



