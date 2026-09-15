using AutoMapper;
using EasyTask.Features.Common.ProjectLists.Queries;

namespace EasyTask.Features.Common.ProjectLists.DTOs
{
    public record ExportProjectListsDTO(byte[] FileContent, string FileName, string ContentType);
    public class ExportProjectListsProfile : Profile
    {
        public ExportProjectListsProfile()
        {
            CreateMap<ExportProjectListsQuery, GetAllProjectListsQuery>();
        }
    }
}
