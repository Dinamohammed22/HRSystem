using AutoMapper;
using EasyTask.Features.CandidateTasks.AssignCandidatesToTasks.Orchestrators;
using EasyTask.Features.Common.CandidateTasks.DTOs;
using EasyTask.Features.Common.ExternalMemberTasks.DTOs;
using FluentValidation;

namespace EasyTask.Features.CandidateTasks.AssignCandidatesToTasks
{
    public record AssignCandidatesToTasksRequestViewModel(List<AssignCandidatesToTasksDTO> AssignCandidatesToTasks,
        List<AssignExternalMemberToTaskDTO> AssignExternalMemberToTask);
    public class AssignCandidatesToTasksRequestValidator : AbstractValidator<AssignCandidatesToTasksRequestViewModel>
    {
        public AssignCandidatesToTasksRequestValidator()
        {
        }
    }
    public class AssignCandidatesToTasksRequestProfile : Profile
    {
        public AssignCandidatesToTasksRequestProfile()
        {
            CreateMap<AssignCandidatesToTasksRequestViewModel, AssignCandidatesToTasksOrchestrator>();
        }
    }
}
