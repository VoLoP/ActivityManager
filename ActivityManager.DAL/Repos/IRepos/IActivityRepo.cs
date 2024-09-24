using ActivityManager.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManager.DAL.Repos.IRepos
{
    public interface IActivityRepo
    {
        IEnumerable<Activity> GetAll();
        Activity GetById(int id);
        void Add(Activity activity);
        void Update(Activity activity);
        void Delete(int id);
    }
}
