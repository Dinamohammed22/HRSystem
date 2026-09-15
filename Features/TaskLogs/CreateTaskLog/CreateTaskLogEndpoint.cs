using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.TaskLogs.CreateTaskLog.Command;
using EasyTask.Features.TaskLogs.CreateTaskLog;
using EasyTask.Common.Endpoints;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTaskLog.Features.TaskLogs.CreateTaskLog
{
    public class CreateTaskLogEndpoint : EndpointBase<CreateTaskLogRequestViewModel, CreateTaskLogResponseViewModel>
    {
        public CreateTaskLogEndpoint(EndpointBaseParameters<CreateTaskLogRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateTaskLog })]
        public async Task<EndPointResponse<CreateTaskLogResponseViewModel>> CreateTaskLog(CreateTaskLogRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateTaskLogCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<CreateTaskLogResponseViewModel>.Success(new CreateTaskLogResponseViewModel(), "TaskLog Added successfully.");
            }
            return EndPointResponse<CreateTaskLogResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
