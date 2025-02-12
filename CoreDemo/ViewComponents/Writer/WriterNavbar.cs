using System.Security.Claims;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNavbar : ViewComponent
    {
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        UserManager<AppUser> _userManager;

        public WriterNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userMail = user.Email;
            var writer = _writerManager.GetWriterByMail(userMail);
            return View(writer);
        }
    }
}
