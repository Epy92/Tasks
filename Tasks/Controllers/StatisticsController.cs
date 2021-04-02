using Microsoft.AspNetCore.Mvc;
using Tasks.Services;
namespace Tasks.Controllers
{
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        protected readonly ITaskService _taskService;

        public StatisticsController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Route("api/statistics")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_taskService.GetStatistics());
        }

        [Route("api/Statistics/GetOverdue")]
        [HttpGet]
        public IActionResult GetOverdue()
        {
            return Ok(_taskService.GetOverdueTasks());
        }

        [Route("api/Statistics/GetPending")]
        [HttpGet]
        public IActionResult GetPending()
        {
            return Ok(_taskService.GetPendingTasks());
        }

        [Route("api/Statistics/GetInProgress")]
        [HttpGet]
        public IActionResult GetInProgress()
        {
            return Ok(_taskService.GetInProgressTasks());
        }

        [Route("api/working")]
        [HttpGet]
        public IActionResult GetWorking()
        {
            return Ok(_taskService.GetWorkingTasks());
        }
    }
}
