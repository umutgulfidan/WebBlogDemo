using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsLetterManager _newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository());
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        // AJAX POST isteğini almak için
        [HttpPost]
        public JsonResult SubscribeMail(string Mail)
        {
            if (string.IsNullOrEmpty(Mail))
            {
                return Json(new { success = false, message = "E-posta adresi geçersiz." });
            }

            var newsLetter = new NewsLetter()
            {
                Mail = Mail,
                MailStatus = true
            };

            NewsLetterValidator validator = new NewsLetterValidator();
            ValidationResult result = validator.Validate(newsLetter);
            if (!result.IsValid)
            {
                string errorMessage = result.Errors.ToString();

                return Json(new { success = false, message = errorMessage });
            }

            if (_newsLetterManager.IsEmailExists(Mail))
            {
                return Json(new { success= false, message="Bu email zaten bültene kaydedilmiş."});
            }

            
            _newsLetterManager.TAdd(newsLetter);
            return Json(new { success = true, message = "Başarıyla abone oldunuz!" });
        }
    }
}
