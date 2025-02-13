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
        private readonly UserManager<AppUser> _userManager;
        UserManager userManager = new UserManager(new EfUserRepository());

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
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel()
            {
                NameSurname = values.NameSurname,
                Mail = values.Email,
                UserName = values.UserName,
                About = values.About
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model,IFormFile file)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.Mail;
            values.UserName = model.UserName;
            values.About = model.About;
            values.NameSurname = model.NameSurname;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values,model.Password);

            bool isImageChanged = false;
            if(file != null)
            {
                values.ImageUrl = FileHelper.AddWriterImage(file);
                isImageChanged = true;
            }

            UserValidator validator = new UserValidator();
            ValidationResult results = validator.Validate(values);

            if (results.IsValid)
            {
                var result = await _userManager.UpdateAsync(values);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {

                if (isImageChanged)
                {
                    FileHelper.DeleteWriterImage(values.ImageUrl);
                }

                ModelState.Clear();
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(model);
        }
     
    }
}
