using AutoMapper;
using TimeLogger.Application.Commands;
using TimeLogger.Application.Commands.Responses;
using TimeLogger.Application.Queries.Responses;
using TimeLogger.Contract.Requests;
using TimeLogger.Contract.Responses;

namespace TimeLogger.API.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProjectRequest, CreateProjectCommand>();
            CreateMap<CreateProjectCommandResponse, CreateProjectResponse>();
            CreateMap<GetProjectByIdQueryResponse, GetProjectByIdResponse>();

            CreateMap<CreateTimeEntryRequest, CreateTimeEntryCommand>();
            CreateMap<TimeLogger.Contract.Requests.Time, TimeLogger.Application.Commands.Time>();
            CreateMap<CreateTimeEntryCommandResponse, CreateTimeEntryResponse>();
            CreateMap<GetTimeEntryByIdQueryResponse, GetTimeEntryByIdResponse>();
        }
    }
}
