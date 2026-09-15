using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Features.Common.ProjectLists.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectLists.ExportProjectLists
{
    public class ExportProjectListsEndpoint : EndpointBase<ExportProjectListsRequestViewModel, ExportProjectListsResponseViewModel>
    {
        public ExportProjectListsEndpoint(EndpointBaseParameters<ExportProjectListsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ExportProjectLists })]
        public async Task<ActionResult<EndPointResponse<ExportProjectListsResponseViewModel>>> ExportProjectLists([FromQuery] ExportProjectListsRequestViewModel? filter)
        {
            var query = filter.MapOne<ExportProjectListsQuery>();
            var result = await _mediator.Send(query);

            if (result.IsSuccess && result.Data != null)
            {
                var fileResult = new FileContentResult(result.Data.FileContent ?? Array.Empty<byte>(), result.Data.ContentType ?? "application/octet-stream")
                {
                    FileDownloadName = result.Data.FileName ?? "export.xlsx",
                    EnableRangeProcessing = false
                };

                return fileResult;
            }

            return EndPointResponse<ExportProjectListsResponseViewModel>
                .Failure(ErrorCode.NotFound, "No ProjectLists found.");
        }
    }
}
