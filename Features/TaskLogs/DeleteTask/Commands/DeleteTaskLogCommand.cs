using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.TaskLogs;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Tasks.DeleteTaskLog.Commands
{
    public record DeleteTaskLogCommand(string ID):IRequestBase<bool>;
    public class DeleteTaskLogCommandHandler : RequestHandlerBase<TaskLog, DeleteTaskLogCommand, bool>
    {
        public DeleteTaskLogCommandHandler(RequestHandlerBaseParameters<TaskLog> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteTaskLogCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository
                  .Get(s => s.ID == request.ID)
                  .FirstOrDefaultAsync();

            if (task == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            _repository.Delete(task);
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
