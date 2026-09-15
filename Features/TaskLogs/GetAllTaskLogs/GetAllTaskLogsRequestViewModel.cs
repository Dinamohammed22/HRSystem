using AutoMapper;
using EasyTask.Features.Common.TaskLogsLogs.Queries;
using FluentValidation;

namespace EasyTask.Features.ProjectTaskLogs.GetAllTaskLogs
{
    public record GetAllTaskLogsRequestViewModel(
        DateOnly? From,
        DateOnly? TO,
        string? TaskId,
        int pageIndex = 1,
        int pageSize = 100
    );
    public class GetAllTaskLogsRequestValidator : AbstractValidator<GetAllTaskLogsRequestViewModel>
    {
        public GetAllTaskLogsRequestValidator()
        {
        }
    }
    public class GetAllTaskLogsRequestProfile : Profile
    {
        public GetAllTaskLogsRequestProfile()
        {
            CreateMap<GetAllTaskLogsRequestViewModel, GetAllTaskLogsQuery>();
        }
    }
}
