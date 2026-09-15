using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.ProjectCandidates.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.ProjectCandidates;
using EasyTask.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.ProjectCandidates.Queries
{
    public record GetProjectInternalMembersQuery(string ProjectId,string? SearchText, int pageIndex = 1, int pageSize = 100) : IRequestBase<PagingViewModel<GetProjectInternalMembersDTO>>;

    public class GetProjectInternalMembersQueryHandler : RequestHandlerBase<ProjectCandidate, GetProjectInternalMembersQuery, PagingViewModel<GetProjectInternalMembersDTO>>
    {
        public GetProjectInternalMembersQueryHandler(RequestHandlerBaseParameters<ProjectCandidate> requestParameters) : base(requestParameters)
        {
        }
        public async override Task<RequestResult<PagingViewModel<GetProjectInternalMembersDTO>>> Handle(GetProjectInternalMembersQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<ProjectCandidate>(true);

            var searchText = request.SearchText?.ToLower();

            predicate = predicate.And(c =>
                string.IsNullOrEmpty(searchText) ||
                (c.Candidate.FirstName + " " + c.Candidate.LastName).ToLower().Contains(searchText) ||
                c.Candidate.Email.ToLower().Contains(searchText)
            );

            var query = await _repository
                .Get(predicate)
                .Where(c => c.ProjectId == request.ProjectId)
                .Include(c => c.Candidate).ThenInclude(c => c.Position)
                .Map<GetProjectInternalMembersDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetProjectInternalMembersDTO>>.Success(query);
        }

    }
}
