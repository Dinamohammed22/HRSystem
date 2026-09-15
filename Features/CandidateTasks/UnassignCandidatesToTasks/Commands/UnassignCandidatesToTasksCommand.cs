using EasyTask.Common.Requests;
using EasyTask.Features.Common.CandidateTasks.DTOs;
using EasyTask.Models.CandidateTasks;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.CandidateTasks.UnassignCandidatesToTasks.Commands
{
    public record UnassignCandidatesToTasksCommand(List<AssignCandidatesToTasksDTO> UnassignCandidatesFromTasks) : IRequestBase<bool>;
    public class UnassignCandidatesToTasksCommandHandler : RequestHandlerBase<CandidateTask, UnassignCandidatesToTasksCommand, bool>
    {
        public UnassignCandidatesToTasksCommandHandler(RequestHandlerBaseParameters<CandidateTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(UnassignCandidatesToTasksCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.UnassignCandidatesFromTasks)
            {
                var newCandidates = item.CandidateIds;

                // 1️⃣ Get all existing assignments for this task
                var existingAssignments = await _repository.Get(
                    x => x.ProjectTaskId == item.ProjectTaskId
                ).ToListAsync();

                // 2️⃣ Find candidates to remove → not included in new list
                var toRemove = existingAssignments
                    .Where(x => !newCandidates.Contains(x.CandidateId))
                    .ToList();

                // 3️⃣ Remove those relationships
                foreach (var assignment in toRemove)
                {
                    _repository.Delete(assignment);
                }
            }

            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
