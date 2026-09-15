using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectChangeRequests;

namespace EasyTask.Features.ProjectChangeRequests.CreateProjectChangeRequest.Commands
{
    public record CreateProjectChangeRequestCommand(string? CandidateId, string ProjectChangeReason,string ProjectId,
        ProjectChangeType ProjectChangeType, ProjectChangeImpact ProjectChangeImpact) : IRequestBase<bool>;
    public class CreateProjectChangeRequestCommandHandler : RequestHandlerBase<ProjectChangeRequest, CreateProjectChangeRequestCommand, bool>
    {
        public CreateProjectChangeRequestCommandHandler(RequestHandlerBaseParameters<ProjectChangeRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateProjectChangeRequestCommand request, CancellationToken cancellationToken)
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

            var permission = new ProjectChangeRequest()
            {
                CandidateId = candidateId,
                ProjectChangeReason = request.ProjectChangeReason,
                ProjectChangeType= request.ProjectChangeType,
                ProjectChangeImpact=request.ProjectChangeImpact,
                RequestStatus = RequestStatus.Pending,
                ProjectId=request.ProjectId
            };

            _repository.Add(permission);
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
