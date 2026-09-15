using AutoMapper;
using EasyTask.Features.Common.ProjectTasks.DTOs;
using EasyTask.Features.Common.TaskDependencies.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Tasks.GetTaskById
{
    public record GetTaskByIdResponseViewModel(string ID,
    string Name,
    TaskPriority TaskPriority,
    DateTime StartDate,
    DateTime EndDate,
    string WorkPackageId,
    string WorkPackageName,
    List<GetAllTaskDependencyDTO> TaskDependencyDTOs);
    public class GetTaskByIdResponseProfile : Profile
    {
        public GetTaskByIdResponseProfile()
        {
            CreateMap<GetTaskByIdDTO, GetTaskByIdResponseViewModel>();
        }
    }
}
