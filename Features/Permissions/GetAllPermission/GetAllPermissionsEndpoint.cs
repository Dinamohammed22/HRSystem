using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Permissions.DTOs;
using EasyTask.Features.Common.Permissions.Queries;
using EasyTask.Features.Common.Shifts.DTOs;
using EasyTask.Features.Common.Shifts.Queries;
using EasyTask.Features.Common.Vacations.DTOs;
using EasyTask.Features.Common.Vacations.Queries;
using EasyTask.Features.Permissions.GetAllPermissions;
using EasyTask.Features.Shifts.GetAllShifts;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Vacations.GetAllVacations
{
    public class GetAllPermissionsEndpoint : EndpointBase<GetAllPermissionsRequestViewModel, GetAllPermissionsResponseViewModel>
    {
        public GetAllPermissionsEndpoint(EndpointBaseParameters<GetAllPermissionsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllPermissions })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllPermissionsResponseViewModel>>>> GetAllPermissions(
        [FromQuery] GetAllPermissionsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetPermissionsQuery>());
            var response = result.Data.MapPage<GetPermissionByIdDTO, GetAllPermissionsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllPermissionsResponseViewModel>>
                    .Success(response, "Permissions filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllPermissionsResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
