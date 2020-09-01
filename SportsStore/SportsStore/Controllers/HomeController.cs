using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            User u = new User() { Name = "Denis", Age = 22};
            //db.Users.Add(u);
            //db.SaveChanges();
            var users = db.Users.ToList();
            return View(db.Users.ToList());
        }
    }
}
