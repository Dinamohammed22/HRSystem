using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.ExternalCompanies.DTOs;
using EasyTask.Features.Common.ExternalCompanies.Queries;
using EasyTask.Features.Common.Shifts.DTOs;
using EasyTask.Features.Common.Shifts.Queries;
using EasyTask.Features.Shifts.GetAllShifts;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ExternalCompanies.GetAllExternalCompanies
{
    public class GetAllExternalCompaniesEndpoint : EndpointBase<GetAllExternalCompaniesRequestViewModel, GetAllExternalCompaniesResponseViewModel>
    {
        public GetAllExternalCompaniesEndpoint(EndpointBaseParameters<GetAllExternalCompaniesRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllExternalCompanies })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllExternalCompaniesResponseViewModel>>>> GetAllExternalCompanies(
        [FromQuery] GetAllExternalCompaniesRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllExternalCompaniesQuery>());
            var response = result.Data.MapPage<GetExternalCompanyByIdDTO, GetAllExternalCompaniesResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllExternalCompaniesResponseViewModel>>
                    .Success(response, " ExternalCompanies filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllExternalCompaniesResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
