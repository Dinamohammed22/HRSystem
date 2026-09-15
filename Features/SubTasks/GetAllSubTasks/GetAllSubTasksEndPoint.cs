using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.SubTasks.DTOs;
using EasyTask.Features.Common.SubTasks.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.SubTasks.GetAllSubTasks
{
    public class GetAllSubTasksEndPoint : EndpointBase<GetAllSubTasksRequestViewModel, GetAllSubTasksResponseViewModel>
    {
        public GetAllSubTasksEndPoint(EndpointBaseParameters<GetAllSubTasksRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllSubTasks })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllSubTasksResponseViewModel>>>> GetAllSubTasks(
         [FromQuery] GetAllSubTasksRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllSubTasksQuery>());
            var response = result.Data.MapPage<GetAllSubTasksDTO, GetAllSubTasksResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllSubTasksResponseViewModel>>
                    .Success(response, "Tasks filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllSubTasksResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
