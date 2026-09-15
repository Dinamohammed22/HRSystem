using AutoMapper;
using EasyTask.Features.WorkPackageDependencies.EditWorkPackageDependency.Command;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.WorkPackageDependencies.EditWorkPackageDependency
{
    public record EditWorkPackageDependencyRequestViewModel(
        Dependencies DependencyType,
        string SourceWorkPackageId,
        string DestinationWorkPackageId
    );
    public class EditWorkPackageDependencyRequestValidator : AbstractValidator<EditWorkPackageDependencyRequestViewModel>
    {
        public EditWorkPackageDependencyRequestValidator()
        {
        }
    }
    public class EditWorkPackageDependencyRequestProfile : Profile
    {
        public EditWorkPackageDependencyRequestProfile()
        {
            CreateMap<EditWorkPackageDependencyRequestViewModel, EditWorkPackageDependencyCommand>();
        }
    }
}
