using AutoMapper;
using EasyTask.Features.Common.TaskLogs.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.ProjectTaskLogs.GetAllTaskLogs
{
    public record GetAllTaskLogsResponseViewModel
   (string ID,string TaskName,
    string UserName,
    string Description,
    DateTime CreatedDate);
    public class GetAllTaskLogsResponseProfile : Profile
    {
        public GetAllTaskLogsResponseProfile()
        {
            CreateMap<GetAllTaskLogsDTO, GetAllTaskLogsResponseViewModel>();
        }
    }
}
