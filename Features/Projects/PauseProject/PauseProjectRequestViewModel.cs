using AutoMapper;
using EasyTask.Features.Projects.PauseProject.Commands;
using FluentValidation;

namespace EasyTask.Features.Projects.PauseProject
{
    public record PauseProjectRequestViewModel(string ID, string? PauseReason);
    public class PauseProjectRequestValidator : AbstractValidator<PauseProjectRequestViewModel>
    {
        public PauseProjectRequestValidator()
        {
        }
    }
    public class PauseProjectRequestProfile : Profile
    {
        public PauseProjectRequestProfile()
        {
            CreateMap<PauseProjectRequestViewModel, PauseProjectCommand>();
        }
    }
}
