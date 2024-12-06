using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectService.Data;
using ProjectService.Dtos;
using ProjectService.Models;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectDbContext _dbcontext;

        public ProjectController(ProjectDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _dbcontext.Projects.ToListAsync();
            if(projects==null) return NotFound();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectcById(int id)
        {
            var project = await _dbcontext.Projects.FindAsync(id);
            if (project == null) return NotFound("Project not found");
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectDto projectDto)
        {
            var project = new Project
            {
                ProjectName = projectDto.ProjectName,
                Description = projectDto.Description,
                UserId = projectDto.UserId,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate
            };
            await _dbcontext.Projects.AddAsync(project);
            _dbcontext.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateProject), new { id = project.ProjectId }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id,[FromBody] ProjectDto projectDto)
        {
            var project = await _dbcontext.Projects.FindAsync(id);
            if (project == null) return NotFound("Project not found");

            project.ProjectName = projectDto.ProjectName;
            project.Description = projectDto.Description;
            project.StartDate = projectDto.StartDate;
            project.EndDate = projectDto.EndDate;
            project.UserId = projectDto.UserId;

            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _dbcontext.Projects.FindAsync(id);
            if (project == null) return NotFound("Project not found");

            _dbcontext.Projects.Remove(project);
            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }
       
    }
}