using AutoMapper;
using EasyTask.Features.Common.ProjectCandidates.Queries;
using EasyTask.Models.Enums;
using FluentValidation;
using System.Security.Policy;

namespace EasyTask.Features.ProjectCandidates.GetProjectInternalMembers
{
    public record GetProjectInternalMembersRequestViewModel(string ProjectId, string? SearchText, int pageIndex = 1, int pageSize = 100);
    public class GetProjectInternalMembersRequestValidator : AbstractValidator<GetProjectInternalMembersRequestViewModel>
    {
        public GetProjectInternalMembersRequestValidator()
        {
        }
    }
    public class GetProjectInternalMembersRequestProfile : Profile
    {
        public GetProjectInternalMembersRequestProfile() {
            CreateMap<GetProjectInternalMembersRequestViewModel, GetProjectInternalMembersQuery>();
        }
    }
}
