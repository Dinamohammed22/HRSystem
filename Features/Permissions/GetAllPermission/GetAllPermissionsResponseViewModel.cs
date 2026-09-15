using AutoMapper;
using EasyTask.Features.Common.Permissions.DTOs;
using EasyTask.Features.Common.Vacations.DTOs;

namespace EasyTask.Features.Vacations.GetAllVacations
{
    public class GetAllPermissionsResponseViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int MaxHours { get; set; }
        public int MinHours { get; set; }
        public int MaxRepeatTimes { get; set; }
        public int MaxHoursPerMonth { get; set; }
    }
    public class GetAllPermissionsResponseProfile : Profile
    {
        public GetAllPermissionsResponseProfile()
        {
            CreateMap<GetPermissionByIdDTO, GetAllPermissionsResponseViewModel>();
        }
    }
}
