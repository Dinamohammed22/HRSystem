using EasyTask.Common.Endpoints;
using EasyTask.Features.CandidateTasks.AssignCandidatesToTasks.Orchestrators;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateTasks.AssignCandidatesToTasks
{
    public class AssignCandidatesToTasksEndPoint : EndpointBase<AssignCandidatesToTasksRequestViewModel, AssignCandidatesToTasksResponseViewModel>
    {
        public AssignCandidatesToTasksEndPoint(EndpointBaseParameters<AssignCandidatesToTasksRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AssignCandidatesToTasks })]
        public async Task<EndPointResponse<AssignCandidatesToTasksResponseViewModel>> AssignCandidatesToTasks(AssignCandidatesToTasksRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AssignCandidatesToTasksOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<AssignCandidatesToTasksResponseViewModel>.Success(new AssignCandidatesToTasksResponseViewModel(), "Candidates Assigned to Tasks Successfully");
            else
                return EndPointResponse<AssignCandidatesToTasksResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
