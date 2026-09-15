using AutoMapper;
using EasyTask.Features.TaskLogs.CreateTaskLog.Command;
using FluentValidation;

namespace EasyTask.Features.TaskLogs.CreateTaskLog
{
    public record CreateTaskLogRequestViewModel(string Description, string ProjectTaskId);
    public class CreateTaskLogRequestValidator : AbstractValidator<CreateTaskLogRequestViewModel>
    {
        public CreateTaskLogRequestValidator()
        {
        }
    }
    public class CreateTaskLogRequestProfile : Profile
    {
        public CreateTaskLogRequestProfile()
        {
            CreateMap<CreateTaskLogRequestViewModel, CreateTaskLogCommand>();
        }
    }
}
