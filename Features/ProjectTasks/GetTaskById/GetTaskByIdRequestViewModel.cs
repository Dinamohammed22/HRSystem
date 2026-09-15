using AutoMapper;
using EasyTask.Features.Common.Shifts.Queries;
using EasyTask.Features.Common.Tasks.Queries;
using FluentValidation;

namespace EasyTask.Features.Shifts.GetShiftById
{
    public record GetTaskByIdRequestViewModel(string ID);
    public class GetTaskByIdRequestValidator : AbstractValidator<GetTaskByIdRequestViewModel>
    {
        public GetTaskByIdRequestValidator()
        {
        }
    }
    public class GetTaskByIdRequestProfile : Profile
    {
        public GetTaskByIdRequestProfile()
        {
            CreateMap<GetTaskByIdRequestViewModel, GetTaskByIdQuery>();
        }
    }
}
