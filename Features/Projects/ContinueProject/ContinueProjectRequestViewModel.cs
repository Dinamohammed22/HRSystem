using AutoMapper;
using EasyTask.Features.Projects.ContinueProject.Commands;
using FluentValidation;

namespace EasyTask.Features.Projects.ContinueProject
{
    public record ContinueProjectRequestViewModel(string ID);
    public class ContinueProjectRequestValidator : AbstractValidator<ContinueProjectRequestViewModel>
    {
        public ContinueProjectRequestValidator()
        {
        }
    }
    public class ContinueProjectRequestProfile : Profile
    {
        public ContinueProjectRequestProfile()
        {
            CreateMap<ContinueProjectRequestViewModel, ContinueProjectCommand>();
        }
    }
}
