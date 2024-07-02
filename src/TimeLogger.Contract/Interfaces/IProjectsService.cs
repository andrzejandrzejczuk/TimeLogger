using Refit;
using TimeLogger.Contract.Requests;
using TimeLogger.Contract.Responses;

namespace TimeLogger.Contract.Interfaces
{
    public interface IProjectsService
    {
        [Post("Projects/create")]
        Task<IApiResponse> Create(CreateProjectRequest request);

        [Get("Projects/{id}")]
        Task<IApiResponse<GetProjectByIdResponse>> GetById(Guid id);
    }
}
