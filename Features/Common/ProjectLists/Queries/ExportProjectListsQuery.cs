using EasyTask.Common.Requests;
using EasyTask.Features.Common.ProjectLists.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectLists;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace EasyTask.Features.Common.ProjectLists.Queries
{
    public record ExportProjectListsQuery(
        string ProjectId,
        string? WorkPackageId) :IRequestBase<ExportProjectListsDTO>;
    public class ExportProjectListsQueryHandler : RequestHandlerBase<ProjectList, ExportProjectListsQuery, ExportProjectListsDTO>
    {
        public ExportProjectListsQueryHandler(RequestHandlerBaseParameters<ProjectList> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<ExportProjectListsDTO>> Handle(ExportProjectListsQuery request, CancellationToken cancellationToken)
        {
            var projectListsRequest = request.MapOne<GetAllProjectListsQuery>();
            var projectLists = (await _mediator.Send(projectListsRequest)).Data;

            var allTasks = projectLists
                .SelectMany(pl => pl.Tasks.Select(t => new
                {
                    ProjectName = pl.ProjectName,
                    ProjectListName = pl.Name,
                    TaskName = t.Name,
                    TaskPriority = t.TaskPriority,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate
                }))
                .ToList();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Tasks");

            // ===== Title =====
            worksheet.Cells["A1:E1"].Merge = true;
            worksheet.Cells["A1"].Value = $"Project: {projectLists.FirstOrDefault()?.ProjectName}";
            worksheet.Cells["A1"].Style.Font.Size = 18;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            worksheet.Cells["A2:E2"].Merge = true;
            worksheet.Cells["A2"].Value = $"Work Package: {request.WorkPackageId ?? "All"}";
            worksheet.Cells["A2"].Style.Font.Size = 14;
            worksheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // ===== Header =====
            worksheet.Cells[4, 1].Value = "Task Name";
            worksheet.Cells[4, 2].Value = "Task Priority";
            worksheet.Cells[4, 3].Value = "Project List";
            worksheet.Cells[4, 4].Value = "Start Date";
            worksheet.Cells[4, 5].Value = "End Date";

            using (var header = worksheet.Cells[4, 1, 4, 5])
            {
                header.Style.Font.Bold = true;
                header.Style.Font.Color.SetColor(Color.White);
                header.Style.Fill.PatternType = ExcelFillStyle.Solid;
                header.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(52, 152, 219));
                header.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                header.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            }

            int row = 5;

            foreach (var task in allTasks)
            {
                worksheet.Cells[row, 1].Value = task.TaskName;
                worksheet.Cells[row, 2].Value = task.TaskPriority.ToString();
                worksheet.Cells[row, 3].Value = task.ProjectListName;
                worksheet.Cells[row, 4].Value = task.StartDate.ToString("yyyy-MM-dd");
                worksheet.Cells[row, 5].Value = task.EndDate.ToString("yyyy-MM-dd");

                // ===== Card Style =====
                using (var card = worksheet.Cells[row, 1, row, 5])
                {
                    card.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    card.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(245, 247, 250));
                    card.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    card.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                // ===== Status Color =====
                var statusCell = worksheet.Cells[row, 2];

                if (task.TaskPriority == TaskPriority.high)
                {
                    statusCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    statusCell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }
                else if (task.TaskPriority == TaskPriority.medium)
                {
                    statusCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    statusCell.Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                }
                else if (task.TaskPriority == TaskPriority.low)
                {
                    statusCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    statusCell.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                }

                row++;
            }

            // ===== UX Improvements =====
            worksheet.Cells.AutoFitColumns();
            worksheet.View.FreezePanes(5, 1);
            worksheet.Cells[4, 1, row - 1, 5].AutoFilter = true;

            var fileBytes = package.GetAsByteArray();
            var fileName = $"Tasks_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var result = new ExportProjectListsDTO(fileBytes, fileName, contentType);

            return RequestResult<ExportProjectListsDTO>.Success(result);
        }
    }
}
