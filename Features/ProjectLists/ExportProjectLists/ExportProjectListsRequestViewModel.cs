using AutoMapper;
using EasyTask.Features.Common.ProjectLists.Queries;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.ProjectLists.ExportProjectLists
{
    public record ExportProjectListsRequestViewModel(string ProjectId,
        string? WorkPackageId);
    public class ExportProjectListsRequestValidator : AbstractValidator<ExportProjectListsRequestViewModel>
    {
        public ExportProjectListsRequestValidator()
        {
        }
    }
    public class ExportProjectListsRequestProfile : Profile
    {
        public ExportProjectListsRequestProfile()
        {
            CreateMap<ExportProjectListsRequestViewModel, ExportProjectListsQuery>();
        }
    }
}
