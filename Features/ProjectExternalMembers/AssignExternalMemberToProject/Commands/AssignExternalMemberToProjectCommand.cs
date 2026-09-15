
using EasyTask.Common.Requests;
using EasyTask.Models.ProjectExternalMembers;
using Microsoft.EntityFrameworkCore;

namespace EasyProject.Features.ExternalMemberProjects.AssignExternalMemberToProject.Commands
{
    public record AssignExternalMemberToProjectCommand(string ProjectId,string ExternalMemberId) : IRequestBase<bool>;
    public class AssignExternalMemberToProjectCommandHandler : RequestHandlerBase<ProjectExternalMember, AssignExternalMemberToProjectCommand, bool>
    {
        public AssignExternalMemberToProjectCommandHandler(RequestHandlerBaseParameters<ProjectExternalMember> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AssignExternalMemberToProjectCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.Get(p => p.ProjectId == request.ProjectId && p.ExternalMemberId == request.ExternalMemberId).FirstOrDefaultAsync();
            if (existing != null)
            {
                return RequestResult<bool>.Success(true);
            }
            var externalMemberProject = new ProjectExternalMember
            {
                 ProjectId = request.ProjectId,
                 ExternalMemberId = request.ExternalMemberId
            };
            _repository.Add(externalMemberProject);      
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
