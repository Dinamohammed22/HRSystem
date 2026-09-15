using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.ProjectTypes.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectTypes.ProjectTypeSelectList
{
    public class ProjectTypeSelectListEndpoint : EndpointBase<ProjectTypeSelectListRequestViewModel, ProjectTypeSelectListResponseViewModel>
    {
        public ProjectTypeSelectListEndpoint(EndpointBaseParameters<ProjectTypeSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ProjectTypeSelectList })]
        public async Task<EndPointResponse<IEnumerable<ProjectTypeSelectListResponseViewModel>>> ProjectTypeSelectList([FromQuery] ProjectTypeSelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<ProjectTypeSelectListQuery>());

            var response = result.Data.MapList<ProjectTypeSelectListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<ProjectTypeSelectListResponseViewModel>>.Success(response, "Project Lists got successfully.");
            else
                return EndPointResponse<IEnumerable<ProjectTypeSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
