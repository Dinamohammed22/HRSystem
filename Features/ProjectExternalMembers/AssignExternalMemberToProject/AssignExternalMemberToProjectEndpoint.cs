using EasyProject.Features.ExternalMemberProjects.AssignExternalMemberToProject.Commands;
using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster;
using EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectExternalMembers.AssignExternalMemberToProject
{
    public class AssignExternalMemberToProjectEndpoint : EndpointBase<AssignExternalMemberToProjectRequestViewModel, AssignExternalMemberToProjectResponseViewModel>
    {
        public AssignExternalMemberToProjectEndpoint(EndpointBaseParameters<AssignExternalMemberToProjectRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AssignExternalMemberToProject })]
        public async Task<EndPointResponse<AssignExternalMemberToProjectResponseViewModel>> AssignExternalMemberToProject(AssignExternalMemberToProjectRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AssignExternalMemberToProjectCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<AssignExternalMemberToProjectResponseViewModel>.Success(new AssignExternalMemberToProjectResponseViewModel(), "Project External Member Added successfully.");
            }
            return EndPointResponse<AssignExternalMemberToProjectResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
