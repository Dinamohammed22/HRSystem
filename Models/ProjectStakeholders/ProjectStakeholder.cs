using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using EasyTask.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.ProjectStakeholders
{
    [Table("ProjectStakeholder", Schema = "ProjectStakeholders")]
    public class ProjectStakeholder:BaseModel
    {
        public string StakeholderId {  get; set; }
        public StakeholderType StakeholderType { get; set; }
        public StakeholderRole Role { get; set; }
        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public Project? Project { get; set; }

    }
}
