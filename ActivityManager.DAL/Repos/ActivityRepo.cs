using ActivityManager.DAL.Data;
using ActivityManager.DAL.Repos.IRepos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivityManager.DAL.Repos
{
    public class ActivityRepo : IActivityRepo
    {
        private readonly ActivityDb _context;
        private readonly ILogger<ActivityRepo> _logger;

        public ActivityRepo(ActivityDb context, ILogger<ActivityRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Data.Activity>> GetAllAsync()
        {
            try
            {
                return await _context.Activities.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all activities.");
                throw;
            }
        }

        public async Task<Data.Activity> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Activities.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching activity with ID {id}.");
                throw;
            }
        }

        public async Task AddAsync(Data.Activity activity)
        {
            try
            {
                await _context.Activities.AddAsync(activity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding activity.");
                throw;
            }
        }

        public async Task UpdateAsync(Data.Activity activity)
        {
            try
            {
                _context.Entry(activity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating activity.");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var activity = await _context.Activities.FindAsync(id);
                if (activity != null)
                {
                    _context.Activities.Remove(activity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting activity with ID {id}.");
                throw;
            }
        }
    }
}