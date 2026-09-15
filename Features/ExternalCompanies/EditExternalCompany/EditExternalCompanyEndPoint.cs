using EasyTask.Common.Endpoints;
using EasyTask.Features.ExternalCompanies.EditExternalCompany.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ExternalCompanies.EditExternalCompany
{
    public class EditExternalCompanyEndPoint : EndpointBase<EditExternalCompanyRequestViewModel, EditExternalCompanyResponseViewModel>
    {
        public EditExternalCompanyEndPoint(EndpointBaseParameters<EditExternalCompanyRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditExternalCompany })]
        public async Task<EndPointResponse<EditExternalCompanyResponseViewModel>> EditExternalCompany(EditExternalCompanyRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditExternalCompanyCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<EditExternalCompanyResponseViewModel>.Success(new EditExternalCompanyResponseViewModel(), "ExternalCompany Edited successfully.");
            }
            return EndPointResponse<EditExternalCompanyResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
