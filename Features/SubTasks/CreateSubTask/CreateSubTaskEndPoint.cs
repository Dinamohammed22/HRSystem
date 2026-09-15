using EasyTask.Common.Endpoints;
using EasyTask.Features.SubTasks.CreateSubTask.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.SubTasks.CreateSubTask
{
    public class CreateSubTaskEndPoint : EndpointBase<CreateSubTaskRequestViewModel, CreateSubTaskResponseViewModel>
    {
        public CreateSubTaskEndPoint(EndpointBaseParameters<CreateSubTaskRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateSubTask })]
        public async Task<EndPointResponse<CreateSubTaskResponseViewModel>> CreateSubTask(CreateSubTaskRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateSubTaskCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<CreateSubTaskResponseViewModel>.Success(new CreateSubTaskResponseViewModel(), "SubTask Added successfully.");
            }
            return EndPointResponse<CreateSubTaskResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
