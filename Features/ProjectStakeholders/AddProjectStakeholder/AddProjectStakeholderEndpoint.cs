using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster;
using EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster.Commands;
using EasyTask.Features.ProjectStakeholders.AddProjectStakeholder.Command;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectStakeholders.AddProjectStakeholder
{
    public class AddProjectStakeholderEndpoint : EndpointBase<AddProjectStakeholderRequestViewModel, AddProjectStakeholderResponseViewModel>
    {
        public AddProjectStakeholderEndpoint(EndpointBaseParameters<AddProjectStakeholderRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AddProjectStakeholder })]
        public async Task<EndPointResponse<AddProjectStakeholderResponseViewModel>> AddProjectScrumMaster(AddProjectStakeholderRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AddProjectStakeholderCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<AddProjectStakeholderResponseViewModel>.Success(new AddProjectStakeholderResponseViewModel(), "Project Stakeholder Added successfully.");
            }
            return EndPointResponse<AddProjectStakeholderResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
