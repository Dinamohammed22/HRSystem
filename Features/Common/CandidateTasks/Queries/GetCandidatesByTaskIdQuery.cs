using EasyTask.Common.Requests;
using EasyTask.Models.CandidateTasks;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.CandidateTasks.Queries
{
    public record GetCandidatesByTaskIdQuery(string ProjectTaskId) : IRequestBase<IEnumerable<string>>;
    public class GetCandidatesByTaskIdQueryHandler : RequestHandlerBase<CandidateTask, GetCandidatesByTaskIdQuery, IEnumerable<string>>
    {
        public GetCandidatesByTaskIdQueryHandler(RequestHandlerBaseParameters<CandidateTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<string>>> Handle(GetCandidatesByTaskIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Get(c => c.ProjectTaskId == request.ProjectTaskId).Select(c => c.CandidateId).ToListAsync();
            return RequestResult<IEnumerable<string>>.Success(result);
        }
    }
}
