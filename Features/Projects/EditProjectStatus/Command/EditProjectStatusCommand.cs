using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.Projects;

namespace EasyTask.Features.Projects.EditProjectStatus.Command
{
    public record EditProjectStatusCommand(string ProjectId, ProjectStatus ProjectStatus):IRequestBase<bool>;
    public class EditProjectStatusCommandHandler : RequestHandlerBase<Project, EditProjectStatusCommand, bool>
    {
        public EditProjectStatusCommandHandler(RequestHandlerBaseParameters<Project> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditProjectStatusCommand request, CancellationToken cancellationToken)
        {

            var check = await _repository.AnyAsync(b => b.ID == request.ProjectId);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            Project Project = new Project { ID = request.ProjectId };
            Project.ProjectStatus = request.ProjectStatus;
            _repository.SaveIncluded(Project, nameof(Project.ProjectStatus));
            _repository.SaveChanges();
            var result = RequestResult<bool>.Success(true);
            return await Task.FromResult(result);
        }
    }
}
