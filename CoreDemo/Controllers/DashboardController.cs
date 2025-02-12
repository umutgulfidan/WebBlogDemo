using System.Security.Claims;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            Context c = new Context();
            //var id = Convert.ToInt32(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _userManager.GetUserAsync(User);
            var userMail = user.Email;
            var writerId = c.Writers.Where(x=> x.WriterMail == userMail).Select(y=>y.WriterID).FirstOrDefault();

            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x=> x.WriterID==writerId).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
