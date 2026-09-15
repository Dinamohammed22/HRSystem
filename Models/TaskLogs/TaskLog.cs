using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;
using EasyTask.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.TaskLogs
{
    [Table("TaskLog", Schema = "TaskLogs")]
    public class TaskLog:BaseModel
    {
        public string Description {  get; set; }
        [ForeignKey("ProjectTask")]
        public string ProjectTaskId { get; set; }
        public ProjectTask? ProjectTask { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
