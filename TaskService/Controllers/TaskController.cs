using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using TaskService.Data;
using TaskService.Dtos;
using TaskService.Models;

namespace TaskService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly TaskDbContext _dbContext;
        private readonly HttpClient _httpClient;


        public TaskController(TaskDbContext dbContext, HttpClient httpClient)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _dbContext.Tasks.ToListAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task == null) NotFound("Task not found");

            var project = await _httpClient.GetFromJsonAsync<Object>($"http://localhost:5002/api/project/{task.ProjectId}");

            return Ok(new { task, project });
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto taskDto)
        {
            var task = new TaskService.Models.Task
            {
                TaskTitle = taskDto.TaskTitle,
                Description = taskDto.Description,
                ProjectId = taskDto.ProjectId,
                AssignedUserId = taskDto.AssignedUserId,
                DueDate = taskDto.DueDate,
                Priority = taskDto.Priority,
                Status = taskDto.Status
            };

            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTaskById), new { id = task.TaskId }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDto taskDto)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task == null) return NotFound("Task not found");

            task.TaskTitle = taskDto.TaskTitle;
            task.Description = taskDto.Description;
            task.ProjectId = taskDto.ProjectId;
            task.AssignedUserId = taskDto.AssignedUserId;
            task.DueDate = taskDto.DueDate;
            task.Priority = taskDto.Priority;
            task.Status = taskDto.Status;

            await _dbContext.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task == null) return NotFound("Task not found");

            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }

}

