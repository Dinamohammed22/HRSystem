using AutoMapper;
using EasyTask.Features.Common.ExternalCompanies.DTOs;

namespace EasyTask.Features.ExternalCompanies.GetExternalCompanyById
{
    public record GetExternalCompanyByIdResponseViewModel(string ID, string Name, string Location);
    public class GetExternalCompanyByIdResponseProfile : Profile
    {
        public GetExternalCompanyByIdResponseProfile()
        {
            CreateMap<GetExternalCompanyByIdDTO, GetExternalCompanyByIdResponseViewModel>();
        }
    }
}
