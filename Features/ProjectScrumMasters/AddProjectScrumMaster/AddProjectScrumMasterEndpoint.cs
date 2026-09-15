using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster
{
    public class AddProjectScrumMasterEndpoint : EndpointBase<AddProjectScrumMasterRequestViewModel, AddProjectScrumMasterResponseViewModel>
    {
        public AddProjectScrumMasterEndpoint(EndpointBaseParameters<AddProjectScrumMasterRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AddProjectScrumMaster })]
        public async Task<EndPointResponse<AddProjectScrumMasterResponseViewModel>> AddProjectScrumMaster(AddProjectScrumMasterRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AddProjectScrumMasterCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<AddProjectScrumMasterResponseViewModel>.Success(new AddProjectScrumMasterResponseViewModel(), "Project Scrum Master Added successfully.");
            }
            return EndPointResponse<AddProjectScrumMasterResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
