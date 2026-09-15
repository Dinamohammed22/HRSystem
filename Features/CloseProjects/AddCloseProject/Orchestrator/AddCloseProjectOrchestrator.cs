using EasyTask.Common.Requests;
using EasyTask.Features.CloseProjects.AddCloseProject.Commands;
using EasyTask.Features.Documents.AddDocument.Commands;
using EasyTask.Features.Projects.EditProjectStatus.Command;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Managements;
using EasyTask.Models.Projects;

namespace EasyTask.Features.Projects.AddCloseProject.Orchestrator
{
    public record AddCloseProjectOrchestrator(string? CandidateId, string ProjectId, string ProjectCloseReason, int CloseDuration
        , bool HasCloseImpact, string InternalCloseReason, string ExternalCloseReason) : IRequestBase<bool>;
    public class AddCloseProjectOrchestratorHandler : RequestHandlerBase<Project, AddCloseProjectOrchestrator, bool>
    {
        public AddCloseProjectOrchestratorHandler(RequestHandlerBaseParameters<Project> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AddCloseProjectOrchestrator request, CancellationToken cancellationToken)
        {
            var project = await _mediator.Send(request.MapOne<AddCloseProjectCommand>());
            if (project.IsSuccess)
            {
                _mediator.Send(new EditProjectStatusCommand(request.ProjectId, ProjectStatus.Inactive));
                return RequestResult<bool>.Success(true);
            }
            return RequestResult<bool>.Failure(project.ErrorCode);
        }
    }
}
