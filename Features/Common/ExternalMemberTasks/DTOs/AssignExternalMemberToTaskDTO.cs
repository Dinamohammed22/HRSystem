using AutoMapper;
using EasyTask.Models.ExternalMemberTasks;

namespace EasyTask.Features.Common.ExternalMemberTasks.DTOs
{
    public class AssignExternalMemberToTaskDTO
    {
        public string ProjectTaskId { get; set; }
        public List<string> ExternalMemberIds { get; set; }
    }
    public class AssignExternalMemberToTaskDTOProfile : Profile
    {
        public AssignExternalMemberToTaskDTOProfile()
        {
            CreateMap<ExternalMemberTask, AssignExternalMemberToTaskDTO>();
        }
    }
}
