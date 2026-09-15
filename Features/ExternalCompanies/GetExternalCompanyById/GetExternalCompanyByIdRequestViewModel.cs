using AutoMapper;
using EasyTask.Features.Common.ExternalCompanies.Quereies;
using FluentValidation;

namespace EasyTask.Features.ExternalCompanies.GetExternalCompanyById
{
    public record GetExternalCompanyByIdRequestViewModel(string ID);
    public class GetExternalCompanyByIdRequestValidator : AbstractValidator<GetExternalCompanyByIdRequestViewModel>
    {
        public GetExternalCompanyByIdRequestValidator()
        {
        }
    }
    public class GetExternalCompanyByIdRequestProfile : Profile
    {
        public GetExternalCompanyByIdRequestProfile()
        {
            CreateMap<GetExternalCompanyByIdRequestViewModel, GetExternalCompanyByIdQuery>();
        }
    }
}
