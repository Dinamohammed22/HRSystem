using AutoMapper;
using EasyTask.Features.WorkPackages.EditWorkPackage.Commands;
using FluentValidation;

namespace EasyTask.Features.WorkPackages.EditWorkPackage
{
    public record EditWorkPackageRequestViewModel(
        string ID,
        string? Name,
        DateTime? StartDate, 
        DateTime? EndDate, 
        string? ProjectId
    );
    public class EditWorkPackageRequestValidator : AbstractValidator<EditWorkPackageRequestViewModel>
    {
        public EditWorkPackageRequestValidator()
        {

        }
    }
    public class EditWorkPackageRequestProfile : Profile
    {
        public EditWorkPackageRequestProfile()
        {
            CreateMap<EditWorkPackageRequestViewModel, EditWorkPackageCommand>();
        }
    }
}
