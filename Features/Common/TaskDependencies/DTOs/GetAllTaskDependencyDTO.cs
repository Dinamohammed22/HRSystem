using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;
using EasyTask.Models.TaskDependencies;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Features.Common.TaskDependencies.DTOs
{
    public class GetAllTaskDependencyDTO
    {
        public Dependencies DependencyType { get; set; }

        public string SourceTaskId { get; set; }

        public string SourceTaskName { get; set; }
        public string DestinationTaskId { get; set; }

        public string DestinationTaskName { get; set; }

    }
    public class GetAllTaskDependencyDTOProfile : Profile
    {
        public GetAllTaskDependencyDTOProfile()
        {
            CreateMap<TaskDependency, GetAllTaskDependencyDTO>()
                           .ForMember(dest => dest.SourceTaskName,
                               opt => opt.MapFrom(src => src.SourceTask != null
                                   ? src.SourceTask.Name
                                   : null))

                           .ForMember(dest => dest.DestinationTaskName,
                               opt => opt.MapFrom(src => src.DestinationTask != null
                                   ? src.DestinationTask.Name
                                   : null))

                           .ForMember(dest => dest.SourceTaskId,
                               opt => opt.MapFrom(src => src.SourceTaskId))

                           .ForMember(dest => dest.DestinationTaskId,
                               opt => opt.MapFrom(src => src.DestinationTaskId))

                           .ForMember(dest => dest.DependencyType,
                               opt => opt.MapFrom(src => src.DependencyType));
        }
    }
}
