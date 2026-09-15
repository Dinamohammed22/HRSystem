using AutoMapper;
using EasyTask.Features.Common.Projects.Queries;
using FluentValidation;

namespace EasyTask.Features.Projects.ProjectSelectList
{
    public record ProjectSelectListRequestViewModel();
    public class ProjectSelectListRequestValidator : AbstractValidator<ProjectSelectListRequestViewModel>
    {
        public ProjectSelectListRequestValidator()
        {
        }
    }
    public class ProjectSelectListRequestProfile : Profile
    {
        public ProjectSelectListRequestProfile()
        {
            CreateMap<ProjectSelectListRequestViewModel, ProjectSelectListQuery>();
        }
    }
}
