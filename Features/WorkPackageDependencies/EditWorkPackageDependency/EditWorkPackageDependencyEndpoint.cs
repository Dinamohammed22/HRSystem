using EasyTask.Common.Endpoints;
using EasyTask.Features.WorkPackageDependencies.EditWorkPackageDependency.Command;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.WorkPackageDependencies.EditWorkPackageDependency
{
    public class EditWorkPackageDependencyEndpoint : EndpointBase<EditWorkPackageDependencyRequestViewModel, EditWorkPackageDependencyResponseViewModel>
    {
        public EditWorkPackageDependencyEndpoint(EndpointBaseParameters<EditWorkPackageDependencyRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditWorkPackageDependency })]
        public async Task<EndPointResponse<EditWorkPackageDependencyResponseViewModel>> EditWorkPackageDependency(EditWorkPackageDependencyRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditWorkPackageDependencyCommand>());
            if (result.IsSuccess)
                return EndPointResponse<EditWorkPackageDependencyResponseViewModel>.Success(new EditWorkPackageDependencyResponseViewModel(), "WorkPackageDependency Edit Successfully");
            else
                return EndPointResponse<EditWorkPackageDependencyResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
