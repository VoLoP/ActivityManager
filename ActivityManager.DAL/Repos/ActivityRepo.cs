using ActivityManager.DAL.Data;
using ActivityManager.DAL.Repos.IRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

        public IEnumerable<Data.Activity> GetAll()
        {
            return _context.Activities.ToList();
        }

        public Data.Activity GetById(int id)
        {
            return _context.Activities.Find(id);
        }

        public void Add(Data.Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
        }

        public void Update(Data.Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var activity = _context.Activities.Find(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
        }
    }
}
