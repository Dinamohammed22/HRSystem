
using EasyTask.Common.Requests;
using EasyTask.Models.ProjectCandidates;
using Microsoft.EntityFrameworkCore;

namespace EasyProject.Features.CandidateProjects.AssignCandidateToProject.Commands
{
    public record AssignCandidateToProjectCommand(string ProjectId,string CandidateId) : IRequestBase<bool>;
    public class AssignCandidateToProjectCommandHandler : RequestHandlerBase<ProjectCandidate, AssignCandidateToProjectCommand, bool>
    {
        public AssignCandidateToProjectCommandHandler(RequestHandlerBaseParameters<ProjectCandidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AssignCandidateToProjectCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.Get(p => p.ProjectId == request.ProjectId && p.CandidateId == request.CandidateId).FirstOrDefaultAsync();
            if (existing != null)
            {
                return RequestResult<bool>.Success(true);
            }
            var CandidateProject = new ProjectCandidate
            {
                 ProjectId = request.ProjectId,
                 CandidateId = request.CandidateId
            };
            _repository.Add(CandidateProject);      
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
