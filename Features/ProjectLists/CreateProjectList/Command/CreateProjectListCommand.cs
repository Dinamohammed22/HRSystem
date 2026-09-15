using EasyTask.Common.Requests;
using EasyTask.Models.ProjectLists;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.ProjectLists.CreateProjectList.Command
{
    public record CreateProjectListCommand(string Name, int Sequence, string ProjectId):IRequestBase<bool>;
    public class CreateProjectListCommandHandler : RequestHandlerBase<ProjectList, CreateProjectListCommand, bool>
    {
        public CreateProjectListCommandHandler(RequestHandlerBaseParameters<ProjectList> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateProjectListCommand request, CancellationToken cancellationToken)
        {

            ProjectList projectList = new ProjectList
            {
                Name = request.Name,
                ProjectId = request.ProjectId,
                Sequence = request.Sequence,
            };

            _repository.Add(projectList);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
