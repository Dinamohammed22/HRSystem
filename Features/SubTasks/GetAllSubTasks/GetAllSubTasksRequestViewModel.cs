using AutoMapper;
using EasyTask.Features.Common.SubTasks.Queries;
using FluentValidation;

namespace EasyTask.Features.SubTasks.GetAllSubTasks
{
    public record GetAllSubTasksRequestViewModel(
        string? ProjectTaskId,
        int pageIndex = 1,
        int pageSize = 100
        );
    public class GetAllSubTasksRequestValidator : AbstractValidator<GetAllSubTasksRequestViewModel>
    {
        public GetAllSubTasksRequestValidator()
        {
        }
    }
    public class GetAllSubTasksRequestProfile : Profile
    {
        public GetAllSubTasksRequestProfile()
        {
            CreateMap<GetAllSubTasksRequestViewModel, GetAllSubTasksQuery>();
        }
    }
}
