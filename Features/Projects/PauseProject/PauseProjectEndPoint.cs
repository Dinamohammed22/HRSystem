using EasyTask.Common.Endpoints;
using EasyTask.Features.Projects.PauseProject.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Projects.PauseProject
{
    public class PauseProjectEndPoint : EndpointBase<PauseProjectRequestViewModel, PauseProjectResponseViewModel>
    {
        public PauseProjectEndPoint(EndpointBaseParameters<PauseProjectRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.PauseProject })]
        public async Task<EndPointResponse<PauseProjectResponseViewModel>> PauseProject(PauseProjectRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<PauseProjectCommand>());

            if (result.IsSuccess)
                return EndPointResponse<PauseProjectResponseViewModel>.Success(new PauseProjectResponseViewModel(), "Project Paused successfully");
            else
                return EndPointResponse<PauseProjectResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
