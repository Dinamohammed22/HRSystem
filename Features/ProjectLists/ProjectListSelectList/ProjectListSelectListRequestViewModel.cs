using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.ProjectLists.Queries;

namespace EasyTask.Features.ProjectLists.ProjectListSelectList
{
    public record ProjectListSelectListRequestViewModel(string? ProjectId);
    public class ProjectListSelectListRequestValidator : AbstractValidator<ProjectListSelectListRequestViewModel>
    {
        public ProjectListSelectListRequestValidator() { }
    }
    public class ProjectListSelectListRequestProfile : Profile
    {
        public ProjectListSelectListRequestProfile() {
            CreateMap<ProjectListSelectListRequestViewModel, ProjectListSelectListQuery>();
        }
    }
}
