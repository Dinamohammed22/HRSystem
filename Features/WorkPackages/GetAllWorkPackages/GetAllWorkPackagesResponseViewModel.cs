using AutoMapper;
using EasyTask.Features.Common.WorkPackages.DTOs;

namespace EasyTask.Features.WorkPackages.GetAllWorkPackages
{
    public record GetAllWorkPackagesResponseViewModel(string ID, string Name, DateTime StartDate, DateTime EndDate, string ProjectId, string ProjectName);
    public class GetAllWorkPackagesResponseProfile : Profile
    {
        public GetAllWorkPackagesResponseProfile()
        {
            CreateMap<GetAllWorkPackagesDTO, GetAllWorkPackagesResponseViewModel>();
        }
    }
}
