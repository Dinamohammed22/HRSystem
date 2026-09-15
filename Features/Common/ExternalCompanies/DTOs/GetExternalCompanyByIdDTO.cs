using AutoMapper;
using EasyTask.Models.ExternalComapnies;

namespace EasyTask.Features.Common.ExternalCompanies.DTOs
{
    public record GetExternalCompanyByIdDTO(string ID, string Name, string Location);
    public class GetExternalCompanyByIdDTOProfile : Profile
    {
        public GetExternalCompanyByIdDTOProfile()
        {
            CreateMap<ExternalCompany, GetExternalCompanyByIdDTO>();
        }
    }
}
