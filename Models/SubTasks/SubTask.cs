using EasyTask.Common.Interfaces;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.SubTasks
{
    [Table("SubTask", Schema = "SubTasks")]
    public class SubTask : BaseModel, ISelectableListItem
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("ProjectTask")]
        public string ProjectTaskId { get; set; }
        public ProjectTask? ProjectTask { get; set; }

        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate? Candidate { get; set; }

        public SubTaskStatus SubTaskStatus { get; set; }
    }
}
