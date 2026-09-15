using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.ExternalComapnies;

namespace EasyTask.Features.ExternalCompanies.EditExternalCompany.Commands
{
    public record EditExternalCompanyCommand(
        string ID,
        string? Name,
        string? Location
    ) : IRequestBase<bool>;
    public class EditExternalCompanyCommandHandler : RequestHandlerBase<ExternalCompany, EditExternalCompanyCommand, bool>
    {
        public EditExternalCompanyCommandHandler(RequestHandlerBaseParameters<ExternalCompany> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditExternalCompanyCommand request, CancellationToken cancellationToken)
        {
            var ExternalCompany = await _repository.GetByIDAsync(request.ID);
            if (ExternalCompany == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            ExternalCompany.Name = request.Name ?? ExternalCompany.Name;
            ExternalCompany.Location = request.Location ?? ExternalCompany.Location;

            _repository.SaveIncluded(ExternalCompany, nameof(ExternalCompany.Name), nameof(ExternalCompany.Location));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
