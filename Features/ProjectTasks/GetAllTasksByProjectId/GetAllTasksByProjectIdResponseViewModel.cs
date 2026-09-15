using AutoMapper;
using EasyTask.Features.Common.ProjectTasks.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.ProjectTasks.GetAllTasksByProjectId
{
    public record GetAllTasksByProjectIdResponseViewModel(string ID,
    string Name,
    TaskPriority TaskPriority,
    DateTime StartDate,
    DateTime EndDate,
    string WorkPackageId,
    string WorkPackageName,
    List<Dependencies> Dependencies);
    public class GetAllTasksByProjectIdResponseProfile : Profile
    {
        public GetAllTasksByProjectIdResponseProfile()
        {
            CreateMap<GetAllTasksByProjectIdDTO, GetAllTasksByProjectIdResponseViewModel>();
        }
    }
}
