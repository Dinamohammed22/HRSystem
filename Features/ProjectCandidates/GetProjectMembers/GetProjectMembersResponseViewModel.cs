using AutoMapper;
using EasyTask.Features.Common.ProjectCandidates.DTOs;

namespace EasyTask.Features.ProjectCandidates.GetProjectInternalMembers
{
    public record GetProjectInternalMembersResponseViewModel
        (
        string ID,
        string CandidateId,
        string CandidateName,
        string CandidateEmail,
        string PositionName
        );
    public class GetProjectInternalMembersResponseProfile : Profile
    {
        public GetProjectInternalMembersResponseProfile()
        {
            CreateMap<GetProjectInternalMembersDTO, GetProjectInternalMembersResponseViewModel>();
        }
    }
}
