using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.ProjectExternalMembers.DTOs;
using EasyTask.Features.Common.ProjectExternalMembers.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectExternalMembers.GetProjectExternalMembers
{
    public class GetProjectExternalMembersEndpoint : EndpointBase<GetProjectExternalMembersRequestViewModel, GetProjectExternalMembersResponseViewModel>
    {
        public GetProjectExternalMembersEndpoint(EndpointBaseParameters<GetProjectExternalMembersRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetProjectExternalMembers })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetProjectExternalMembersResponseViewModel>>>> GetProjectExternalMembers(
         [FromQuery] GetProjectExternalMembersRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetProjectExternalMembersQuery>());
            var response = result.Data.MapPage<GetProjectExternalMembersDTO, GetProjectExternalMembersResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetProjectExternalMembersResponseViewModel>>
                    .Success(response, "Project External Members filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetProjectExternalMembersResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
