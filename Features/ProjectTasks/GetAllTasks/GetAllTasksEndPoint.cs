using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.ProjectTasks.DTOs;
using EasyTask.Features.Common.ProjectTasks.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectTasks.GetAllTasks
{
    public class GetAllTasksEndPoint : EndpointBase<GetAllTasksRequestViewModel, GetAllTasksResponseViewModel>
    {
        public GetAllTasksEndPoint(EndpointBaseParameters<GetAllTasksRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllTasks })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllTasksResponseViewModel>>>> GetAllTasks(
         [FromQuery] GetAllTasksRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllTasksQuery>());
            var response = result.Data.MapPage<GetAllTasksDTO, GetAllTasksResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllTasksResponseViewModel>>
                    .Success(response, "Tasks filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllTasksResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
