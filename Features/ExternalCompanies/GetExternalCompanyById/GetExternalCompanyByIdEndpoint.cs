using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.ExternalCompanies.Quereies;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ExternalCompanies.GetExternalCompanyById
{
    public class GetExternalCompanyByIdEndpoint : EndpointBase<GetExternalCompanyByIdRequestViewModel, GetExternalCompanyByIdResponseViewModel>
    {
        public GetExternalCompanyByIdEndpoint(EndpointBaseParameters<GetExternalCompanyByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetExternalCompanyById })]
        public async Task<EndPointResponse<GetExternalCompanyByIdResponseViewModel>> GetExternalCompanyById([FromQuery] GetExternalCompanyByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetExternalCompanyByIdQuery>());

            GetExternalCompanyByIdResponseViewModel response = result.Data.MapOne<GetExternalCompanyByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetExternalCompanyByIdResponseViewModel>.Success(response, "Get ExternalCompany successfully.");
            else
                return EndPointResponse<GetExternalCompanyByIdResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
