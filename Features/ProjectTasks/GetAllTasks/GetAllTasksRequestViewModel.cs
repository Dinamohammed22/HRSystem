using AutoMapper;
using EasyTask.Features.Common.ProjectTasks.Queries;
using FluentValidation;

namespace EasyTask.Features.ProjectTasks.GetAllTasks
{
    public record GetAllTasksRequestViewModel(
        DateOnly? From,
        DateOnly? TO,
        string? ProjectId,
        int pageIndex = 1,
        int pageSize = 100
    );
    public class GetAllTasksRequestValidator : AbstractValidator<GetAllTasksRequestViewModel>
    {
        public GetAllTasksRequestValidator()
        {
        }
    }
    public class GetAllTasksRequestProfile : Profile
    {
        public GetAllTasksRequestProfile()
        {
            CreateMap<GetAllTasksRequestViewModel, GetAllTasksQuery>();
        }
    }
}
