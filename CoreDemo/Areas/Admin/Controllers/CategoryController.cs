using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Extensions;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;
using FluentValidation.Results;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = _categoryManager.GetList().ToPagedList(page,10);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.CategoryStatus = true;

            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);


            if (results.IsValid)
            {
                _categoryManager.TAdd(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {

                ModelState.Clear();
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View(category);
        }
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryManager.GetById(id);
            _categoryManager.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult DeactivateCategory(int id)
        {
            var value = _categoryManager.GetById(id);
            value.CategoryStatus = false;
            _categoryManager.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult ActivateCategory(int id)
        {
            var value = _categoryManager.GetById(id);
            value.CategoryStatus = true;
            _categoryManager.TUpdate(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var value = _categoryManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);


            if (results.IsValid)
            {
                _categoryManager.TUpdate(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {

                ModelState.Clear();
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View(category);
        }
    }
}
