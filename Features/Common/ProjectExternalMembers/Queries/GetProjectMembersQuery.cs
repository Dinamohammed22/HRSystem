using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.ProjectExternalMembers.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.ProjectExternalMembers;
using EasyTask.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.ProjectExternalMembers.Queries
{
    public record GetProjectExternalMembersQuery(string ProjectId,string? SearchText, int pageIndex = 1, int pageSize = 100) : IRequestBase<PagingViewModel<GetProjectExternalMembersDTO>>;

    public class ProjectExternalMembersQueryHandler : RequestHandlerBase<ProjectExternalMember, GetProjectExternalMembersQuery, PagingViewModel<GetProjectExternalMembersDTO>>
    {
        public ProjectExternalMembersQueryHandler(RequestHandlerBaseParameters<ProjectExternalMember> requestParameters) : base(requestParameters)
        {
        }
        public async override Task<RequestResult<PagingViewModel<GetProjectExternalMembersDTO>>> Handle(GetProjectExternalMembersQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<ProjectExternalMember>(true);

            var searchText = request.SearchText?.ToLower();

            predicate = predicate.And(c =>
                string.IsNullOrEmpty(searchText) ||
                (c.ExternalMember.Name).ToLower().Contains(searchText) ||
                c.ExternalMember.Email.ToLower().Contains(searchText)
            );

            var query = await _repository
                .Get(predicate)
                .Where(c => c.ProjectId == request.ProjectId)
                .Include(c => c.ExternalMember).ThenInclude(c => c.Position)
                .Map<GetProjectExternalMembersDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetProjectExternalMembersDTO>>.Success(query);
        }

    }
}
