using Microsoft.AspNetCore.Mvc;
using Tasks.Services;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        protected readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/<WorkingTasksController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_taskService.GetAll());
        }

        // GET api/<WorkingTasksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_taskService.GetById(id));
        }

        // POST api/<WorkingTasksController>
        [HttpPost]
        public void Post([FromBody] Models.Task task)
        {
            _taskService.Add(task);
        }

        // PUT api/<WorkingTasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Models.Task task)
        {
            _taskService.Update(task, id);
        }

        // DELETE api/<WorkingTasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _taskService.Remove(id);
        }
    }
}
