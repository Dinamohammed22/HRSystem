using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.ProjectLists;

namespace EasyTask.Features.Common.ProjectLists.Queries
{
    public record ProjectListSelectListQuery(string? ProjectId) :IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class ProjectListSelectListQueryHandler : RequestHandlerBase<ProjectList, ProjectListSelectListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public ProjectListSelectListQueryHandler(RequestHandlerBaseParameters<ProjectList> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(ProjectListSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get(x => string.IsNullOrEmpty(request.ProjectId) || x.ProjectId == request.ProjectId).ToSelectListViewModel();
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
