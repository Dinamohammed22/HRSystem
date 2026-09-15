using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.WorkPackages;

namespace EasyTask.Features.WorkPackages.EditWorkPackage.Commands
{
    public record EditWorkPackageCommand(
        string ID,
        string? Name,
        DateTime? StartDate,
        DateTime? EndDate,
        string? ProjectId
    ) : IRequestBase<bool>;
    public class EditWorkPackageCommandHandler : RequestHandlerBase<WorkPackage, EditWorkPackageCommand, bool>
    {
        public EditWorkPackageCommandHandler(RequestHandlerBaseParameters<WorkPackage> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditWorkPackageCommand request, CancellationToken cancellationToken)
        {
            var WorkPackage = await _repository.GetByIDAsync(request.ID);
            if (WorkPackage == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            WorkPackage.Name = request.Name ?? WorkPackage.Name;
            WorkPackage.StartDate = request.StartDate ?? WorkPackage.StartDate;
            WorkPackage.EndDate = request.EndDate ?? WorkPackage.EndDate;
            WorkPackage.ProjectId = request.ProjectId ?? WorkPackage.ProjectId;

            _repository.SaveIncluded(WorkPackage, nameof(WorkPackage.Name), 
                nameof(WorkPackage.StartDate),
                nameof(WorkPackage.ProjectId),
                nameof(WorkPackage.EndDate));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
