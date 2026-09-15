using AutoMapper;
using EasyTask.Features.Common.ExternalCompanies.Queries;
using FluentValidation;

namespace EasyTask.Features.ExternalCompanies.GetAllExternalCompanies
{
    public record GetAllExternalCompaniesRequestViewModel(string? Name, int pageIndex = 1, int pageSize = 100);
    public class GetAllExternalCompaniesRequestValidator : AbstractValidator<GetAllExternalCompaniesRequestViewModel>
    {
        public GetAllExternalCompaniesRequestValidator()
        {
        }
    }
    public class GetAllExternalCompaniesRequestProfile : Profile
    {
        public GetAllExternalCompaniesRequestProfile()
        {
            CreateMap<GetAllExternalCompaniesRequestViewModel, GetAllExternalCompaniesQuery>();
        }
    }
}
