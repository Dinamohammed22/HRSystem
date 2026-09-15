using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Tasks.Queries;
using EasyTask.Features.Shifts.GetShiftById;
using EasyTask.Features.Tasks.GetTaskById;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Tasks.GetTaskById
{
    public class GetTaskByIdEndpoint : EndpointBase<GetTaskByIdRequestViewModel, GetTaskByIdResponseViewModel>
    {
        public GetTaskByIdEndpoint(EndpointBaseParameters<GetTaskByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetTaskByID })]
        public async Task<EndPointResponse<GetTaskByIdResponseViewModel>> GetByID([FromQuery] GetTaskByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetTaskByIdQuery>());

            var response = result.Data.MapOne<GetTaskByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetTaskByIdResponseViewModel>.Success(response, "Get Task successfully.");
            else
                return EndPointResponse<GetTaskByIdResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
