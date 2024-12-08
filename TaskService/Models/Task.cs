using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskService.Models
{
    public class Task
    {
        [Column("task_id")]
        public int TaskId { get; set; }

        [Column("task_title")]
        public string TaskTitle { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("assigned_user_id")]
        public int? AssignedUserId { get; set; }

        [Column("due_date")]
        public DateOnly? DueDate { get; set; }

        [Column("priority")]
        public string? Priority { get; set; } = "High";

        [Column("status")]
        public string? Status { get; set; } = "Pending";
        //public DateTime? CreatedAt { get; set; }
        //public DateTime? UpdatedAt { get; set; }
    }

}