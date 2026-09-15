using EasyTask.Common.Interfaces;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using EasyTask.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.ProjectChangeRequests
{
    [Table("ProjectChangeRequest", Schema = "ProjectChangeRequests")]
    public class ProjectChangeRequest : BaseModel
    {
        public string ProjectChangeReason { get; set; }
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        public ProjectChangeType ProjectChangeType { get; set; }
        public ProjectChangeImpact ProjectChangeImpact { get; set; }
        public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;
    }
}
