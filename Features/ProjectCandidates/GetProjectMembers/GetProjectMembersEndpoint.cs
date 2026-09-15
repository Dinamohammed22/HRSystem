using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.ProjectCandidates.DTOs;
using EasyTask.Features.Common.ProjectCandidates.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectCandidates.GetProjectInternalMembers
{
    public class GetProjectInternalMembersEndpoint : EndpointBase<GetProjectInternalMembersRequestViewModel, GetProjectInternalMembersResponseViewModel>
    {
        public GetProjectInternalMembersEndpoint(EndpointBaseParameters<GetProjectInternalMembersRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetProjectInternalMembers })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetProjectInternalMembersResponseViewModel>>>> GetProjectInternalMembers(
         [FromQuery] GetProjectInternalMembersRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetProjectInternalMembersQuery>());
            var response = result.Data.MapPage<GetProjectInternalMembersDTO, GetProjectInternalMembersResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetProjectInternalMembersResponseViewModel>>
                    .Success(response, "Project Internal Members filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetProjectInternalMembersResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
