using ActivityManager.DAL.Repos.IRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ActivityManager.DAL.Data;

namespace ActivityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepo _activityRepository;
        private readonly ILogger<ActivityController> _logger;

        public ActivityController(IActivityRepo activityRepository, ILogger<ActivityController> logger)
        {
            _activityRepository = activityRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activities = await _activityRepository.GetAllAsync();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var activity = await _activityRepository.GetByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Activity activity)
        {
            if (activity == null)
            {
                return BadRequest();
            }

            await _activityRepository.AddAsync(activity);
            return CreatedAtAction(nameof(GetById), new { id = activity.Id }, activity);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Activity activity)
        {
            if (activity == null)
            {
                return BadRequest();
            }

            await _activityRepository.UpdateAsync(activity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _activityRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}