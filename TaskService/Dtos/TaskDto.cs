using System;
using System.ComponentModel.DataAnnotations;

namespace TaskService.Dtos
{
    public class TaskDto
    {
   //     public int TaskId { get; set; }

        [Required(ErrorMessage = "Task title is required")]
        public string TaskTitle { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        public int ProjectId { get; set; }
        public int? AssignedUserId { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        public DateOnly? DueDate { get; set; }

        public string? Priority { get; set; }
        public string? Status { get; set; }
     /*   public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }*/
    }
}