using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectTasks.EditTaskProjectList.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectTasks.EditTaskProjectList
{
    public class EditTaskProjectListEndPoint : EndpointBase<EditTaskProjectListRequestViewModel, EditTaskProjectListResponseViewModel>
    {
        public EditTaskProjectListEndPoint(EndpointBaseParameters<EditTaskProjectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditTaskProjectList })]
        public async Task<EndPointResponse<EditTaskProjectListResponseViewModel>> EditTaskProjectList(EditTaskProjectListRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EditTaskProjectListCommand>());

            if (result.IsSuccess)
                return EndPointResponse<EditTaskProjectListResponseViewModel>.Success(new EditTaskProjectListResponseViewModel(), "Task Status Updated successfully");
            else
                return EndPointResponse<EditTaskProjectListResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
