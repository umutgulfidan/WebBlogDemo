using System.Security.Claims;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            Context c = new Context();
            var id = Convert.ToInt32(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x=> x.WriterID==id).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
