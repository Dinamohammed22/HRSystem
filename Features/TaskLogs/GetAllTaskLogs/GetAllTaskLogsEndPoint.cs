using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.TaskLogs.DTOs;
using EasyTask.Features.Common.TaskLogsLogs.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectTaskLogs.GetAllTaskLogs
{
    public class GetAllTaskLogsEndPoint : EndpointBase<GetAllTaskLogsRequestViewModel, GetAllTaskLogsResponseViewModel>
    {
        public GetAllTaskLogsEndPoint(EndpointBaseParameters<GetAllTaskLogsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllTaskLogs })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllTaskLogsResponseViewModel>>>> GetAllTaskLogs(
         [FromQuery] GetAllTaskLogsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllTaskLogsQuery>());
            var response = result.Data.MapPage<GetAllTaskLogsDTO, GetAllTaskLogsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllTaskLogsResponseViewModel>>
                    .Success(response, "TaskLogs filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllTaskLogsResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
