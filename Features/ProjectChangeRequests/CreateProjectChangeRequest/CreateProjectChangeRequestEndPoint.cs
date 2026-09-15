using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectChangeRequests.CreateProjectChangeRequest.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectChangeRequests.CreateProjectChangeRequest
{
    public class CreateProjectChangeRequestEndPoint : EndpointBase<CreateProjectChangeRequestRequestViewModel, CreateProjectChangeRequestResponseViewModel>
    {
        public CreateProjectChangeRequestEndPoint(EndpointBaseParameters<CreateProjectChangeRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateProjectChangeRequest })]
        public async Task<EndPointResponse<CreateProjectChangeRequestResponseViewModel>> CreateProjectChangeRequest(CreateProjectChangeRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateProjectChangeRequestCommand>());
            if (result.IsSuccess)
                return EndPointResponse<CreateProjectChangeRequestResponseViewModel>.Success(new CreateProjectChangeRequestResponseViewModel(), "Change Request Added Successfully");
            else
                return EndPointResponse<CreateProjectChangeRequestResponseViewModel>.Failure(result.ErrorCode, result.Message);
        }
    }
}
