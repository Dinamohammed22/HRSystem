using AutoMapper;
using EasyProject.Features.CandidateProjects.AssignCandidateToProject.Commands;
using FluentValidation;

namespace EasyTask.Features.ProjectCandidates.AssignCandidateToProject
{
    public record AssignCandidateToProjectRequestViewModel(string ProjectId, string CandidateId);
    public class AssignCandidateToProjectRequestValidator : AbstractValidator<AssignCandidateToProjectRequestViewModel>
    {
        public AssignCandidateToProjectRequestValidator()
        {
        }
    }
    public class AssignCandidateToProjectRequestProfile : Profile
    {
        public AssignCandidateToProjectRequestProfile()
        {
            CreateMap<AssignCandidateToProjectRequestViewModel, AssignCandidateToProjectCommand>();
        }
    }
}
