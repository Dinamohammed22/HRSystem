using EasyTask.Common.Requests;
using EasyTask.Models.ProjectScrumMasters;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.ProjectScrumMasters.EditProjectScrumMaster.Commands
{
    public record EditProjectScrumMasterCommand(List<string> CandidateIds, string ProjectId) : IRequestBase<bool>;
    public class EditProjectScrumMasterCommandHandler : RequestHandlerBase<ProjectScrumMaster, EditProjectScrumMasterCommand, bool>
    {
        public EditProjectScrumMasterCommandHandler(RequestHandlerBaseParameters<ProjectScrumMaster> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditProjectScrumMasterCommand request, CancellationToken cancellationToken)
        {
            var existingAssignments = await _repository
                .Get(x => x.ProjectId == request.ProjectId)
                .ToListAsync();

            var existingIds = existingAssignments.Select(x => x.CandidateId).ToList();

            var newIds = request.CandidateIds ?? new List<string>();

            var toAdd = newIds.Except(existingIds).ToList();

            foreach (var candidateId in toAdd)
            {
                var newScrumMaster = new ProjectScrumMaster
                {
                    ProjectId = request.ProjectId,
                    CandidateId = candidateId
                };
                _repository.Add(newScrumMaster);
            }

            var toRemove = existingAssignments
                .Where(x => !newIds.Contains(x.CandidateId))
                .ToList();

            foreach (var record in toRemove)
            {
                _repository.Delete(record);
            }

            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
