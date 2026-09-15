using EasyTask.Common.Interfaces;
using EasyTask.Models.Candidates;
using EasyTask.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.CloseProjects
{
    [Table("CloseProject", Schema = "CloseProjects")]
    public class CloseProject : BaseModel
    {
        public string ProjectCloseReason { get; set; }
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        public int CloseDuration { get; set; }
        public bool HasCloseImpact { get; set; }
        public string InternalCloseReason { get; set; }
        public string ExternalCloseReason { get; set; }
    }
}
