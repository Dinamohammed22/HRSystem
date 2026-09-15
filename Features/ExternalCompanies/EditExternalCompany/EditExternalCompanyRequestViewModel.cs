using AutoMapper;
using EasyTask.Features.ExternalCompanies.EditExternalCompany.Commands;
using FluentValidation;

namespace EasyTask.Features.ExternalCompanies.EditExternalCompany
{
    public record EditExternalCompanyRequestViewModel(
       string ID,
        string? Name,
        string? Location
    );
    public class EditExternalCompanyRequestValidator : AbstractValidator<EditExternalCompanyRequestViewModel>
    {
        public EditExternalCompanyRequestValidator()
        {

        }
    }
    public class EditExternalCompanyRequestProfile : Profile
    {
        public EditExternalCompanyRequestProfile()
        {
            CreateMap<EditExternalCompanyRequestViewModel, EditExternalCompanyCommand>();
        }
    }
}
