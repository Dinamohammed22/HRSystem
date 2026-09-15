using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.ExternalCompanies.DTOs;
using EasyTask.Features.Common.Shifts.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.ExternalComapnies;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.ExternalCompanies.Queries
{
    public record GetAllExternalCompaniesQuery(string? Name, int pageIndex = 1,
        int pageSize = 100) : IRequestBase<PagingViewModel<GetExternalCompanyByIdDTO>>;
    public class GetAllExternalCompaniesQueryHandler : RequestHandlerBase<ExternalCompany, GetAllExternalCompaniesQuery, PagingViewModel<GetExternalCompanyByIdDTO>>
    {
        public GetAllExternalCompaniesQueryHandler(RequestHandlerBaseParameters<ExternalCompany> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetExternalCompanyByIdDTO>>> Handle(GetAllExternalCompaniesQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<ExternalCompany>(true);
            predicate = predicate.And(c => string.IsNullOrEmpty(request.Name) || c.Name.Contains(request.Name));

            var query =await _repository.Get(predicate).Map<GetExternalCompanyByIdDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize); ;

            return RequestResult<PagingViewModel<GetExternalCompanyByIdDTO>>.Success(query);
        }
    }
}
