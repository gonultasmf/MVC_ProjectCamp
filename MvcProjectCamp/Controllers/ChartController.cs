using MvcProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categories = new List<CategoryClass>();
            categories.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 9
            });
            categories.Add(new CategoryClass()
            {
                CategoryName = "Seyehat",
                CategoryCount = 4
            });
            categories.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 6
            });
            categories.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 7
            });
            return categories;
        }
    }
}