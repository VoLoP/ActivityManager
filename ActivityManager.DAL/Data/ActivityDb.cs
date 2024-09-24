using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManager.DAL.Data
{
    public class ActivityDb : DbContext
    {
        public ActivityDb(DbContextOptions<ActivityDb> options) : base(options) { }

        public DbSet<Activity> Activities { get; set; }
    }
}
