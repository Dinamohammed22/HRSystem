using AutoMapper;
using EasyTask.Features.Common.ProjectExternalMembers.Queries;
using EasyTask.Models.Enums;
using FluentValidation;
using System.Security.Policy;

namespace EasyTask.Features.ProjectExternalMembers.GetProjectExternalMembers
{
    public record GetProjectExternalMembersRequestViewModel(string ProjectId, string? SearchText, int pageIndex = 1, int pageSize = 100);
    public class GetProjectExternalMembersRequestValidator : AbstractValidator<GetProjectExternalMembersRequestViewModel>
    {
        public GetProjectExternalMembersRequestValidator()
        {
        }
    }
    public class GetProjectExternalMembersRequestProfile : Profile
    {
        public GetProjectExternalMembersRequestProfile() {
            CreateMap<GetProjectExternalMembersRequestViewModel, GetProjectExternalMembersQuery>();
        }
    }
}
