using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Models.Candidates;
using EasyTask.Models.ProjectExternalMembers;

namespace EasyTask.Features.Common.ProjectExternalMembers.DTOs
{
    public class GetProjectExternalMembersDTO
    {
        public string ID { get; set; }
        public string CandidateId {  get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmail {  get; set; }
        public string PositionName { get; set; }
    }
    public class ProjectExternalMembersDTOProfile : Profile
    {
        public ProjectExternalMembersDTOProfile()
        {
            CreateMap<ProjectExternalMember, GetProjectExternalMembersDTO>()
                .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => string.Concat(src.ExternalMember.Name)))
                .ForMember(dest => dest.CandidateEmail, opt => opt.MapFrom(src => src.ExternalMember.Email))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.ExternalMember.Position.Name));
        }
    }
}
