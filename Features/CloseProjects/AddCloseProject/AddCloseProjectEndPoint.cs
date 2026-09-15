using EasyTask.Common.Endpoints;
using EasyTask.Features.CloseProjects.AddCloseProject.Commands;
using EasyTask.Features.Projects.AddCloseProject.Orchestrator;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CloseProjects.AddCloseProject
{
    public class AddCloseProjectEndPoint : EndpointBase<AddCloseProjectRequestViewModel, AddCloseProjectResponseViewModel>
    {
        public AddCloseProjectEndPoint(EndpointBaseParameters<AddCloseProjectRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AddCloseProject })]
        public async Task<EndPointResponse<AddCloseProjectResponseViewModel>> AddCloseProject(AddCloseProjectRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AddCloseProjectOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<AddCloseProjectResponseViewModel>.Success(new AddCloseProjectResponseViewModel(), "Close Request Added Successfully");
            else
                return EndPointResponse<AddCloseProjectResponseViewModel>.Failure(result.ErrorCode, result.Message);
        }
    }
}
