using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Projects.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Projects.ProjectSelectList
{
    public class ProjectSelectListEndpoint : EndpointBase<ProjectSelectListRequestViewModel, ProjectSelectListResponseViewModel>
    {
        public ProjectSelectListEndpoint(EndpointBaseParameters<ProjectSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ProjectSelectList })]
        public async Task<EndPointResponse<IEnumerable<ProjectSelectListResponseViewModel>>> ProjectSelectList([FromQuery] ProjectSelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<ProjectSelectListQuery>());

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<ProjectSelectListResponseViewModel>>.Success(result.Data.MapList<ProjectSelectListResponseViewModel>(), "Projects got successfully.");
            else
                return EndPointResponse<IEnumerable<ProjectSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
