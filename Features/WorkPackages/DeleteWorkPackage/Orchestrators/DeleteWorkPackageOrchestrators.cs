
using EasyTask.Common.Requests;
using EasyTask.Features.Tasks.DeleteWorkPackage.Commands;
using EasyTask.Helpers;
using EasyTask.Models.ProjectTasks;
using EasyTask.Models.WorkPackages;
using EasyWorkPackageDependency.Features.WorkPackageDependencys.DeleteWorkPackageDependency.Commands;

namespace EasyTask.Features.ProjectTasks.DeleteWorkPackage.Orchestrators
{
    public record DeleteWorkPackageOrchestrators(string ID):IRequestBase<bool>;
    public class DeleteWorkPackageOrchestratorsHandler : RequestHandlerBase<WorkPackage, DeleteWorkPackageOrchestrators, bool>
    {
        public DeleteWorkPackageOrchestratorsHandler(RequestHandlerBaseParameters<WorkPackage> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteWorkPackageOrchestrators request, CancellationToken cancellationToken)
        {
            var WorkPackage = await _mediator.Send(request.MapOne<DeleteWorkPackageCommand>());
            if (!WorkPackage.IsSuccess)
            {
                return RequestResult<bool>.Failure(WorkPackage.ErrorCode);
            }
            var WorkPackagedependency = await _mediator.Send(new DeleteWorkPackageDependencyCommand(request.ID));
            if (!WorkPackagedependency.IsSuccess)
            {
                return RequestResult<bool>.Failure(WorkPackagedependency.ErrorCode);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
