using EasyTask.Models.Candidates;
using EasyTask.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.ProjectScrumMasters
{
    [Table("ProjectScrumMaster",Schema = "ProjectScrumMasters")]
    public class ProjectScrumMaster : BaseModel
    {
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
