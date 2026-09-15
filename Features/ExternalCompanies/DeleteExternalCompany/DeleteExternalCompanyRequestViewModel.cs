using AutoMapper;
using EasyTask.Features.ExternalCompanys.DeleteExternalCompany.Commands;
using FluentValidation;

namespace EasyTask.Features.ExternalCompanys.DeleteExternalCompany
{
    public record DeleteExternalCompanyRequestViewModel(string ID);
    public class DeleteExternalCompanyRequestValidator : AbstractValidator<DeleteExternalCompanyRequestViewModel>
    {
        public DeleteExternalCompanyRequestValidator()
        {
        }
    }
    public class DeleteExternalCompanyRequestProfile : Profile
    {
        public DeleteExternalCompanyRequestProfile()
        {
            CreateMap<DeleteExternalCompanyRequestViewModel, DeleteExternalCompanyCommand>();
        }
    }
}
