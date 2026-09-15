using AutoMapper;
using EasyTask.Features.ProjectStakeholders.AddProjectStakeholder.Command;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.ProjectStakeholders.AddProjectStakeholder
{
    public record AddProjectStakeholderRequestViewModel(string StakeholderId, StakeholderType StakeholderType,
        StakeholderRole Role, string ProjectId);
    public class AddProjectStakeholderRequestValidator : AbstractValidator<AddProjectStakeholderRequestViewModel>
    {
        public AddProjectStakeholderRequestValidator()
        {
            RuleFor(x => x.StakeholderId)
            .NotEmpty()
            .WithMessage("StakeholderId is required.");

            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .WithMessage("ProjectId is required.");

            RuleFor(x => x.StakeholderType)
                .IsInEnum()
                .WithMessage("Invalid StakeholderType.");

            RuleFor(x => x.StakeholderType)
                .NotNull()
                .WithMessage("StakeholderType is required.");

            RuleFor(x => x.Role)
                .IsInEnum()
                .WithMessage("Invalid StakeholderRole.");

            RuleFor(x => x.Role)
                .NotNull()
                .WithMessage("StakeholderRole is required.");
        }
    }
    public class AddProjectStakeholderRequestProfile : Profile
    {
        public AddProjectStakeholderRequestProfile()
        {
            CreateMap<AddProjectStakeholderRequestViewModel, AddProjectStakeholderCommand>();
        }
    }
}
