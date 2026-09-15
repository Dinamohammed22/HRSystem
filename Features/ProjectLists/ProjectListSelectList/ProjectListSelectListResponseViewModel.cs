using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.ProjectLists.ProjectListSelectList
{
    public record ProjectListSelectListResponseViewModel(string Name, string ID);
    public class ProjectListSelectListResponseProfile : Profile
    {
        public ProjectListSelectListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, ProjectListSelectListResponseViewModel>();
        }
    }
}
