using ActivityManager.DAL.Data;
using ActivityManager.DAL.Repos.IRepos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityManager.DAL.Repos
{
    public class ActivityRepo : IActivityRepo
    {
        private readonly ActivityDb _context;

        public ActivityRepo(ActivityDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Data.Activity>> GetAllAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Data.Activity> GetByIdAsync(int id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public async Task AddAsync(Data.Activity activity)
        {
            await _context.Activities.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Data.Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }
    }
}