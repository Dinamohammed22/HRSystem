using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.ExternalComapnies;
using Microsoft.IdentityModel.Tokens;

namespace EasyTask.Features.Common.ExternalCompanies.Quereies
{
    public record ExternalCompanySelectListQuery() : IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class ExternalCompanySelectListQueryHandler : RequestHandlerBase<ExternalCompany, ExternalCompanySelectListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public ExternalCompanySelectListQueryHandler(RequestHandlerBaseParameters<ExternalCompany> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(ExternalCompanySelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get().ToSelectListViewModel();
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
