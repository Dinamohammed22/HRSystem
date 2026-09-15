using AutoMapper;
using EasyTask.Models.WorkPackages;

namespace EasyTask.Features.Common.WorkPackages.DTOs
{
    public record GetWorkPackageByIdDTO(string ID, string Name, DateTime StartDate,DateTime EndDate, string ProjectId, string ProjectName);
    public class GetWorkPackageByIdDTOProfile : Profile
    {
        public GetWorkPackageByIdDTOProfile()
        {
            CreateMap<WorkPackage, GetWorkPackageByIdDTO>()
               .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name));
        }
    }
}
