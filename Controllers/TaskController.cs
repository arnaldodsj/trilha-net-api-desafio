using Microsoft.AspNetCore.Mvc;
using TaskAPI.Context;
using TaskAPI.Entities;
using Task = TaskAPI.Entities.Task;

namespace TaskAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskContext _context;

        public TaskController(TaskContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { task.Id }, task);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var tasks = _context.Tasks;

            return Ok(tasks);
        }

        [HttpGet("GetByTitle")]
        public IActionResult GetByTitle(string title)
        {
            var task = _context.Tasks.Where(x => x.Title.Contains(title));

            if (!task.Any())
            {
                return NotFound();
            }

            return Ok(task);
        }
        [HttpGet("GetByDate")]
        public IActionResult GetByDate(DateTime date)
        {
            var task = _context.Tasks.Where(x => x.CreatedDate.Date == date.Date);

            if (!task.Any())
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpGet("GetByStatus")]
        public IActionResult GetByStatus(ETaskStatus status)
        {
            var task = _context.Tasks.Where(x => x.Status == status);

            if (!task.Any())
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Task task)
        {
            var updatedTask = _context.Tasks.Find(id);

            if (updatedTask == null)
            {
                return NotFound();
            }


            updatedTask.Title = task.Title;
            updatedTask.Description = task.Description;
            updatedTask.CreatedDate = task.CreatedDate;
            updatedTask.Status = task.Status;

            _context.SaveChanges();

            return Ok(updatedTask);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
