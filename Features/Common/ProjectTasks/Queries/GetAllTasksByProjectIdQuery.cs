using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidateTasks.Queries;
using EasyTask.Features.Common.ExternalMemberTasks.Queries;
using EasyTask.Features.Common.ProjectTasks.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.ProjectTasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.ProjectTasks.Queries
{
    public record GetAllTasksByProjectIdQuery(
        string ProjectId,
        string? SearchText,
        int pageIndex = 1,
        int pageSize = 100
    ) : IRequestBase<PagingViewModel<GetAllTasksByProjectIdDTO>>;
    public class GetAllTasksByProjectIdQueryHandler : RequestHandlerBase<ProjectTask, GetAllTasksByProjectIdQuery, PagingViewModel<GetAllTasksByProjectIdDTO>>
    {
        public GetAllTasksByProjectIdQueryHandler(RequestHandlerBaseParameters<ProjectTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllTasksByProjectIdDTO>>> Handle(GetAllTasksByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<ProjectTask>(true);
            predicate = predicate.And(t =>
                string.IsNullOrWhiteSpace(request.SearchText) ||
                t.Name.Contains(request.SearchText) ||
                (t.WorkPackage != null && t.WorkPackage.Name.Contains(request.SearchText)));
            var model = await _repository.Get(predicate).Where(s => s.ProjectId == request.ProjectId)
                .Include(x => x.WorkPackage)
                .Include(x => x.OutgoingDependencies).Include(x => x.IncomingDependencies).Map<GetAllTasksByProjectIdDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            foreach (var item in model.Items)
            {
                var task = await _repository.Get(x => x.ID == item.ID)
                    .Include(x => x.OutgoingDependencies)
                    .Include(x => x.IncomingDependencies)
                    .FirstOrDefaultAsync();

                item.Dependencies = task.OutgoingDependencies
                    .Select(x => x.DependencyType)
                    .Concat(task.IncomingDependencies.Select(x => x.DependencyType))
                    .ToList();
            }

            return RequestResult<PagingViewModel<GetAllTasksByProjectIdDTO>>.Success(model);
        }
    }
}
