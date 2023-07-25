using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.DBModels;
using DataAccess.IService;
using DataAccess.Service;
using DTO;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarceiAvot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        IHistoryService historyService;
        IMapper _mapper;

        public HistoryController(IHistoryService historyService, IMapper mapper)
        {
            this.historyService = historyService;
            _mapper = mapper;
        }
        [HttpGet, Route("GetHistoryForStudent")]
        public async Task<List<HistoryAndStatusDTO>> GetHistoryForStudent(string studentId)
        {
            List<History> list = await historyService.GetHistoryForStudent(studentId);
            List<HistoryAndStatusDTO> historyAndStatusDTO = _mapper.Map<List<History>, List<HistoryAndStatusDTO>>(list);
            return historyAndStatusDTO;

        }

    }
}


