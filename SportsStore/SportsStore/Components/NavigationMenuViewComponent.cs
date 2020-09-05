using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent: ViewComponent
    {
        private ApplicationContext db;
        
        public NavigationMenuViewComponent(ApplicationContext application)
        {
            db = application;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(db.Products.Select(x=>x.Category).Distinct().OrderBy(x=>x));
        }

    }
}
