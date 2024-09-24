using ActivityManager.DAL.Repos.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ActivityManager.DAL.Data;


namespace ActivityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
       private readonly IActivityRepo _activityRepository;

        public ActivityController(IActivityRepo activityRepository)
        {
            _activityRepository = activityRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var activities = _activityRepository.GetAll();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var activity = _activityRepository.GetById(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpPost]
        public IActionResult Create([FromBody] DAL.Data.Activity activity)
        {
            _activityRepository.Add(activity);
            return CreatedAtAction(nameof(GetById), new { id = activity.Id }, activity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DAL.Data.Activity activity)
        {
            if (id != activity.Id)
            {
                return BadRequest();
            }
            _activityRepository.Update(activity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _activityRepository.Delete(id);
            return NoContent();
        }
    }
}
