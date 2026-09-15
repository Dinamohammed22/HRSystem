using AutoMapper;
using FluentValidation;
using EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster.Commands;

namespace EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster
{
    public record AddProjectScrumMasterRequestViewModel(string CandidateId, string ProjectId);
    public class AddProjectScrumMasterRequestValidator : AbstractValidator<AddProjectScrumMasterRequestViewModel>
    {
        public AddProjectScrumMasterRequestValidator() { }
    }
    public class AddProjectScrumMasterRequestProfile : Profile
    {
        public AddProjectScrumMasterRequestProfile() {
            CreateMap<AddProjectScrumMasterRequestViewModel, AddProjectScrumMasterCommand>();
        }
    }
}
