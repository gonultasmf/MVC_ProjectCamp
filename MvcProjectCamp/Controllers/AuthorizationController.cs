using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adm = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var values = adm.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valuesYetki = (from x in adm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.AdminRole,
                                                    Value = x.AdminID.ToString()
                                                }).ToList();
            ViewBag.vly = valuesYetki;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adm.AdminAddBL(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valuesYetki = (from x in adm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.AdminRole,
                                                    Value = x.AdminID.ToString()
                                                }).ToList();
            ViewBag.vly = valuesYetki;
            var value = adm.GetByIDBL(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            adm.AdminUpdateBL(admin);
            return RedirectToAction("Index");
        }
    }
}