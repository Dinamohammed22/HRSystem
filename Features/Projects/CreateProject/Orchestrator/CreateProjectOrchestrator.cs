using EasyTask.Common.Requests;
using EasyTask.Features.Documents.AddDocument.Commands;
using EasyTask.Features.Projects.CreateProject.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Managements;
using EasyTask.Models.Projects;

namespace EasyTask.Features.Projects.CreateProject.Orchestrator
{
    public record CreateProjectOrchestrator(
        string Name,
        bool Strategic,
        bool Financial,
        DateTime? KickOffDate,
        bool IsKickOffmeeting,
        DateTime StartDate,
        DateTime? EndDate,
        string? ProjectPurpose,
        string? Scope,
        string? Deliverables,
        string? HighLevelRequirements,
        string ProjectTypeId,
        string ProjectManagerId,
        string ProjectOwnerId,
        string ManagementId,
        string DepartmentId,
        ICollection<string>? ScrumMastersIds
    ) : IRequestBase<string>;
    public class CreateProjectOrchestratorHandler : RequestHandlerBase<Project, CreateProjectOrchestrator, string>
    {
        public CreateProjectOrchestratorHandler(RequestHandlerBaseParameters<Project> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateProjectOrchestrator request, CancellationToken cancellationToken)
        {
            // Send command to MediatR
            var projectId = await _mediator.Send(request.MapOne<CreateProjectCommand>());
            if (projectId.IsSuccess)
            {
                var managementDocumentResult = await _mediator.Send(new AddDocumentCommand(PhysicalName: request.Name,
                    SourceId: projectId.Data,
                    SourceType: DocumentType.Project,
                    Path: "Projects",
                    ParentDocumentId: null));

                if (!managementDocumentResult.IsSuccess)
                    return RequestResult<string>.Failure(managementDocumentResult.ErrorCode);
                
                return RequestResult<string>.Success(projectId.Data);
            }
            return RequestResult<string>.Failure(projectId.ErrorCode);

        }
    }
}
