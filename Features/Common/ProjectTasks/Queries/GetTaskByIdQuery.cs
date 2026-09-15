using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.ProjectTasks.DTOs;
using EasyTask.Features.Common.TaskDependencies.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.ProjectTasks;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Tasks.Queries
{
    public record GetTaskByIdQuery(string ID):IRequestBase<GetTaskByIdDTO>;
    public class GetTaskByIdQueryHandler : RequestHandlerBase<ProjectTask, GetTaskByIdQuery, GetTaskByIdDTO>
    {
        public GetTaskByIdQueryHandler(RequestHandlerBaseParameters<ProjectTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetTaskByIdDTO>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var dto = await _repository.Get(x => x.ID == request.ID)
         .Select(task => new GetTaskByIdDTO
         {
             ID = task.ID,
             Name = task.Name,
             TaskPriority = task.TaskPriority,
             StartDate = task.StartDate,
             EndDate = task.EndDate,
             WorkPackageId = task.WorkPackageId,
             WorkPackageName = task.WorkPackage.Name,
             TaskDependencyDTOs = task.OutgoingDependencies
                 .Select(d => new GetAllTaskDependencyDTO
                 {
                     DependencyType = d.DependencyType,
                     SourceTaskId = d.SourceTaskId,
                     SourceTaskName = d.SourceTask != null ? d.SourceTask.Name : null,
                     DestinationTaskId = d.DestinationTaskId,
                     DestinationTaskName = d.DestinationTask != null ? d.DestinationTask.Name : null
                 })
                 .ToList()
         })
         .FirstOrDefaultAsync();
            return RequestResult<GetTaskByIdDTO>.Success(dto);
        }
    }
}
