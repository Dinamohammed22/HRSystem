using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.WorkPackages.Quereies;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.WorkPackages.GetWorkPackageById
{
    public class GetWorkPackageByIdEndpoint : EndpointBase<GetWorkPackageByIdRequestViewModel, GetWorkPackageByIdResponseViewModel>
    {
        public GetWorkPackageByIdEndpoint(EndpointBaseParameters<GetWorkPackageByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetWorkPackageById })]
        public async Task<EndPointResponse<GetWorkPackageByIdResponseViewModel>> GetWorkPackageById([FromQuery] GetWorkPackageByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetWorkPackageByIdQuery>());

            GetWorkPackageByIdResponseViewModel response = result.Data.MapOne<GetWorkPackageByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetWorkPackageByIdResponseViewModel>.Success(response, "Get WorkPackage successfully.");
            else
                return EndPointResponse<GetWorkPackageByIdResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
