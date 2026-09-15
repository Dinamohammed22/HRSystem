using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Models.Candidates;
using EasyTask.Models.ProjectCandidates;

namespace EasyTask.Features.Common.ProjectCandidates.DTOs
{
    public class GetProjectInternalMembersDTO
    {
        public string ID { get; set; }
        public string CandidateId {  get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmail {  get; set; }
        public string PositionName { get; set; }
    }
    public class ProjectCandidatesDTOProfile : Profile
    {
        public ProjectCandidatesDTOProfile()
        {
            CreateMap<ProjectCandidate, GetProjectInternalMembersDTO>()
                .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => string.Concat(src.Candidate.FirstName," ", src.Candidate.LastName)))
                .ForMember(dest => dest.CandidateEmail, opt => opt.MapFrom(src => src.Candidate.Email))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Candidate.PositionName ?? src.Candidate.Position.Name));
        }
    }
}
