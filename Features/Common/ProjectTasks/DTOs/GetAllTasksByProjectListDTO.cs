using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.Common.ProjectTasks.DTOs
{
    public class GetAllTasksByProjectListDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public TaskPriority TaskPriority { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string WorkPackageId { get; set; }
        public string WorkPackageName { get; set; }

    }
    public class GetAllTasksByProjectListDTOProfile : Profile
    {
        public GetAllTasksByProjectListDTOProfile()
        {
            CreateMap<ProjectTask, GetAllTasksByProjectListDTO>()
                .ForMember(d => d.WorkPackageName,o => o.MapFrom(s => s.WorkPackage.Name));
        }
    }
}
