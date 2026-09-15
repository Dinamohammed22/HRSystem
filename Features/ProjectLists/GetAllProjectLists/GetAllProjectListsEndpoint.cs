using EasyTask.Common.Endpoints;
using EasyTask.Common.Views;
using EasyTask.Features.Common.ProjectLists.DTOs;
using EasyTask.Features.Common.ProjectLists.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Positions.GetAllProjectLists
{
    public class GetAllProjectListsEndpoint : EndpointBase<GetAllProjectListsRequestViewModel, GetAllProjectListsResponseViewModel>
    {
        public GetAllProjectListsEndpoint(EndpointBaseParameters<GetAllProjectListsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllProjectLists })]
        public async Task<EndPointResponse<IEnumerable<GetAllProjectListsResponseViewModel>>> GetAllProjectLists([FromQuery] GetAllProjectListsRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<GetAllProjectListsQuery>());
            var response = result.Data.MapList<GetAllProjectListsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<IEnumerable<GetAllProjectListsResponseViewModel>>.Success(response, "Project List Filtered Successfully");
            else
                return EndPointResponse<IEnumerable<GetAllProjectListsResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
