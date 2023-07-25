using AutoMapper;
using DataAccess.DBModels;
using DataAccess.IService;
using DataAccess.Service;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//change
namespace DarceiAvot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarParticipantsController : ControllerBase
    {
        ISeminarParticipantsService SeminarParticipantsService;
        IMapper _mapper;
        public SeminarParticipantsController(ISeminarParticipantsService SeminarParticipantsService, IMapper mapper)
        {
            this.SeminarParticipantsService = SeminarParticipantsService;
            _mapper = mapper;
        }
        
        [HttpDelete, Route("DeleteParticipantFromSeminar")]
        public async Task DeleteParticipantFromSeminar([FromQuery] SeminarParticipantsDTO seminarParticipant)
        {
            SeminarParticipant seminarParticipant1 = _mapper.Map<SeminarParticipant>(seminarParticipant);
            await SeminarParticipantsService.DeleteParticipantFromSeminar(seminarParticipant1);
        }

        [HttpPost, Route("AddParticipantToSeminar")]
        public async Task AddParticipantToSeminar([FromQuery]SeminarParticipantsDTO seminarParticipant)
        {
            SeminarParticipant seminarParticipant1 = _mapper.Map<SeminarParticipant>(seminarParticipant);
            await SeminarParticipantsService.AddParticipantToSeminar(seminarParticipant1);
        }
    }
}
