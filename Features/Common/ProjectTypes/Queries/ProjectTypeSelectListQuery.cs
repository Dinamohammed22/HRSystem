using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.ProjectTypes;

namespace EasyTask.Features.Common.ProjectTypes.Queries
{
    public record ProjectTypeSelectListQuery() :IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class ProjectTypeSelectListQueryHandler : RequestHandlerBase<ProjectType, ProjectTypeSelectListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public ProjectTypeSelectListQueryHandler(RequestHandlerBaseParameters<ProjectType> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(ProjectTypeSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get().ToSelectListViewModel();
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
