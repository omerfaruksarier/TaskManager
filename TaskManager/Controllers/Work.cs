using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Controllers
{
    public class Work : Controller
    {
        WorkManager wm = new WorkManager(new EfWorkRepository());

  
        public IActionResult Index()
        {
            ViewBag.Name = User.Identity.Name;
            var values = wm.GetWorkListWithUser(userId());

            return View(values);
        }

        public IActionResult Edit(int id)
        {
            var values = wm.GetWorkById(id);
            return View(values);
        }
        [HttpPost]

        public IActionResult Edit(int id,EntityLayer.Concrete.Work work)
        {
            work.WorkId = id;
            work.UserId = userId();
            work.Status = true;
            wm.TUpdate(work);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {

            wm.TDelete(wm.GetById(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddWork()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWork(EntityLayer.Concrete.Work work)
        {
            WorkValidator wv = new WorkValidator();
            work.UserId = userId();
            ValidationResult results = wv.Validate(work);
            if (results.IsValid) { 
            work.Status = true;
            wm.TAdd(work);
            return RedirectToAction("Index");;
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
        public int userId()
        {
            Context c = new Context();
            var userId = c.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.UserId).FirstOrDefault();
            return userId;
        }

    }
}
