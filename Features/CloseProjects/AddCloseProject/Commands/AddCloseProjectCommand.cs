using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Projects.EditProjectStatus.Command;
using EasyTask.Models.CloseProjects;
using EasyTask.Models.Enums;

namespace EasyTask.Features.CloseProjects.AddCloseProject.Commands
{
    public record AddCloseProjectCommand(string? CandidateId,string ProjectId, string ProjectCloseReason, int CloseDuration
        , bool HasCloseImpact, string InternalCloseReason, string ExternalCloseReason) : IRequestBase<bool>;
    public class AddCloseProjectCommandHandler : RequestHandlerBase<CloseProject, AddCloseProjectCommand, bool>
    {
        public AddCloseProjectCommandHandler(RequestHandlerBaseParameters<CloseProject> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AddCloseProjectCommand request, CancellationToken cancellationToken)
        {
            var candidateId = request.CandidateId;

            if (string.IsNullOrEmpty(candidateId))
            {
                candidateId = _userState.UserID;
            }

            if (string.IsNullOrEmpty(candidateId))
            {
                return RequestResult<bool>.Failure(ErrorCode.Unauthorize, "CandidateId is required.");
            }

            var permission = new CloseProject()
            {
                CandidateId = candidateId,
                ProjectCloseReason=request.ProjectCloseReason,
                CloseDuration=request.CloseDuration,
                HasCloseImpact=request.HasCloseImpact,
                InternalCloseReason=request.InternalCloseReason,
                ExternalCloseReason=request.ExternalCloseReason,
                ProjectId=request.ProjectId
            };

            _repository.Add(permission);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
