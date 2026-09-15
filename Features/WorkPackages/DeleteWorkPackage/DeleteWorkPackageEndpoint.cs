using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectTasks.DeleteTast.Orchestrators;
using EasyTask.Features.ProjectTasks.DeleteWorkPackage.Orchestrators;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using EasyWorkPackage.Features.WorkPackages.DeleteWorkPackage;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Tasks.DeleteTask
{
    public class DeleteWorkPackageEndpoint : EndpointBase<DeleteWorkPackageRequestViewModel, DeleteWorkPackageResponseViewModel>
    {
        public DeleteWorkPackageEndpoint(EndpointBaseParameters<DeleteWorkPackageRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteWorkPackage })]
        public async Task<EndPointResponse<DeleteWorkPackageResponseViewModel>> DeleteWorkPackage(DeleteWorkPackageRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteWorkPackageOrchestrators>());
            if (result.IsSuccess)
                return EndPointResponse<DeleteWorkPackageResponseViewModel>.Success(new DeleteWorkPackageResponseViewModel(), "WorkPackage Deleted Successfully");
            else
                return EndPointResponse<DeleteWorkPackageResponseViewModel>.Failure(result.ErrorCode);
        }

    }
}
