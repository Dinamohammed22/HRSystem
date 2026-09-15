using AutoMapper;
using EasyTask.Features.Common.WorkPackages.Quereies;
using FluentValidation;

namespace EasyTask.Features.WorkPackages.GetWorkPackageById
{
    public record GetWorkPackageByIdRequestViewModel(string ID);
    public class GetWorkPackageByIdRequestValidator : AbstractValidator<GetWorkPackageByIdRequestViewModel>
    {
        public GetWorkPackageByIdRequestValidator()
        {
        }
    }
    public class GetWorkPackageByIdRequestProfile : Profile
    {
        public GetWorkPackageByIdRequestProfile()
        {
            CreateMap<GetWorkPackageByIdRequestViewModel, GetWorkPackageByIdQuery>();
        }
    }
}
