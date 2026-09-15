using AutoMapper;
using EasyTask.Features.ProjectLists.CreateProjectList.Command;
using FluentValidation;

namespace EasyTask.Features.ProjectLists.CreateProjectList
{
    public record CreateProjectListRequestViewModel(string Name, int Sequence, string ProjectId);
    public class CreateProjectListRequestValidator : AbstractValidator<CreateProjectListRequestViewModel>
    {
        public CreateProjectListRequestValidator()
        {
        }
    }
    public class CreateProjectListRequestProfile : Profile
    {
        public CreateProjectListRequestProfile()
        {
            CreateMap<CreateProjectListRequestViewModel, CreateProjectListCommand>();
        }
    }
}
