using AutoMapper;
using EasyTask.Features.ProjectTasks.DeleteWorkPackage.Orchestrators;
using EasyTask.Features.Tasks.DeleteWorkPackage.Commands;
using FluentValidation;

namespace EasyWorkPackage.Features.WorkPackages.DeleteWorkPackage
{
    public record DeleteWorkPackageRequestViewModel(string ID);
    public class DeleteWorkPackageRequestValidator : AbstractValidator<DeleteWorkPackageRequestViewModel>
    {
        public DeleteWorkPackageRequestValidator()
        {
        }
    }
    public class DeleteWorkPackageRequestProfile : Profile
    {
        public DeleteWorkPackageRequestProfile()
        {
            CreateMap<DeleteWorkPackageRequestViewModel, DeleteWorkPackageOrchestrators>();
            CreateMap<DeleteWorkPackageOrchestrators, DeleteWorkPackageCommand>();
        }
    }
}
