using EasyTask.Common.Requests;
using EasyTask.Features.ProjectLists.CreateProjectList.Command;
using EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster.Commands;
using EasyTask.Helpers;
using EasyTask.Models.ProjectLists;
using EasyTask.Models.Projects;

namespace EasyTask.Features.Projects.CreateProject.Commands
{
    public record CreateProjectCommand(
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
    ) :IRequestBase<string>;
    public class CreateProjectCommandHandler : RequestHandlerBase<Project, CreateProjectCommand, string>
    {
        public CreateProjectCommandHandler(RequestHandlerBaseParameters<Project> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {

            Project project = request.MapOne<Project>();

            project.ProjectCode = GenerateGenericCode.Generate("PR-");
            
            _repository.Add(project);

            _repository.SaveChanges();

            if (request.ScrumMastersIds != null && request.ScrumMastersIds.Any())
            {
                foreach (var id in request.ScrumMastersIds)
                {
                    await _mediator.Send(new AddProjectScrumMasterCommand(id, project.ID), cancellationToken);
                }
            }

            // Create default project lists
            var defaultProjectLists = new List<ProjectList>
            {
                new ProjectList { Name = "Backlog", Sequence = 1, ProjectId = project.ID },
                new ProjectList { Name = "In Progress", Sequence = 2, ProjectId = project.ID },
                new ProjectList { Name = "Done", Sequence = 3, ProjectId = project.ID }
            };

            var createTasks = defaultProjectLists
                .Select(pl => _mediator.Send(
                    new CreateProjectListCommand(pl.Name, pl.Sequence, pl.ProjectId), cancellationToken));

            await Task.WhenAll(createTasks);

            _repository.SaveChanges();

            return RequestResult<string>.Success(project.ID);
        }
    }
}
