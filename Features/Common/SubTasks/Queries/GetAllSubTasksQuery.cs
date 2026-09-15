using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidateTasks.Queries;
using EasyTask.Features.Common.ExternalMemberTasks.Queries;
using EasyTask.Features.Common.SubTasks.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.SubTasks;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.SubTasks.Queries
{
    public record GetAllSubTasksQuery(
        string? ProjectTaskId,
        int pageIndex = 1,
        int pageSize = 100
    ) : IRequestBase<PagingViewModel<GetAllSubTasksDTO>>;
    public class GetAllSubTasksQueryHandler : RequestHandlerBase<SubTask, GetAllSubTasksQuery, PagingViewModel<GetAllSubTasksDTO>>
    {
        public GetAllSubTasksQueryHandler(RequestHandlerBaseParameters<SubTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllSubTasksDTO>>> Handle(GetAllSubTasksQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<SubTask>(true);

            if (!string.IsNullOrEmpty(request.ProjectTaskId))
            {
                predicate = predicate.And(t => t.ProjectTaskId == request.ProjectTaskId);
            }

            var model = await _repository
                .Get(predicate)
                .Map<GetAllSubTasksDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllSubTasksDTO>>.Success(model);
        }
    }
}
