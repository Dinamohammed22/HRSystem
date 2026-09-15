using EasyTask.Common.Endpoints;
using EasyTask.Features.Tasks.DeleteTaskLog.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Tasks.DeleteTaskLog
{
    public class DeleteTaskLogEndpoint : EndpointBase<DeleteTaskLogRequestViewModel, DeleteTaskLogResponseViewModel>
    {
        public DeleteTaskLogEndpoint(EndpointBaseParameters<DeleteTaskLogRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteTaskLog })]
        public async Task<EndPointResponse<DeleteTaskLogResponseViewModel>> Delete(DeleteTaskLogRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteTaskLogCommand>());
            if (result.IsSuccess)
                return EndPointResponse<DeleteTaskLogResponseViewModel>.Success(new DeleteTaskLogResponseViewModel(), "Task Log Deleted Successfully");
            else
                return EndPointResponse<DeleteTaskLogResponseViewModel>.Failure(result.ErrorCode);
        }

    }
}
