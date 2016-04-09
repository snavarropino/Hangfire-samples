using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TasksDbContext: DbContext
    {
        public TasksDbContext() : base("BkgConn") { }
        
        public DbSet<TaskEntity> Tasks { get; set; }
        
    }
}
