using Microsoft.WindowsAzure.ServiceRuntime;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExecutableTask
{
    public class TaskType1
    {
        public static void Execute (string msg)
        {
            var executorId = RoleEnvironment.CurrentRoleInstance.Id;

            var dao = new TasksDAO();
            dao.Add(TaskEntity.CT_TASK_TYPE_HANGFIRE, msg, executorId);
        }

    }
}
