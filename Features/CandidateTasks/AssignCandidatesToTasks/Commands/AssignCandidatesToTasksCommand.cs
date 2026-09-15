using EasyTask.Common.Requests;
using EasyTask.Features.Common.CandidateTasks.DTOs;
using EasyTask.Models.CandidateTasks;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.CandidateTasks.AssignCandidatesToTasks.Commands
{
    public record AssignCandidatesToTasksCommand(List<AssignCandidatesToTasksDTO> AssignCandidatesToTasks) : IRequestBase<bool>;
    public class AssignCandidatesToTasksCommandHandler : RequestHandlerBase<CandidateTask, AssignCandidatesToTasksCommand, bool>
    {
        public AssignCandidatesToTasksCommandHandler(RequestHandlerBaseParameters<CandidateTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AssignCandidatesToTasksCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.AssignCandidatesToTasks)
            {
                foreach (var candidateId in item.CandidateIds)
                {
                    var exists = await _repository.Get(
                        x => x.ProjectTaskId == item.ProjectTaskId
                          && x.CandidateId == candidateId).FirstOrDefaultAsync();

                    if (exists == null)
                    {
                        var candidateTask = new CandidateTask
                        {
                            ProjectTaskId = item.ProjectTaskId,
                            CandidateId = candidateId
                        };

                        _repository.Add(candidateTask);
                    }
                }
            }
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}