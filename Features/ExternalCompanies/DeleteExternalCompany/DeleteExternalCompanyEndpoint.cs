using EasyTask.Common.Endpoints;
using EasyTask.Features.ExternalCompanys.DeleteExternalCompany.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ExternalCompanys.DeleteExternalCompany
{
    public class DeleteExternalCompanyEndpoint : EndpointBase<DeleteExternalCompanyRequestViewModel, DeleteExternalCompanyResponseViewModel>
    {
        public DeleteExternalCompanyEndpoint(EndpointBaseParameters<DeleteExternalCompanyRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteExternalCompany })]
        public async Task<EndPointResponse<DeleteExternalCompanyResponseViewModel>> Delete(DeleteExternalCompanyRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteExternalCompanyCommand>());
            if (result.IsSuccess)
                return EndPointResponse<DeleteExternalCompanyResponseViewModel>.Success(new DeleteExternalCompanyResponseViewModel(), "External Company Deleted Successfully");
            else
                return EndPointResponse<DeleteExternalCompanyResponseViewModel>.Failure(result.ErrorCode);
        }

    }
}
