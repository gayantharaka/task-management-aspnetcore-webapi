﻿using System;

namespace ProjectService.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}