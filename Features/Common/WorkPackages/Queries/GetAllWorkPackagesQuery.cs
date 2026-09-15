using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Helpers;
using EasyTask.Models.WorkPackages;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.WorkPackages.DTOs
{
    public record GetAllWorkPackagesQuery(string? ProjectId,string? SearchText, int pageIndex = 1, int pageSize = 100) : IRequestBase<PagingViewModel<GetAllWorkPackagesDTO>>;
    public class GetAllWorkPackagesQueryHandler : RequestHandlerBase<WorkPackage, GetAllWorkPackagesQuery, PagingViewModel<GetAllWorkPackagesDTO>>
    {
        public GetAllWorkPackagesQueryHandler(RequestHandlerBaseParameters<WorkPackage> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllWorkPackagesDTO>>> Handle(GetAllWorkPackagesQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<WorkPackage>(true);

            if (!string.IsNullOrEmpty(request.SearchText))
            {
                predicate = predicate.And(c =>
                    c.Name.Contains(request.SearchText) ||
                    (c.Project != null && c.Project.Name.Contains(request.SearchText)));
            }

            if (!string.IsNullOrEmpty(request.ProjectId))
            {
                predicate = predicate.And(c => c.ProjectId == request.ProjectId);
            }

            var query = await _repository
                .Get(predicate)
                .Map<GetAllWorkPackagesDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllWorkPackagesDTO>>.Success(query);
        }
    }
}
