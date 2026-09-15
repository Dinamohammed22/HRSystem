using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.ProjectLists.Queries;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;
using EasyTask.Models.SubTasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Features.SubTasks.CreateSubTask.Commands
{
    public record CreateSubTaskCommand
        ( string Name , 
        DateTime StartDate ,
        DateTime EndDate,
        string ProjectTaskId ,
        string CandidateId,
        SubTaskStatus SubTaskStatus) : IRequestBase<string>;
    public class CreateSubTaskCommandHandler : RequestHandlerBase<SubTask, CreateSubTaskCommand, string>
    {
        public CreateSubTaskCommandHandler(RequestHandlerBaseParameters<SubTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateSubTaskCommand request, CancellationToken cancellationToken)
        {
            SubTask SubTask = new SubTask
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                ProjectTaskId = request.ProjectTaskId,
                CandidateId = request.CandidateId,
                SubTaskStatus = request.SubTaskStatus
            };

            _repository.Add(SubTask);
            _repository.SaveChanges();
            return RequestResult<string>.Success(SubTask.ID);
        }
    }
}
