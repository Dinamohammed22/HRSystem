using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Permissions.DTOs;
using EasyTask.Features.Common.Vacations.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Permissions;
using EasyTask.Models.Vacations;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Permissions.Queries
{
    public record GetPermissionsQuery(string? Name, int pageIndex = 1,
        int pageSize = 100) : IRequestBase<PagingViewModel<GetPermissionByIdDTO>>;
    public class GetPermissionsQueryHandler : RequestHandlerBase<Permission, GetPermissionsQuery, PagingViewModel<GetPermissionByIdDTO>>
    {
        public GetPermissionsQueryHandler(RequestHandlerBaseParameters<Permission> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetPermissionByIdDTO>>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Permission>(true);
            predicate = predicate.And(c => string.IsNullOrEmpty(request.Name) || c.Name.Contains(request.Name));

            var query = await _repository.Get(predicate).Map<GetPermissionByIdDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize); ;

            return RequestResult<PagingViewModel<GetPermissionByIdDTO>>.Success(query);
        }
    }
}
