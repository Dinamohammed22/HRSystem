using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.Projects;

namespace EasyTask.Features.Projects.ContinueProject.Commands
{
    public record ContinueProjectCommand(string ID) : IRequestBase<bool>;
    public class ContinueProjectCommandHandler : RequestHandlerBase<Project, ContinueProjectCommand, bool>
    {
        public ContinueProjectCommandHandler(RequestHandlerBaseParameters<Project> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(ContinueProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                ID = request.ID,
                ProjectStatus = ProjectStatus.Active
            };

            _repository.SaveIncluded(project,nameof(project.ProjectStatus));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
