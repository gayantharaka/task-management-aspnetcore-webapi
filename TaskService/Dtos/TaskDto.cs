using System;

namespace TaskService.Dtos
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string? Description { get; set; }
        public int ProjectId { get; set; }
        public string? AssignedUserId { get; set; }
        public Date? DueDate { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }