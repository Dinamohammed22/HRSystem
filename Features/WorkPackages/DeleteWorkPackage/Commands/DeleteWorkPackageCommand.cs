using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.ProjectTasks;
using EasyTask.Models.WorkPackages;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Tasks.DeleteWorkPackage.Commands
{
    public record DeleteWorkPackageCommand(string ID):IRequestBase<bool>;
    public class DeleteWorkPackageCommandHandler : RequestHandlerBase<WorkPackage, DeleteWorkPackageCommand, bool>
    {
        public DeleteWorkPackageCommandHandler(RequestHandlerBaseParameters<WorkPackage> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteWorkPackageCommand request, CancellationToken cancellationToken)
        {
            var WorkPackage = await _repository
                  .Get(s => s.ID == request.ID).Include(c=>c.ProjectTasks)
                  .FirstOrDefaultAsync();

            if (WorkPackage == null )
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            if (WorkPackage.ProjectTasks.Any())
            {
                return RequestResult<bool>.Failure(ErrorCode.CannotDelete);
            }
            _repository.Delete(WorkPackage);
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
