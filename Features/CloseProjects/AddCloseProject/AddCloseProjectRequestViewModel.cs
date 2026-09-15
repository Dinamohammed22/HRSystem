using AutoMapper;
using EasyTask.Features.CloseProjects.AddCloseProject.Commands;
using EasyTask.Features.Projects.AddCloseProject.Orchestrator;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.CloseProjects.AddCloseProject
{
    public record AddCloseProjectRequestViewModel(string? CandidateId, string ProjectId, string ProjectCloseReason, int CloseDuration
        , bool HasCloseImpact, string InternalCloseReason, string ExternalCloseReason);
    public class AddCloseProjectRequestValidator : AbstractValidator<AddCloseProjectRequestViewModel>
    {
        public AddCloseProjectRequestValidator()
        {
        }
    }
    public class AddCloseProjectRequestProfile : Profile
    {
        public AddCloseProjectRequestProfile()
        {
            CreateMap<AddCloseProjectRequestViewModel, AddCloseProjectOrchestrator>();
            CreateMap<AddCloseProjectOrchestrator, AddCloseProjectCommand>();
        }
    }
}
