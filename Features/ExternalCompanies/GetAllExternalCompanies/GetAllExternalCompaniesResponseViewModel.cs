using AutoMapper;
using EasyTask.Features.Common.ExternalCompanies.DTOs;

namespace EasyTask.Features.ExternalCompanies.GetAllExternalCompanies
{
    public record GetAllExternalCompaniesResponseViewModel(string ID, string Name, string Location);
    public class GetAllExternalCompaniesResponseProfile : Profile
    {
        public GetAllExternalCompaniesResponseProfile()
        {
            CreateMap<GetExternalCompanyByIdDTO, GetAllExternalCompaniesResponseViewModel>();
        }
    }
}
