using EasyTask.Common.Requests;
using EasyTask.Features.Common.ExternalMemberTasks.DTOs;
using EasyTask.Models.ExternalMemberTasks;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.ExternalMemberTasks.UnassignExternalMemberToTask.Commands
{
    public record UnassignExternalMemberToTaskCommand(List<AssignExternalMemberToTaskDTO> UnassignExternalMemberToTask) : IRequestBase<bool>;
    public class UnassignExternalMemberToTaskCommandHandler : RequestHandlerBase<ExternalMemberTask, UnassignExternalMemberToTaskCommand, bool>
    {
        public UnassignExternalMemberToTaskCommandHandler(RequestHandlerBaseParameters<ExternalMemberTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(UnassignExternalMemberToTaskCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.UnassignExternalMemberToTask)
            {
                if (string.IsNullOrWhiteSpace(item.ProjectTaskId))
                    continue;

                var validIds = item.ExternalMemberIds ?? new List<string>();

                var existingAssignments = await _repository.Get(
                    x => x.ProjectTaskId == item.ProjectTaskId
                ).ToListAsync(cancellationToken);

                var assignmentsToRemove = existingAssignments
                    .Where(x => !validIds.Contains(x.ExternalMemberId))
                    .ToList();

                foreach (var assignment in assignmentsToRemove)
                {
                    _repository.Delete(assignment);
                }
            }

            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
