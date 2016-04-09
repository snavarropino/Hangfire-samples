using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TasksDAO
    {
        public IEnumerable <TaskEntity> GetAll ()
        {
            using (var ctx = new TasksDbContext())
            {
                return ctx.Tasks.AsEnumerable();
            }
        }

        public void Add(string tasktype, string details, string worker)
        {
            using (var ctx = new TasksDbContext())
            {
                var t = new TaskEntity()
                {
                    ExecutionDT = DateTime.UtcNow,
                    TaskType = tasktype,
                    Worker = worker,
                    Details = details
                };

                ctx.Tasks.Add(t);

                ctx.SaveChanges();
            }
        }

        public void DeleteAll()
        {
            using (var ctx = new TasksDbContext())
            {
                ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE [TaskEntities]");
            }
        }

        public void DeleteAllByType(string type)
        {
            using (var ctx = new TasksDbContext())
            {
                ctx.Tasks.RemoveRange(ctx.Tasks);
                ctx.SaveChanges();
            }
        }
    }
}
