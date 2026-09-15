using AutoMapper;
using EasyTask.Features.Common.ProjectTasks.DTOs;
using EasyTask.Models.ProjectLists;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.Common.ProjectLists.DTOs
{
    public class GetAllProjectListsDTO
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public int Sequence { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public List<GetAllTasksByProjectListDTO> Tasks { get; set; }
    }

    public class GetAllProjectListsDTOProfile : Profile
    {
        public GetAllProjectListsDTOProfile()
        {
            CreateMap<ProjectList, GetAllProjectListsDTO>()
                            .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project.Name))
                            .ForMember(d => d.Tasks, o => o.MapFrom(s => s.ProjectTasks));
        }
    }
}
