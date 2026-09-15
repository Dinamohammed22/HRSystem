using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.Common.ProjectTasks.DTOs
{
    public class GetAllTasksByProjectIdDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public TaskPriority TaskPriority { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string WorkPackageId { get; set; }
        public string WorkPackageName { get; set; }
        public List<Dependencies> Dependencies { get; set; }

    }
    public class GetAllTasksByProjectIdDTOProfile : Profile
    {
        public GetAllTasksByProjectIdDTOProfile()
        {
            CreateMap<ProjectTask, GetAllTasksByProjectIdDTO>()
     .ForMember(d => d.WorkPackageName,
         o => o.MapFrom(s => s.WorkPackage.Name))
     .ForMember(d => d.Dependencies,
         o => o.Ignore());
        }
    }
}
