using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.Common.ProjectTasks.DTOs
{
    public class GetAllTasksDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> CandidateIds { get; set; }
        public List<string> ExternalMemberIds { get; set; }
    }
    public class GetAllTasksDTOProfile : Profile
    {
        public GetAllTasksDTOProfile()
        {
            CreateMap<ProjectTask, GetAllTasksDTO>();
        }
    }
}
