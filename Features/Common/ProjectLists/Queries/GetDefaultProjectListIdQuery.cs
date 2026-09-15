using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.ProjectLists;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.ProjectLists.Queries
{
    public record GetDefaultProjectListIdQuery(string ProjectId) : IRequestBase<string>;
    public class GetDefaultProjectListIdQueryHandler: RequestHandlerBase<ProjectList, GetDefaultProjectListIdQuery, string>
    {
        public GetDefaultProjectListIdQueryHandler(RequestHandlerBaseParameters<ProjectList> requestParameters): base(requestParameters)
        {
        }

        public override async Task<RequestResult<string>> Handle( GetDefaultProjectListIdQuery request,CancellationToken cancellationToken)
        {
            var defaultList = await _repository.Get(pl => pl.ProjectId == request.ProjectId)
                .Where(pl => pl.Sequence == 1)
                .Select(pl => pl.ID)
                .FirstOrDefaultAsync(cancellationToken);

            if (string.IsNullOrEmpty(defaultList))
                return RequestResult<string>.Failure(ErrorCode.NotFound);

            return RequestResult<string>.Success(defaultList);
        }
    }
}
