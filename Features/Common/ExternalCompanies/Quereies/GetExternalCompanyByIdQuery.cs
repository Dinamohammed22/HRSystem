using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.ExternalCompanies.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.ExternalComapnies;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.ExternalCompanies.Quereies
{
    public record GetExternalCompanyByIdQuery(string ID):IRequestBase<GetExternalCompanyByIdDTO>;
    public class GetExternalCompanyByIdQueryHandler : RequestHandlerBase<ExternalCompany, GetExternalCompanyByIdQuery, GetExternalCompanyByIdDTO>
    {
        public GetExternalCompanyByIdQueryHandler(RequestHandlerBaseParameters<ExternalCompany> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetExternalCompanyByIdDTO>> Handle(GetExternalCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var ExternalCompany = _repository.Get(c=>c.ID==request.ID).FirstOrDefault()!.MapOne<GetExternalCompanyByIdDTO>();
            if (ExternalCompany == null)
            {
                return RequestResult<GetExternalCompanyByIdDTO>.Failure(ErrorCode.NotFound);
            }
            return RequestResult<GetExternalCompanyByIdDTO>.Success(ExternalCompany);
        }
    }
}
