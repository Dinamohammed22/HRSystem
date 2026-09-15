using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.Projects.ProjectSelectList
{
    public record ProjectSelectListResponseViewModel(string Name, string ID);
    public class ProjectSelectListResponseProfile : Profile
    {
        public ProjectSelectListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, ProjectSelectListResponseViewModel>();
        }
    }
}
