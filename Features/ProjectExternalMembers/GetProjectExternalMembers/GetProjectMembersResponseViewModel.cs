using AutoMapper;
using EasyTask.Features.Common.ProjectExternalMembers.DTOs;

namespace EasyTask.Features.ProjectExternalMembers.GetProjectExternalMembers
{
    public record GetProjectExternalMembersResponseViewModel
        (
        string ID,
        string CandidateId,
        string CandidateName,
        string CandidateEmail,
        string PositionName
        );
    public class GetProjectExternalMembersResponseProfile : Profile
    {
        public GetProjectExternalMembersResponseProfile()
        {
            CreateMap<GetProjectExternalMembersDTO, GetProjectExternalMembersResponseViewModel>();
        }
    }
}
