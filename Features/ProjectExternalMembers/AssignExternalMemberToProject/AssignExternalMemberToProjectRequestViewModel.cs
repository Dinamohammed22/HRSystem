using AutoMapper;
using EasyProject.Features.ExternalMemberProjects.AssignExternalMemberToProject.Commands;
using FluentValidation;

namespace EasyTask.Features.ProjectExternalMembers.AssignExternalMemberToProject
{
    public record AssignExternalMemberToProjectRequestViewModel(string ProjectId, string ExternalMemberId);
    public class AssignExternalMemberToProjectRequestValidator : AbstractValidator<AssignExternalMemberToProjectRequestViewModel>
    {
        public AssignExternalMemberToProjectRequestValidator()
        {
        }
    }
    public class AssignExternalMemberToProjectRequestProfile : Profile
    {
        public AssignExternalMemberToProjectRequestProfile()
        {
            CreateMap<AssignExternalMemberToProjectRequestViewModel, AssignExternalMemberToProjectCommand>();
        }
    }
}
