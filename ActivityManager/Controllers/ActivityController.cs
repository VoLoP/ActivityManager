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
            try
            {
                var activities = await _activityRepository.GetAllAsync();
                return Ok(activities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all activities.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var activity = await _activityRepository.GetByIdAsync(id);
                if (activity == null)
                {
                    _logger.LogWarning($"Activity with ID {id} not found.");
                    return NotFound();
                }
                return Ok(activity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching activity with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Activity activity)
        {
            if (activity == null)
            {
                _logger.LogWarning("Create activity request with null activity.");
                return BadRequest();
            }

            try
            {
                await _activityRepository.AddAsync(activity);
                return CreatedAtAction(nameof(GetById), new { id = activity.Id }, activity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating activity.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Activity activity)
        {
            if (activity == null)
            {
                _logger.LogWarning("Update activity request with null activity.");
                return BadRequest();
            }

            try
            {
                await _activityRepository.UpdateAsync(activity);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating activity.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _activityRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting activity with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}