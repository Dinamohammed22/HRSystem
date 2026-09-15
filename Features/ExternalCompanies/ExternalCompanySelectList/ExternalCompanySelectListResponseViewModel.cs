using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.ExternalCompanies.ExternalCompanySelectList
{
    public record ExternalCompanySelectListResponseViewModel(string Name, string ID);
    public class ExternalCompanySelectListResponseProfile : Profile
    {
        public ExternalCompanySelectListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, ExternalCompanySelectListResponseViewModel>();
        }
    }
}
