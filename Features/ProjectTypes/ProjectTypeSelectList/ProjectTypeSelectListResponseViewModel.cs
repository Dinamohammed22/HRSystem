using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.ProjectTypes.ProjectTypeSelectList
{
    public record ProjectTypeSelectListResponseViewModel(string Name, string ID);
    public class ProjectTypeSelectListResponseProfile : Profile
    {
        public ProjectTypeSelectListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, ProjectTypeSelectListResponseViewModel>();
        }
    }
}
