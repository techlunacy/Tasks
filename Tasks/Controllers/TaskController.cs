using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/

        public ActionResult Index()
        {
            try
            {
                IPrincipal identity = this.User;
                List<TaskModel> taskList = TaskModel.GetByUser(identity.Identity.Name);

                return View(taskList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //
        // GET: /Task/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Task/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Task/Create

        [HttpPost]
        public ActionResult Create(TaskModel task)
        {
            try
            {
                //TaskModel task = new TaskModel()
                //                         {
                //                             Name = collection["name"].ToString(),
                //                             DueDate = DateTime.Parse(collection["DueDate"].ToString()),
                //                             Priority = int.Parse(collection["priority.priority"].ToString()),
                //                             User = this.User.Identity.Name
                //                         };
                task.User = this.User.Identity.Name;
                if (ModelState.IsValid)
                {
                    task.Save();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Task/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Task/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Task/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Task/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
