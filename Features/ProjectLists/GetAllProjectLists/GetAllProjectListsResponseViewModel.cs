using AutoMapper;
using EasyTask.Features.Common.ProjectLists.DTOs;
using EasyTask.Features.Common.ProjectTasks.DTOs;

namespace EasyTask.Features.Positions.GetAllProjectLists
{
    public class GetAllProjectListsResponseViewModel
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public int Sequence { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public List<GetAllTasksByProjectListDTO> Tasks { get; set; }
    }
    public class GetAllProjectListsResponseProfile : Profile
    {
        public GetAllProjectListsResponseProfile()
        {
            CreateMap<GetAllProjectListsDTO, GetAllProjectListsResponseViewModel>();
        }
    }
}
