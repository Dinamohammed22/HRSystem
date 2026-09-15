using AutoMapper;
using EasyTask.Models.Projects;
using EasyTask.Models.WorkPackages;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Features.Common.WorkPackages.DTOs
{
    public class GetAllWorkPackagesDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
    public class GetAllWorkPackagesDTOProfile : Profile
    {
        public GetAllWorkPackagesDTOProfile()
        {
            CreateMap<WorkPackage, GetAllWorkPackagesDTO>()
               .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name));
        }
    }
}
