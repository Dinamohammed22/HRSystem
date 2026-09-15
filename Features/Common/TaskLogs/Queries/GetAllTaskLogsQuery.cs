using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.TaskLogs.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.TaskLogs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.TaskLogsLogs.Queries
{
    public record GetAllTaskLogsQuery(
        DateOnly? From,
        DateOnly? TO,
        string? TaskId,
        int pageIndex = 1,
        int pageSize = 100
    ) : IRequestBase<PagingViewModel<GetAllTaskLogsDTO>>;
    public class GetAllTaskLogsQueryHandler : RequestHandlerBase<TaskLog, GetAllTaskLogsQuery, PagingViewModel<GetAllTaskLogsDTO>>
    {
        public GetAllTaskLogsQueryHandler(RequestHandlerBaseParameters<TaskLog> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllTaskLogsDTO>>> Handle(GetAllTaskLogsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<TaskLog>(true);

            predicate = predicate
                .And(t => !string.IsNullOrEmpty(request.TaskId) || t.ProjectTaskId == request.TaskId)
                .And(t => !request.From.HasValue || DateOnly.FromDateTime(t.CreatedDate) >= request.From.Value)
                .And(t => !request.TO.HasValue || DateOnly.FromDateTime(t.CreatedDate) <= request.TO.Value);

            var model = await _repository
                .Get(predicate).Include(p=>p.ProjectTask).Include(u=>u.User)
                .Map<GetAllTaskLogsDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);
            

            return RequestResult<PagingViewModel<GetAllTaskLogsDTO>>.Success(model);
        }
    }
}
