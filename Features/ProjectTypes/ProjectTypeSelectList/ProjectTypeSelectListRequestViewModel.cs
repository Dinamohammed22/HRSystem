using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.ProjectTypes.Queries;

namespace EasyTask.Features.ProjectTypes.ProjectTypeSelectList
{
    public record ProjectTypeSelectListRequestViewModel();
    public class ProjectTypeSelectListRequestValidator : AbstractValidator<ProjectTypeSelectListRequestViewModel>
    {
        public ProjectTypeSelectListRequestValidator() { }
    }
    public class ProjectTypeSelectListRequestProfile : Profile
    {
        public ProjectTypeSelectListRequestProfile() {
            CreateMap<ProjectTypeSelectListRequestViewModel, ProjectTypeSelectListQuery>();
        }
    }
}
