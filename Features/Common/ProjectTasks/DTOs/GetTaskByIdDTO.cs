using AutoMapper;
using EasyTask.Features.Common.TaskDependencies.DTOs;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.Common.ProjectTasks.DTOs
{
    public class GetTaskByIdDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public TaskPriority TaskPriority { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string WorkPackageId { get; set; }
        public string WorkPackageName { get; set; }
        public List<GetAllTaskDependencyDTO> TaskDependencyDTOs { get; set; }

    }
    public class GetTaskByIdDTOProfile : Profile
    {
        public GetTaskByIdDTOProfile()
        {
            CreateMap<ProjectTask, GetTaskByIdDTO>()
                .ForMember(d => d.WorkPackageName,
                    o => o.MapFrom(s => s.WorkPackage.Name))
                .ForMember(d => d.TaskDependencyDTOs,
                    o => o.MapFrom(s => s.OutgoingDependencies));
        }
    }
}
