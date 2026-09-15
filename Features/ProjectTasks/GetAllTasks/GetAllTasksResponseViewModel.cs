using AutoMapper;
using EasyTask.Features.Common.ProjectTasks.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.ProjectTasks.GetAllTasks
{
    public record GetAllTasksResponseViewModel
    (string ID, string Name, TaskPriority TaskPriority, DateTime StartDate, DateTime EndDate,
        List<string> CandidateIds, List<string> ExternalMemberIds);
    public class GetAllTasksResponseProfile : Profile
    {
        public GetAllTasksResponseProfile()
        {
            CreateMap<GetAllTasksDTO, GetAllTasksResponseViewModel>();
        }
    }
}
