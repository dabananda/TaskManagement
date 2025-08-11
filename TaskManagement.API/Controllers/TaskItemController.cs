using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.DTOs.TaskItem;
using TaskManagement.API.Services.Interfaces;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;

        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        // GET: api/taskitem
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskItemService.GetAllAsync();
            return Ok(tasks);
        }

        // GET: api/taskitem/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var task = await _taskItemService.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        // POST: api/taskitem
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskItemCreateDto dto)
        {
            if (dto == null) return BadRequest("Task item cannot be null");
            var createdTask = await _taskItemService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
        }

        // PUT: api/taskitem/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TaskItemUpdateDto dto)
        {
            if (dto == null) return BadRequest("Task item cannot be null");
            var updatedTask = await _taskItemService.UpdateAsync(id, dto);
            if (!updatedTask) return NotFound();
            return NoContent();
        }

        // DELETE: api/taskitem/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _taskItemService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
