using AutoMapper;
using EasyTask.Features.Common.ProjectTasks.Queries;
using FluentValidation;

namespace EasyTask.Features.ProjectTasks.GetAllTasksByProjectId
{
    public record GetAllTasksByProjectIdRequestViewModel(
        string ProjectId,
        string? SearchText,
        int pageIndex = 1,
        int pageSize = 100
    );
    public class GetAllTasksByProjectIdRequestValidator : AbstractValidator<GetAllTasksByProjectIdRequestViewModel>
    {
        public GetAllTasksByProjectIdRequestValidator()
        {
        }
    }
    public class GetAllTasksByProjectIdRequestProfile : Profile
    {
        public GetAllTasksByProjectIdRequestProfile()
        {
            CreateMap<GetAllTasksByProjectIdRequestViewModel, GetAllTasksByProjectIdQuery>();
        }
    }
}
