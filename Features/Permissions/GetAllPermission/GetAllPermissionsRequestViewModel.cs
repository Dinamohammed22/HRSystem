using AutoMapper;
using EasyTask.Features.Common.Permissions.Queries;
using FluentValidation;

namespace EasyTask.Features.Permissions.GetAllPermissions
{
    public record GetAllPermissionsRequestViewModel(string? Name, int pageIndex = 1, int pageSize = 100);
    public class GetAllPermissionsRequestValidator : AbstractValidator<GetAllPermissionsRequestViewModel>
    {
        public GetAllPermissionsRequestValidator()
        {
        }
    }
    public class GetAllPermissionsRequestProfile : Profile
    {
        public GetAllPermissionsRequestProfile()
        {
            CreateMap<GetAllPermissionsRequestViewModel, GetPermissionsQuery>();
        }
    }
}
