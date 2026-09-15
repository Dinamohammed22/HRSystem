using AutoMapper;
using EasyTask.Features.Tasks.DeleteTaskLog.Commands;
using FluentValidation;

namespace EasyTask.Features.Tasks.DeleteTaskLog
{
    public record DeleteTaskLogRequestViewModel(string ID);
    public class DeleteTaskLogRequestValidator : AbstractValidator<DeleteTaskLogRequestViewModel>
    {
        public DeleteTaskLogRequestValidator()
        {
        }
    }
    public class DeleteTaskLogRequestProfile : Profile
    {
        public DeleteTaskLogRequestProfile()
        {
            CreateMap<DeleteTaskLogRequestViewModel, DeleteTaskLogCommand>();
        }
    }
}
