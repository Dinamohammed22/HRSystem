using EasyTask.Common.Requests;
using EasyTask.Features.Common.WorkPackageDependencies.DTO;
using EasyTask.Models.Enums;
using EasyTask.Models.WorkPackageDependencies;

namespace EasyTask.Features.WorkPackageDependencies.EditWorkPackageDependency.Command
{
    public record EditWorkPackageDependencyCommand(
        Dependencies DependencyType, 
        string SourceWorkPackageId,
        string DestinationWorkPackageId
    ) :IRequestBase<bool>;
    public class EditWorkPackageDependencyCommandHandler : RequestHandlerBase<WorkPackageDependency, EditWorkPackageDependencyCommand, bool>
    {
        public EditWorkPackageDependencyCommandHandler(RequestHandlerBaseParameters<WorkPackageDependency> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditWorkPackageDependencyCommand request, CancellationToken cancellationToken)
        {
            bool check = await _repository.AnyAsync(w => w.SourceWorkPackageId == request.SourceWorkPackageId &&
                w.DestinationWorkPackageId == request.DestinationWorkPackageId && w.DependencyType == request.DependencyType);
            if (!check)
            {
                
            }
            WorkPackageDependency workPackage = new WorkPackageDependency
            {
                SourceWorkPackageId=request.SourceWorkPackageId,
                DestinationWorkPackageId=request.DestinationWorkPackageId,
                DependencyType=request.DependencyType,
            };

            _repository.Add(workPackage);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
