using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.ProjectTasks.DTOs;
using EasyTask.Features.Common.ProjectTasks.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectTasks.GetAllTasksByProjectId
{
    public class GetAllTasksByProjectIdEndPoint : EndpointBase<GetAllTasksByProjectIdRequestViewModel, GetAllTasksByProjectIdResponseViewModel>
    {
        public GetAllTasksByProjectIdEndPoint(EndpointBaseParameters<GetAllTasksByProjectIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllTasksByProjectId })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllTasksByProjectIdResponseViewModel>>>> GetAllTasksByProjectId(
         [FromQuery] GetAllTasksByProjectIdRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllTasksByProjectIdQuery>());
            var response = result.Data.MapPage<GetAllTasksByProjectIdDTO, GetAllTasksByProjectIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllTasksByProjectIdResponseViewModel>>
                    .Success(response, "Tasks filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllTasksByProjectIdResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
