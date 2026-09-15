using AutoMapper;
using EasyTask.Features.Common.ProjectLists.DTOs;

namespace EasyTask.Features.ProjectLists.ExportProjectLists
{
    public record ExportProjectListsResponseViewModel(byte[] FileContent, string FileName, string ContentType);
    public class ExportProjectListsResponseProfile : Profile
    {
        public ExportProjectListsResponseProfile()
        {
            CreateMap<ExportProjectListsDTO, ExportProjectListsResponseViewModel>();
        }
    }
}
