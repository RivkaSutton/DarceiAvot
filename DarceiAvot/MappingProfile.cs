using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.DBModels;
using DTO;
using DataAccess;


namespace CarAgent
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HistoryDTO, History>();
            CreateMap<History, HistoryDTO>();
            CreateMap<SeminarDTO, SeminarDetail>();
            CreateMap<SeminarDetail, SeminarDTO>();
            CreateMap<SeminarParticipantsDTO, SeminarParticipant>();
            CreateMap<SeminarParticipant, SeminarParticipantsDTO>();
            CreateMap<StatusDTO, Status>();
            CreateMap<Status, StatusDTO>();
            CreateMap<StudentDTO, StudentDetail>();
            CreateMap<StudentDetail, StudentDTO>();
            CreateMap<StudentsDocumentDTO, StudentsDocument>();
            CreateMap<StudentsDocument, StudentsDocumentDTO>();

            CreateMap<StudentDetail, StudentAndStatusDTO>()
              .ForMember(dest => dest.StatusType,
                          opt => opt.MapFrom(src => src.Status.Type));
            CreateMap<History, HistoryAndStatusDTO>()
               .ForMember(dest => dest.StatusType,
                           opt => opt.MapFrom(src => src.Status.Type));

        }
    }
}

