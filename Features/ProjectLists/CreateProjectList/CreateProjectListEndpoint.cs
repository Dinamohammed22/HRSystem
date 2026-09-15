using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectLists.CreateProjectList.Command;
using EasyTask.Features.ProjectTasks.CreateTask;
using EasyTask.Features.ProjectTasks.CreateTask.Orchestrators;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectLists.CreateProjectList
{
    public class CreateProjectListEndpoint : EndpointBase<CreateProjectListRequestViewModel, CreateProjectListResponseViewModel>
    {
        public CreateProjectListEndpoint(EndpointBaseParameters<CreateProjectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateProjectList })]
        public async Task<EndPointResponse<CreateProjectListResponseViewModel>> CreateTask(CreateProjectListRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateProjectListCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<CreateProjectListResponseViewModel>.Success(new CreateProjectListResponseViewModel(), "Project List Added successfully.");
            }
            return EndPointResponse<CreateProjectListResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
