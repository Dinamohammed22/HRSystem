using AutoMapper;
using EasyTask.Features.Common.WorkPackages.DTOs;

namespace EasyTask.Features.WorkPackages.GetWorkPackageById
{
    public record GetWorkPackageByIdResponseViewModel(string ID, string Name, DateTime StartDate, DateTime EndDate, string ProjectId, string ProjectName);
    public class GetWorkPackageByIdResponseProfile : Profile
    {
        public GetWorkPackageByIdResponseProfile()
        {
            CreateMap<GetWorkPackageByIdDTO, GetWorkPackageByIdResponseViewModel>();
        }
    }
}
