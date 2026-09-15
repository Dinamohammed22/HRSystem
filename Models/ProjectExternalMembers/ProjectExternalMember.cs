using EasyTask.Models.Candidates;
using EasyTask.Models.ExternalMembers;
using EasyTask.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.ProjectExternalMembers
{
    [Table("ProjectExternalMember", Schema = "ProjectExternalMembers")]
    public class ProjectExternalMember:BaseModel
    {
        [ForeignKey("ExternalMember")]
        public string ExternalMemberId { get; set; }
        public ExternalMember ExternalMember { get; set; }
        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
