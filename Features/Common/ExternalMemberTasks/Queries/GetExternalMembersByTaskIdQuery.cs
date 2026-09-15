using EasyTask.Common.Requests;
using EasyTask.Models.ExternalMemberTasks;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.ExternalMemberTasks.Queries
{
    public record GetExternalMembersByTaskIdQuery(string ProjectTaskId) : IRequestBase<IEnumerable<string>>;
    public class GetExternalMembersByTaskIdQueryHandler : RequestHandlerBase<ExternalMemberTask, GetExternalMembersByTaskIdQuery, IEnumerable<string>>
    {
        public GetExternalMembersByTaskIdQueryHandler(RequestHandlerBaseParameters<ExternalMemberTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<string>>> Handle(GetExternalMembersByTaskIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Get(c => c.ProjectTaskId == request.ProjectTaskId).Select(c => c.ExternalMemberId).ToListAsync();
            return RequestResult<IEnumerable<string>>.Success(result);
        }
    }
}
