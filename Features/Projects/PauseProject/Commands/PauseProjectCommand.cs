using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.Projects;

namespace EasyTask.Features.Projects.PauseProject.Commands
{
    public record PauseProjectCommand(string ID, string? PauseReason) : IRequestBase<bool>;
    public class PauseProjectCommandHandler : RequestHandlerBase<Project, PauseProjectCommand, bool>
    {
        public PauseProjectCommandHandler(RequestHandlerBaseParameters<Project> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(PauseProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                ID = request.ID,
                ProjectStatus = ProjectStatus.Paused,
                PauseReason = request.PauseReason
            };

            _repository.SaveIncluded(project,nameof(project.ProjectStatus));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
