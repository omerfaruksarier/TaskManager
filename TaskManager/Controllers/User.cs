using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Controllers
{
    public class User : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            var values = um.GetList();
            return View(values);
        }
    }
}
