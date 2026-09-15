using EasyTask.Common.Endpoints;
using EasyTask.Features.Projects.ContinueProject.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Projects.ContinueProject
{
    public class ContinueProjectEndPoint : EndpointBase<ContinueProjectRequestViewModel, ContinueProjectResponseViewModel>
    {
        public ContinueProjectEndPoint(EndpointBaseParameters<ContinueProjectRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ContinueProject })]
        public async Task<EndPointResponse<ContinueProjectResponseViewModel>> ContinueProject(ContinueProjectRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<ContinueProjectCommand>());

            if (result.IsSuccess)
                return EndPointResponse<ContinueProjectResponseViewModel>.Success(new ContinueProjectResponseViewModel(), "Project Activated successfully");
            else
                return EndPointResponse<ContinueProjectResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
