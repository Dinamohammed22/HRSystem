using EasyTask.Common.Interfaces;
using EasyTask.Models.Projects;
using EasyTask.Models.ProjectTasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.ProjectLists
{
    public class ProjectList:BaseModel, ISelectableListItem
    {
        public string Name {  get; set; }
        public int  Sequence {  get; set; }

        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public Project? Project { get; set; }

        public ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();
    }
}
