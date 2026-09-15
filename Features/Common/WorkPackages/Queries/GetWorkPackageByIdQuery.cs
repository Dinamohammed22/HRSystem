using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.WorkPackages.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.WorkPackages;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.WorkPackages.Quereies
{
    public record GetWorkPackageByIdQuery(string ID):IRequestBase<GetWorkPackageByIdDTO>;
    public class GetWorkPackageByIdQueryHandler : RequestHandlerBase<WorkPackage, GetWorkPackageByIdQuery, GetWorkPackageByIdDTO>
    {
        public GetWorkPackageByIdQueryHandler(RequestHandlerBaseParameters<WorkPackage> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetWorkPackageByIdDTO>> Handle(GetWorkPackageByIdQuery request, CancellationToken cancellationToken)
        {
            var WorkPackage = _repository.Get(c=>c.ID==request.ID).Include(c=>c.Project).FirstOrDefault().MapOne<GetWorkPackageByIdDTO>();
            if (WorkPackage == null)
            {
                return RequestResult<GetWorkPackageByIdDTO>.Failure(ErrorCode.NotFound);
            }
            return RequestResult<GetWorkPackageByIdDTO>.Success(WorkPackage);
        }
    }
}
