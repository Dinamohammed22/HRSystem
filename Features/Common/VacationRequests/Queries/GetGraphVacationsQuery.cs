using EasyTask.Common.Requests;
using EasyTask.Features.Common.VacationRequests.DTOs;
using EasyTask.Models.Enums;
using EasyTask.Models.VacationRequests;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.VacationRequests.Queries
{
    public record GetGraphVacationsQuery(DateOnly FromDate, DateOnly ToDate) :IRequestBase<List<GetGraphVacationsDTO>>;
    public class GetGraphVacationsQueryHandler : RequestHandlerBase<VacationRequest, GetGraphVacationsQuery, List<GetGraphVacationsDTO>>
    {
        public GetGraphVacationsQueryHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<GetGraphVacationsDTO>>> Handle( GetGraphVacationsQuery request, CancellationToken cancellationToken)
        {
            // Step 1: fetch the raw vacation requests that overlap the date range
            var vacations = await _repository.Get()
                .Include(v => v.Vacation)
                .Where(v => v.VacationRequestStatus == RequestStatus.SecondApproval &&
                            v.ToDate >= request.FromDate && v.FromDate <= request.ToDate)
                .ToListAsync(cancellationToken);

            // Step 2: expand each vacation into individual dates on client
            var expanded = vacations
                .SelectMany(v =>
                {
                    var startDate = v.FromDate < request.FromDate ? request.FromDate : v.FromDate;
                    var endDate = v.ToDate > request.ToDate ? request.ToDate : v.ToDate;

                    int daysCount = (endDate.DayNumber - startDate.DayNumber + 1);
                    if (daysCount <= 0) return Enumerable.Empty<(DateOnly Date, string VacationName)>();

                    return Enumerable.Range(0, daysCount)
                    .Select(offset => (Date: startDate.AddDays(offset), VacationName: v.Vacation.Name));
                })
                .GroupBy(x => new { x.Date, x.VacationName })
                .Select(g => new GetGraphVacationsDTO
                {
                    Date = g.Key.Date,
                    VacationName = g.Key.VacationName,
                    NumOfCandidateTakeVacation = g.Count()
                })
                .ToList();


            return RequestResult<List<GetGraphVacationsDTO>>.Success(expanded);
        }

    }
}
