using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.SubTasks.DTOs;
using EasyTask.Features.Common.TaskDependencies.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.SubTasks;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.SubTasks.Queries
{
    public record GetSubTaskByIdQuery(string ID):IRequestBase<GetSubTaskByIdDTO>;
    public class GetSubTaskByIdQueryHandler : RequestHandlerBase<SubTask, GetSubTaskByIdQuery, GetSubTaskByIdDTO>
    {
        public GetSubTaskByIdQueryHandler(RequestHandlerBaseParameters<SubTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetSubTaskByIdDTO>> Handle(GetSubTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var dto = await _repository.Get(x => x.ID == request.ID).FirstOrDefaultAsync();
            if (dto == null)
            {
                return RequestResult<GetSubTaskByIdDTO>.Failure(ErrorCode.NotFound);
            }

            return RequestResult<GetSubTaskByIdDTO>.Success(dto.MapOne<GetSubTaskByIdDTO>());
        }
    }
}
