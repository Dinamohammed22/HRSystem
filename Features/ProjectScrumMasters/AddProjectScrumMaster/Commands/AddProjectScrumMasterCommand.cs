using EasyTask.Common.Requests;
using EasyTask.Models.ProjectScrumMasters;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.ProjectScrumMasters.AddProjectScrumMaster.Commands
{
    public record AddProjectScrumMasterCommand(string CandidateId, string ProjectId) :IRequestBase<string>;
    public class AddProjectScrumMasterCommandHandler : RequestHandlerBase<ProjectScrumMaster, AddProjectScrumMasterCommand, string>
    {
        public AddProjectScrumMasterCommandHandler(RequestHandlerBaseParameters<ProjectScrumMaster> requestParameters) : base(requestParameters)
        {
        }
        public async override Task<RequestResult<string>> Handle(AddProjectScrumMasterCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.Get(p => p.ProjectId == request.ProjectId && p.CandidateId == request.CandidateId).FirstOrDefaultAsync();
            if (existing != null)
            {
                return RequestResult<string>.Success(existing.ID);
            }

            ProjectScrumMaster projectScrumMaster = new ProjectScrumMaster 
            {
                CandidateId = request.CandidateId, 
                ProjectId = request.ProjectId
            };
            _repository.Add(projectScrumMaster);
            _repository.SaveChanges();
            return RequestResult<string>.Success(projectScrumMaster.ID);
        }
    }
}
