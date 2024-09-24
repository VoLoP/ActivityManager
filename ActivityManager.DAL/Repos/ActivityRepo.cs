using ActivityManager.DAL.Data;
using ActivityManager.DAL.Repos.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManager.DAL.Repos
{
    public class ActivityRepo : IActivityRepo
    {
        private readonly List<Activity> _activities = new List<Activity>();

        public IEnumerable<Activity> GetAll()
        {
            return _activities;
        }

        public Activity GetById(int id)
        {
            return _activities.SingleOrDefault(a => a.Id == id);
        }

        public void Add(Activity activity)
        {
            _activities.Add(activity);
        }

        public void Update(Activity activity)
        {
            var existingActivity = GetById(activity.Id);
            if (existingActivity != null)
            {
                existingActivity.Name = activity.Name;
                existingActivity.Date = activity.Date;
                existingActivity.Description = activity.Description;
            }
        }

        public void Delete(int id)
        {
            var activity = GetById(id);
            if (activity != null)
            {
                _activities.Remove(activity);
            }
        }
    }
}
