using AutoMapper;
using EasyTask.Features.RoleFeatures.AssignAllFeaturesToRole.Commands;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.RoleFeatures.AssignAllFeaturesToRole
{
    public record AssignAllFeaturesToRoleRequestViewModel(Role? RoleId);
    public class AssignAllFeaturesToRoleRequestValidator : AbstractValidator<AssignAllFeaturesToRoleRequestViewModel>
    {
        public AssignAllFeaturesToRoleRequestValidator()
        {
        }
    }
    public class AssignAllFeaturesToRoleRequestProfile : Profile
    {
        public AssignAllFeaturesToRoleRequestProfile()
        {
            CreateMap<AssignAllFeaturesToRoleRequestViewModel, AssignAllFeaturesToRoleCommand>();
        }
    }
}
