using EasyTask.Common.Requests;
using EasyTask.Features.Common.ExternalMemberTasks.DTOs;
using EasyTask.Models.ExternalMemberTasks;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.ExternalMemberTasks.AssignExternalMemberToTask.Commands
{
    public record AssignExternalMemberToTaskCommand(List<AssignExternalMemberToTaskDTO> AssignExternalMemberToTask) : IRequestBase<bool>;
    public class AssignExternalMemberToTaskCommandHandler : RequestHandlerBase<ExternalMemberTask, AssignExternalMemberToTaskCommand, bool>
    {
        public AssignExternalMemberToTaskCommandHandler(RequestHandlerBaseParameters<ExternalMemberTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AssignExternalMemberToTaskCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.AssignExternalMemberToTask)
            {
                foreach (var ExternalMemberId in item.ExternalMemberIds)
                {
                    var exists = await _repository.Get(
                        x => x.ProjectTaskId == item.ProjectTaskId
                          && x.ExternalMemberId == ExternalMemberId).FirstOrDefaultAsync();

                    if (exists == null)
                    {
                        var externalMemberTask = new ExternalMemberTask
                        {
                            ProjectTaskId = item.ProjectTaskId,
                            ExternalMemberId = ExternalMemberId
                        };

                        _repository.Add(externalMemberTask);
                    }
                }
            }
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
