using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public int PageSize = 4;

        public IActionResult Index(int productPage = 1)
        {
            if (productPage<1)
            {
                productPage = 1;
            }
            return View(new ProductsListViewModel
            {
                Products = db.Products.OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PageInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = db.Products.Count()
                }
            });
        }
    }
}
