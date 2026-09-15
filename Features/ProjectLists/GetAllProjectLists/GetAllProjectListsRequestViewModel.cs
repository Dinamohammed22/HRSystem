using AutoMapper;
using EasyTask.Features.Common.ProjectLists.Queries;
using FluentValidation;

namespace EasyTask.Features.Positions.GetAllProjectLists
{
    public record GetAllProjectListsRequestViewModel(
        string ProjectId,
        string? WorkPackageId
    );
    public class GetAllProjectListsRequestValidator : AbstractValidator<GetAllProjectListsRequestViewModel>
    {
        public GetAllProjectListsRequestValidator()
        {
        }
    }
    public class GetAllProjectListsRequestProfile : Profile
    {
        public GetAllProjectListsRequestProfile()
        {
            CreateMap<GetAllProjectListsRequestViewModel, GetAllProjectListsQuery>();
        }
    }
}
