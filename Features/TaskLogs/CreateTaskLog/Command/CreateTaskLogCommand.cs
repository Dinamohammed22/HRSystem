using EasyTask.Common.Requests;
using EasyTask.Models.TaskLogs;

namespace EasyTask.Features.TaskLogs.CreateTaskLog.Command
{
    public record CreateTaskLogCommand(string Description, string ProjectTaskId):IRequestBase<bool>;
    public class CreateTaskLogCommandHandler : RequestHandlerBase<TaskLog, CreateTaskLogCommand, bool>
    {
        public CreateTaskLogCommandHandler(RequestHandlerBaseParameters<TaskLog> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateTaskLogCommand request, CancellationToken cancellationToken)
        {
            TaskLog taskLog = new TaskLog
            {
                Description = request.Description,
                ProjectTaskId = request.ProjectTaskId,
                UserId = string.IsNullOrEmpty(_userState.UserID) ? "" : _userState.UserID,
            };
            _repository.Add(taskLog);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
