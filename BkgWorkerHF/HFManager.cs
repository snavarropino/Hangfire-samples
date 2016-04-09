using Hangfire;
using Microsoft.WindowsAzure.ServiceRuntime;
using Model.ExecutableTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkgWorkerHF
{
    public class HFManager
    {
        private BackgroundJobServer _bkgServer;

        const string CTE_TaskId="HF_Task_ID";


        public void Configure ()
        {
            GlobalConfiguration.Configuration
                // Use connection string name defined in `web.config` or `app.config`
                .UseSqlServerStorage("BkgConn");

        }

        public void SetupRecurringTask()
        {
            RecurringJob.AddOrUpdate(CTE_TaskId, () => TaskType1.Execute("Worker role executed a task"), Cron.Minutely);

        }

        public void InitBkgServer()
        {
            _bkgServer = new BackgroundJobServer();

        }

        public void StopBkgServer()
        {
            _bkgServer.Dispose();

        }

    }
}
