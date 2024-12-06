using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectService.Models
{
    public class Project
    {
        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("project_name")]
        public string ProjectName { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

      /*  [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }*/
    }
}