using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.ProjectLists.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectLists.ProjectListSelectList
{
    public class ProjectListSelectListEndpoint : EndpointBase<ProjectListSelectListRequestViewModel, ProjectListSelectListResponseViewModel>
    {
        public ProjectListSelectListEndpoint(EndpointBaseParameters<ProjectListSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ProjectListSelectList })]
        public async Task<EndPointResponse<IEnumerable<ProjectListSelectListResponseViewModel>>> ProjectListSelectList([FromQuery] ProjectListSelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<ProjectListSelectListQuery>());

            var response = result.Data.MapList<ProjectListSelectListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<ProjectListSelectListResponseViewModel>>.Success(response, "Project Lists got successfully.");
            else
                return EndPointResponse<IEnumerable<ProjectListSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
