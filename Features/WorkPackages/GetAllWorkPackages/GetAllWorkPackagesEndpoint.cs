
using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.WorkPackages.DTOs;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.WorkPackages.GetAllWorkPackages
{
    public class GetAllWorkPackagesEndpoint : EndpointBase<GetAllWorkPackagesRequestViewModel, GetAllWorkPackagesResponseViewModel>
    {
        public GetAllWorkPackagesEndpoint(EndpointBaseParameters<GetAllWorkPackagesRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllWorkPackages })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllWorkPackagesResponseViewModel>>>> GetAllWorkPackages(
         [FromQuery] GetAllWorkPackagesRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllWorkPackagesQuery>());
            var response = result.Data.MapPage<GetAllWorkPackagesDTO, GetAllWorkPackagesResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllWorkPackagesResponseViewModel>>
                    .Success(response, "WorkPackages filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllWorkPackagesResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
