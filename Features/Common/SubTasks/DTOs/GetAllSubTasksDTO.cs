using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;
using EasyTask.Models.SubTasks;

namespace EasyTask.Features.Common.SubTasks.DTOs
{
    public class GetAllSubTasksDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string ProjectTaskId { get; set; }
        public string ProjectTaskName { get; set; }
        public SubTaskStatus SubTaskStatus { get; set; }
    }
    public class GetAllSubTasksDTOProfile : Profile
    {
        public GetAllSubTasksDTOProfile()
        {
            CreateMap<SubTask, GetAllSubTasksDTO>()
                .ForMember(src => src.ProjectTaskName, opt => opt.MapFrom(src => src.ProjectTask.Name))
                .ForMember(src => src.CandidateName, opt => opt.MapFrom(src => string.Concat( src.Candidate.FirstName , src.Candidate.LastName)));
        }
    }
}
