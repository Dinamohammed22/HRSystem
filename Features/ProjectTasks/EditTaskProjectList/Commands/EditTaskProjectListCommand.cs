using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.ProjectTasks.EditTaskProjectList.Commands
{
    public record EditTaskProjectListCommand(string ID, string ProjectListId) : IRequestBase<bool>;
    public class EditTaskProjectListCommandHandler : RequestHandlerBase<ProjectTask, EditTaskProjectListCommand, bool>
    {
        public EditTaskProjectListCommandHandler(RequestHandlerBaseParameters<ProjectTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditTaskProjectListCommand request, CancellationToken cancellationToken)
        {
            var projectTask = new ProjectTask
            {
                ID = request.ID,
                ProjectListId = request.ProjectListId,
            };

            _repository.SaveIncluded(projectTask, nameof(projectTask.ProjectListId));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
