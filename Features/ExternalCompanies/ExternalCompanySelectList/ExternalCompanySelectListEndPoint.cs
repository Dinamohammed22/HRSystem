using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.ExternalCompanies.Quereies;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ExternalCompanies.ExternalCompanySelectList
{
    public class ExternalCompanySelectListEndPoint : EndpointBase<ExternalCompanySelectListRequestViewModel, ExternalCompanySelectListResponseViewModel>
    {
        public ExternalCompanySelectListEndPoint(EndpointBaseParameters<ExternalCompanySelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ExternalCompanySelectList })]
        public async Task<EndPointResponse<IEnumerable<ExternalCompanySelectListResponseViewModel>>> ExternalCompanySelectList([FromQuery] ExternalCompanySelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<ExternalCompanySelectListQuery>());

            var response = result.Data.MapList<ExternalCompanySelectListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<ExternalCompanySelectListResponseViewModel>>.Success(response, "ExternalCompanies got successfully.");
            else
                return EndPointResponse<IEnumerable<ExternalCompanySelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
