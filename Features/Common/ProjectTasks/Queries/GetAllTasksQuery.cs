using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidateTasks.Queries;
using EasyTask.Features.Common.ExternalMemberTasks.Queries;
using EasyTask.Features.Common.ProjectTasks.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.ProjectTasks;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.ProjectTasks.Queries
{
    public record GetAllTasksQuery(
        DateOnly? From,
        DateOnly? TO,
        string? ProjectId,
        int pageIndex = 1,
        int pageSize = 100
    ) : IRequestBase<PagingViewModel<GetAllTasksDTO>>;
    public class GetAllTasksQueryHandler : RequestHandlerBase<ProjectTask, GetAllTasksQuery, PagingViewModel<GetAllTasksDTO>>
    {
        public GetAllTasksQueryHandler(RequestHandlerBaseParameters<ProjectTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllTasksDTO>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<ProjectTask>(true);

            predicate = predicate
                .And(t => !string.IsNullOrEmpty(request.ProjectId) || t.ProjectId == request.ProjectId)
                .And(t => !request.From.HasValue || DateOnly.FromDateTime(t.StartDate) >= request.From.Value)
                .And(t => !request.TO.HasValue || DateOnly.FromDateTime(t.EndDate) <= request.TO.Value);

            var model = await _repository
                .Get(predicate)
                .Map<GetAllTasksDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);
            foreach (var item in model.Items)
            {
                item.CandidateIds = (await _mediator.Send(new GetCandidatesByTaskIdQuery(item.ID))).Data.ToList();

                item.ExternalMemberIds = (await _mediator.Send(new GetExternalMembersByTaskIdQuery(item.ID))).Data.ToList();
            }

            return RequestResult<PagingViewModel<GetAllTasksDTO>>.Success(model);
        }
    }
}
