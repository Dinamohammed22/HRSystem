using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectScrumMasters;
using EasyTask.Models.ProjectStakeholders;

namespace EasyTask.Features.ProjectStakeholders.AddProjectStakeholder.Command
{
    public record AddProjectStakeholderCommand(string StakeholderId, StakeholderType StakeholderType, 
        StakeholderRole Role, string ProjectId):IRequestBase<bool>;
    public class AddProjectStakeholderCommandHandler : RequestHandlerBase<ProjectStakeholder, AddProjectStakeholderCommand, bool>
    {
        public AddProjectStakeholderCommandHandler(RequestHandlerBaseParameters<ProjectStakeholder> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AddProjectStakeholderCommand request, CancellationToken cancellationToken)
        {
            ProjectStakeholder projectStakeholder = new ProjectStakeholder
            {
                StakeholderId = request.StakeholderId,
                StakeholderType = request.StakeholderType,
                Role = request.Role,
                ProjectId = request.ProjectId
            };
            _repository.Add(projectStakeholder);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);

        }
    }
}
