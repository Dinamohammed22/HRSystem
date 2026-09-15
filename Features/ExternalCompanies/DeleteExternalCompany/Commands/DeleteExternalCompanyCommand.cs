using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.ExternalComapnies;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.ExternalCompanys.DeleteExternalCompany.Commands
{
    public record DeleteExternalCompanyCommand(string ID):IRequestBase<bool>;
    public class DeleteExternalCompanyCommandHandler : RequestHandlerBase<ExternalCompany, DeleteExternalCompanyCommand, bool>
    {
        public DeleteExternalCompanyCommandHandler(RequestHandlerBaseParameters<ExternalCompany> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteExternalCompanyCommand request, CancellationToken cancellationToken)
        {
            var ExternalCompany = await _repository
                  .Get(s => s.ID == request.ID)
                  .Include(s => s.ExternalMembers) 
                  .FirstOrDefaultAsync();

            if (ExternalCompany == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            if (ExternalCompany.ExternalMembers != null && ExternalCompany.ExternalMembers.Any())
                return RequestResult<bool>.Failure(ErrorCode.CannotDelete); 

            _repository.Delete(ExternalCompany);
             _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
