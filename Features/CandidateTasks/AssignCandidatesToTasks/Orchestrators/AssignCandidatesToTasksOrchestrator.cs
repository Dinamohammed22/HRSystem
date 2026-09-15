using EasyTask.Common.Requests;
using EasyTask.Features.CandidateTasks.AssignCandidatesToTasks.Commands;
using EasyTask.Features.CandidateTasks.UnassignCandidatesToTasks.Commands;
using EasyTask.Features.Common.CandidateTasks.DTOs;
using EasyTask.Features.Common.ExternalMemberTasks.DTOs;
using EasyTask.Features.ExternalMemberTasks.AssignExternalMemberToTask.Commands;
using EasyTask.Features.ExternalMemberTasks.UnassignExternalMemberToTask.Commands;
using EasyTask.Models.CandidateTasks;

namespace EasyTask.Features.CandidateTasks.AssignCandidatesToTasks.Orchestrators
{
    public record AssignCandidatesToTasksOrchestrator(List<AssignCandidatesToTasksDTO> AssignCandidatesToTasks,
        List<AssignExternalMemberToTaskDTO> AssignExternalMemberToTask) : IRequestBase<bool>;
    public class AssignCandidatesToTasksOrchestratorHandler : RequestHandlerBase<CandidateTask, AssignCandidatesToTasksOrchestrator, bool>
    {
        public AssignCandidatesToTasksOrchestratorHandler(RequestHandlerBaseParameters<CandidateTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AssignCandidatesToTasksOrchestrator request, CancellationToken cancellationToken)
        {
            var UnassignCandidate = await _mediator.Send(new UnassignCandidatesToTasksCommand(request.AssignCandidatesToTasks));
            if (!UnassignCandidate.IsSuccess)
                return RequestResult<bool>.Failure(UnassignCandidate.ErrorCode);
            var AssignCandidate = await _mediator.Send(new AssignCandidatesToTasksCommand(request.AssignCandidatesToTasks));
            if (!AssignCandidate.IsSuccess)
                return RequestResult<bool>.Failure(AssignCandidate.ErrorCode);
            var UnassignExternalMember = await _mediator.Send(new UnassignExternalMemberToTaskCommand(request.AssignExternalMemberToTask));
            if (!UnassignExternalMember.IsSuccess)
                return RequestResult<bool>.Failure(UnassignExternalMember.ErrorCode);
            var AssignExternalMember = await _mediator.Send(new AssignExternalMemberToTaskCommand(request.AssignExternalMemberToTask));
            if (!AssignExternalMember.IsSuccess)
                return RequestResult<bool>.Failure(AssignExternalMember.ErrorCode);
            return RequestResult<bool>.Success(true);
        }
    }
}
