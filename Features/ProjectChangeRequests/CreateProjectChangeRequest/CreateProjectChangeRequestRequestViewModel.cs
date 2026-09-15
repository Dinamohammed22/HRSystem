using AutoMapper;
using EasyTask.Features.ProjectChangeRequests.CreateProjectChangeRequest.Commands;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.ProjectChangeRequests.CreateProjectChangeRequest
{
    public record CreateProjectChangeRequestRequestViewModel(string? CandidateId, string ProjectChangeReason, string ProjectId,
        ProjectChangeType ProjectChangeType, ProjectChangeImpact ProjectChangeImpact);
    public class CreateProjectChangeRequestRequestValidator : AbstractValidator<CreateProjectChangeRequestRequestViewModel>
    {
        public CreateProjectChangeRequestRequestValidator()
        {
        }
    }
    public class CreateProjectChangeRequestRequestProfile : Profile
    {
        public CreateProjectChangeRequestRequestProfile()
        {
            CreateMap<CreateProjectChangeRequestRequestViewModel, CreateProjectChangeRequestCommand>();
        }
    }
}
