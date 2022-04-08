using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles ="B")]
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidatior categoryValidator = new CategoryValidatior();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                cm.CategoryAddBL(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetByIDBL(id);
            cm.CategoryDeleteBL(categoryValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = cm.GetByIDBL(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            cm.CategoryUpdateBL(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Upload()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    // burada dilerseniz dosya tipine gore filtreleme yaparak sadece istediginiz dosya formatindaki dosyalari yukleyebilirsiniz
                    if (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" || file.ContentType == "image/png" || file.ContentType == "image/gif")
                    {
                        var fi = new FileInfo(file.FileName);
                        var fileName = Path.GetFileName(file.FileName);
                        fileName = Guid.NewGuid().ToString() + fi.Extension;
                        var path = Path.Combine(Server.MapPath("~/files/"), fileName);
                        file.SaveAs(path);
                    }
                }
            }

            return View();
        }
        [HttpPost]
        public ActionResult Upload(System.Web.HttpPostedFileBase uploadingFiles)
        {
            if (uploadingFiles != null && uploadingFiles.ContentLength > 0)
            {
                return View(uploadingFiles);
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult Deneme()
        {
            return View();
        }
    }
}