using System.Security.Claims;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            var writerValues = _writerManager.GetWriterByMail(user.Email);
            return View(writerValues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer,IFormFile file)
        {
            bool isImageChanged = false;
            if(file != null)
            {
                writer.WriterImage = FileHelper.AddWriterImage(file);
                isImageChanged = true;
            }
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                _writerManager.TUpdate(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {

                if (isImageChanged)
                {
                    FileHelper.DeleteWriterImage(writer.WriterImage);
                }

                ModelState.Clear();
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(writer);
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(WriterWithImage writerWithImage)
        {
            Writer w = new Writer();
            if(writerWithImage.WriterImage != null)
            {
                var newImageName = FileHelper.AddWriterImage(writerWithImage.WriterImage);
                w.WriterImage = newImageName;
            }
            w.WriterName = writerWithImage.WriterName;
            w.WriterStatus = writerWithImage.WriterStatus;
            w.WriterPassword = writerWithImage.WriterPassword;
            w.WriterMail = writerWithImage.WriterMail;
            w.WriterAbout = writerWithImage.WriterAbout;
            _writerManager.TAdd(w);
            return RedirectToAction("Index","Dashboard");
        }
    }
}
