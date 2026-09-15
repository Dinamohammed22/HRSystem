using EasyProject.Features.CandidateProjects.AssignCandidateToProject.Commands;
using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster;
using EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectCandidates.AssignCandidateToProject
{
    public class AssignCandidateToProjectEndpoint : EndpointBase<AssignCandidateToProjectRequestViewModel, AssignCandidateToProjectResponseViewModel>
    {
        public AssignCandidateToProjectEndpoint(EndpointBaseParameters<AssignCandidateToProjectRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AssignCandidateToProject })]
        public async Task<EndPointResponse<AssignCandidateToProjectResponseViewModel>> AssignCandidateToProject(AssignCandidateToProjectRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AssignCandidateToProjectCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<AssignCandidateToProjectResponseViewModel>.Success(new AssignCandidateToProjectResponseViewModel(), "Project Candidate Added successfully.");
            }
            return EndPointResponse<AssignCandidateToProjectResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
