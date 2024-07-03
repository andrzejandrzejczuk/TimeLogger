using Refit;
using TimeLogger.Contract.Requests;
using TimeLogger.Contract.Responses;

namespace TimeLogger.Contract.Interfaces
{
    public interface ITimeLogsService
    {
        [Post("TimeLogs/create")]
        Task<IApiResponse<CreateTimeEntryResponse>> Create([Body] CreateTimeEntryRequest request);

        [Delete("TimeLogs/delete/{id}")]
        Task<IApiResponse> Delete(Guid id);

        [Get("TimeLogs/{id}")]
        Task<IApiResponse<GetTimeEntryByIdResponse>> GetById(Guid id);
    }
}
