using System;
using Microsoft.EntityFrameworkCore;
using ProjectService.Models;

namespace ProjectService.Data
{
    public class ProjectDbContext: DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
    }
}
