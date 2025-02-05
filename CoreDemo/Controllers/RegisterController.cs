using System.Transactions;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer p,IFormFile file)
        {

                if (file != null)
                {
                    p.WriterImage = FileHelper.AddWriterImage(file);
                }
                p.WriterStatus = true;

                WriterValidator writerValidator = new WriterValidator();
                ValidationResult results = writerValidator.Validate(p);
                if (results.IsValid)
                {

                    _writerManager.TAdd(p);
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                FileHelper.DeleteWriterImage(p.WriterImage);
                    ModelState.Clear();
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                return View(p);
        }
    }
}
