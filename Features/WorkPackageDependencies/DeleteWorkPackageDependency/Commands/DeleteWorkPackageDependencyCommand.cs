using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.WorkPackageDependencies;
using Microsoft.EntityFrameworkCore;

namespace EasyWorkPackageDependency.Features.WorkPackageDependencys.DeleteWorkPackageDependency.Commands
{
    public record DeleteWorkPackageDependencyCommand(string ID):IRequestBase<bool>;
    public class DeleteWorkPackageDependencyCommandHandler : RequestHandlerBase<WorkPackageDependency, DeleteWorkPackageDependencyCommand, bool>
    {
        public DeleteWorkPackageDependencyCommandHandler(RequestHandlerBaseParameters<WorkPackageDependency> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteWorkPackageDependencyCommand request, CancellationToken cancellationToken)
        {
            var workPackageDependencies = await _repository.Get(s => s.SourceWorkPackageId == request.ID|| s.DestinationWorkPackageId == request.ID).ToListAsync();

            foreach (var item in workPackageDependencies)
            {
                _repository.Delete(item);
            }

             _repository.SaveChanges();

            return RequestResult<bool>.Success(true);

        }
    }
}
