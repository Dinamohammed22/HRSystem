using EasyTask.Models.Candidates;
using EasyTask.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.ProjectCandidates
{
    [Table("ProjectCandidate", Schema = "ProjectCandidates")]
    public class ProjectCandidate:BaseModel
    {
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public Project Project{ get; set; }
    }
}
