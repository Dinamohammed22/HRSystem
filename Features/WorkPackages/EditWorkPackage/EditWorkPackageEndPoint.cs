using EasyTask.Common.Endpoints;
using EasyTask.Features.WorkPackages.EditWorkPackage.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.WorkPackages.EditWorkPackage
{
    public class EditWorkPackageEndPoint : EndpointBase<EditWorkPackageRequestViewModel, EditWorkPackageResponseViewModel>
    {
        public EditWorkPackageEndPoint(EndpointBaseParameters<EditWorkPackageRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditWorkPackage })]
        public async Task<EndPointResponse<EditWorkPackageResponseViewModel>> EditWorkPackage(EditWorkPackageRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditWorkPackageCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<EditWorkPackageResponseViewModel>.Success(new EditWorkPackageResponseViewModel(), "WorkPackage Edited successfully.");
            }
            return EndPointResponse<EditWorkPackageResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
