using AutoMapper;
using EasyTask.Features.Common.SubTasks.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.SubTasks.GetAllSubTasks
{
    public class GetAllSubTasksResponseViewModel
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
    public class GetAllSubTasksResponseProfile : Profile
    {
        public GetAllSubTasksResponseProfile()
        {
            CreateMap<GetAllSubTasksDTO, GetAllSubTasksResponseViewModel>();
        }
    }
}
