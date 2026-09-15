using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.TaskLogs;

namespace EasyTask.Features.Common.TaskLogs.DTOs
{
    public class GetAllTaskLogsDTO
    {
        public string ID { get; set; }
        public string TaskName { get; set; }
        public string UserName { get; set; }
        public string Description {  get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class GetAllTaskLogsDTOProfile : Profile
    {
        public GetAllTaskLogsDTOProfile()
        {
            CreateMap<TaskLog, GetAllTaskLogsDTO>()
                .ForMember(dest => dest.TaskName,
                    opt => opt.MapFrom(src => src.ProjectTask != null ? src.ProjectTask.Name : null))

                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.User != null ? src.User.Name : null))

                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description))

                .ForMember(dest => dest.ID,
                    opt => opt.MapFrom(src => src.ID))

                .ForMember(dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => src.CreatedDate));
        }
    }
}
