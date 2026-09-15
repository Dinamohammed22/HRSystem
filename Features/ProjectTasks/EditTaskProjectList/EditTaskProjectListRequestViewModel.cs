using AutoMapper;
using EasyTask.Features.ProjectTasks.EditTaskProjectList.Commands;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.ProjectTasks.EditTaskProjectList
{
    public record EditTaskProjectListRequestViewModel(string ID,string ProjectListId);
    public class EditTaskProjectListRequestValidator : AbstractValidator<EditTaskProjectListRequestViewModel>
    {
        public EditTaskProjectListRequestValidator()
        {
        }
    }
    public class EditTaskProjectListRequestProfile : Profile
    {
        public EditTaskProjectListRequestProfile()
        {
            CreateMap<EditTaskProjectListRequestViewModel, EditTaskProjectListCommand>();
        }
    }
}
