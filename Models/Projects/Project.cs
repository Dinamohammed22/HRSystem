using EasyTask.Common.Interfaces;
using EasyTask.Models.Candidates;
using EasyTask.Models.Departments;
using EasyTask.Models.Enums;
using EasyTask.Models.Managements;
using EasyTask.Models.ProjectCandidates;
using EasyTask.Models.ProjectExternalMembers;
using EasyTask.Models.ProjectLists;
using EasyTask.Models.ProjectScrumMasters;
using EasyTask.Models.ProjectStakeholders;
using EasyTask.Models.ProjectTypes;
using EasyTask.Models.WorkPackages;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Projects
{
    [Table("Project", Schema = "Projects")]
    public class Project : BaseModel, ISelectableListItem
    {
        public string Name { get; set; } 
        public string ProjectCode { get; set; }

        public bool Strategic { get; set; }
        public bool Financial { get; set; }

        public DateTime? KickOffDate { get; set; }
        public bool IsKickOffmeeting { get; set; }

        public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.Active;
        public string? PauseReason { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string? ProjectPurpose { get; set; }
        public string? Scope { get; set; }
        public string? Deliverables { get; set; }
        public string? HighLevelRequirements { get; set; }


        // ---------------- Relationships ----------------

        [ForeignKey("ProjectType")]
        public string ProjectTypeId { get; set; }
        public ProjectType? ProjectType { get; set; }

        [ForeignKey("ProjectManager")]
        public string ProjectManagerId { get; set; }
        public Candidate? ProjectManager { get; set; }

        [ForeignKey("ProjectOwner")]
        public string ProjectOwnerId { get; set; }
        public Candidate? ProjectOwner { get; set; }

        [ForeignKey("Management")]
        public string ManagementId { get; set; }
        public Management? Management { get; set; }

        [ForeignKey("Department")]
        public string DepartmentId { get; set; }
        public Department? Department { get; set; }

        public ICollection<ProjectScrumMaster>? ScrumMasters { get; set; }
        public ICollection<WorkPackage>? WorkPackages { get; set; }
        public ICollection<ProjectList>? ProjectLists { get; set; }
        public ICollection<ProjectStakeholder> ProjectStakeholders { get; set; }
        public ICollection<ProjectCandidate>? ProjectCandidates { get; set; }
        public ICollection<ProjectExternalMember>? ProjectExternalMembers { get; set; }

        //TODO :
        //list of milestones
    }
}
