using Hangfire;
using Model;
using Model.ExecutableTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebFront.Controllers
{
    public class TasksController : Controller
    {
        private TasksDbContext db = new TasksDbContext();

        // GET: Tasks
        public ActionResult Index()
        {
            return View(db.Tasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEntity executedTask = db.Tasks.Find(id);
            if (executedTask == null)
            {
                return HttpNotFound();
            }
            return View(executedTask);
        }

        // GET: Tasks/DeleteAll
        public ActionResult DeleteAll()
        {
            var dao = new TasksDAO();
            dao.DeleteAll();
            return RedirectToAction("Index");
        }

        // GET: Tasks/DeleteHF
        public ActionResult DeleteHF()
        {
            var dao = new TasksDAO();
            dao.DeleteAllByType(TaskEntity.CT_TASK_TYPE_HANGFIRE);
            return RedirectToAction("Index");
        }


        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEntity executedTask = db.Tasks.Find(id);
            if (executedTask == null)
            {
                return HttpNotFound();
            }
            return View(executedTask);
        }

        
        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEntity executedTask = db.Tasks.Find(id);
            if (executedTask == null)
            {
                return HttpNotFound();
            }
            return View(executedTask);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskEntity executedTask = db.Tasks.Find(id);
            db.Tasks.Remove(executedTask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NewTask()
        {
            BackgroundJob.Enqueue(() => TaskType1.Execute("Worker role executed a task queued by FRONT!"));

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}