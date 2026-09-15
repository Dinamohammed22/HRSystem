using AutoMapper;
using EasyTask.Features.Common.WorkPackages.DTOs;
using FluentValidation;

namespace EasyTask.Features.WorkPackages.GetAllWorkPackages
{
    public record GetAllWorkPackagesRequestViewModel(string? ProjectId, string? SearchText, int pageIndex = 1, int pageSize = 100);
    public class GetAllWorkPackagesRequestValidator : AbstractValidator<GetAllWorkPackagesRequestViewModel>
    {
        public GetAllWorkPackagesRequestValidator()
        {
        }
    }
    public class GetAllWorkPackagesRequestProfile : Profile
    {
        public GetAllWorkPackagesRequestProfile()
        {
            CreateMap<GetAllWorkPackagesRequestViewModel, GetAllWorkPackagesQuery>();
        }
    }
}
