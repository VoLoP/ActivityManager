using ActivityManager.DAL.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivityManager.DAL.Repos.IRepos
{
    public interface IActivityRepo
    {
        Task<IEnumerable<Activity>> GetAllAsync();
        Task<Activity> GetByIdAsync(int id);
        Task AddAsync(Activity activity);
        Task UpdateAsync(Activity activity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Activity>> SearchAsync(string searchTerm);
    }
}