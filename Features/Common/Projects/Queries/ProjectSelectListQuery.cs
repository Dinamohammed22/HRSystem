using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.Projects;

namespace EasyTask.Features.Common.Projects.Queries
{
    public record ProjectSelectListQuery():IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class ProjectSelectListQueryHandler : RequestHandlerBase<Project, ProjectSelectListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public ProjectSelectListQueryHandler(RequestHandlerBaseParameters<Project> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(ProjectSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get().ToSelectListViewModel();

            if (selectListItems == null || !selectListItems.Any())
            {
                return RequestResult<IEnumerable<SelectListItemViewModel>>
                    .Failure(ErrorCode.NotFound,"No Projects found.");
            }
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
