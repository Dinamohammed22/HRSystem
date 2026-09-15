using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.SubTasks;

namespace EasyTask.Features.Common.SubTasks.DTOs
{
    public class GetSubTaskByIdDTO
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
    public class GetSubTaskByIdDTOProfile : Profile
    {
        public GetSubTaskByIdDTOProfile()
        {
            CreateMap<SubTask, GetSubTaskByIdDTO>()
               .ForMember(src => src.ProjectTaskName, opt => opt.MapFrom(src => src.ProjectTask.Name))
                .ForMember(src => src.CandidateName, opt => opt.MapFrom(src => string.Concat(src.Candidate.FirstName, src.Candidate.LastName)));
        }
    }
}
