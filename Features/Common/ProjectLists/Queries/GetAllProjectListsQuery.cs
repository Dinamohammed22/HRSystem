using EasyTask.Common.Requests;
using EasyTask.Features.Common.ProjectLists.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.ProjectLists;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.ProjectLists.Queries
{
    public record GetAllProjectListsQuery(
        string ProjectId,
        string ? WorkPackageId
    ) : IRequestBase<List<GetAllProjectListsDTO>>;

    public class GetAllProjectListsQueryHandler: RequestHandlerBase<ProjectList, GetAllProjectListsQuery, List<GetAllProjectListsDTO>>
    {
        public GetAllProjectListsQueryHandler(RequestHandlerBaseParameters<ProjectList> requestParameters): base(requestParameters)
        {
        }

        public override async Task<RequestResult<List<GetAllProjectListsDTO>>> Handle(GetAllProjectListsQuery request,CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<ProjectList>(true);
            predicate = predicate.And(pl => pl.ProjectId == request.ProjectId);

            var projectLists = await _repository
                .Get(predicate)
                .Include(pl => pl.Project)
                .Include(pl => pl.ProjectTasks
                    .Where(t => request.WorkPackageId == null || t.WorkPackageId == request.WorkPackageId))
                    .ThenInclude(t => t.WorkPackage)
                .OrderBy(pl => pl.Sequence)
                .ToListAsync(cancellationToken);

            var result = projectLists.MapOne<List<GetAllProjectListsDTO>>();

            // Order tasks inside each project list by TaskPriority
            foreach (var plDto in result)
            {
                plDto.Tasks = plDto.Tasks
                    .OrderBy(t => t.TaskPriority)
                    .ToList();
            }

            return RequestResult<List<GetAllProjectListsDTO>>.Success(result);
        }

    }


}
