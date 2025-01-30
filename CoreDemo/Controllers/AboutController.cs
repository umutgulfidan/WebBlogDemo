using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var values = _aboutManager.GetList();
            return View(values);
        }
        public PartialViewResult SocialMediaAbout()
        {

            return new PartialViewResult();
        }
    }
}
