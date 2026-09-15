using AutoMapper;
using EasyTask.Features.Common.TaskDependencies.DTOs;
using EasyTask.Features.SubTasks.CreateSubTask.Commands;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.SubTasks.CreateSubTask
{
    public record CreateSubTaskRequestViewModel(string Name,
        DateTime StartDate,
        DateTime EndDate,
        string ProjectTaskId,
        string CandidateId,
        SubTaskStatus SubTaskStatus);
    public class CreateSubTaskRequestValidator : AbstractValidator<CreateSubTaskRequestViewModel>
    {
        public CreateSubTaskRequestValidator()
        {
        }
    }
    public class CreateSubTaskRequestProfile : Profile
    {
        public CreateSubTaskRequestProfile()
        {
            CreateMap<CreateSubTaskRequestViewModel, CreateSubTaskCommand>();
        }
    }
}
