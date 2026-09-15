using AutoMapper;
using EasyTask.Models.CandidateTasks;

namespace EasyTask.Features.Common.CandidateTasks.DTOs
{
    public class AssignCandidatesToTasksDTO
    {
        public string ProjectTaskId { get; set; }
        public List<string> CandidateIds { get; set; }
    }
    public class AssignCandidatesToTasksDTOProfile : Profile
    {
        public AssignCandidatesToTasksDTOProfile()
        {
            CreateMap<CandidateTask, AssignCandidatesToTasksDTO>();
        }
    }
}
