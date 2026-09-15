using AutoMapper;
using EasyTask.Features.Common.ExternalCompanies.Quereies;
using FluentValidation;

namespace EasyTask.Features.ExternalCompanies.ExternalCompanySelectList
{
    public record ExternalCompanySelectListRequestViewModel();
    public class ExternalCompanySelectListRequestValidator : AbstractValidator<ExternalCompanySelectListRequestViewModel>
    {
        public ExternalCompanySelectListRequestValidator()
        {
        }
    }
    public class ExternalCompanySelectListRequestProfile : Profile
    {
        public ExternalCompanySelectListRequestProfile()
        {
            CreateMap<ExternalCompanySelectListRequestViewModel, ExternalCompanySelectListQuery>();
        }
    }
}
