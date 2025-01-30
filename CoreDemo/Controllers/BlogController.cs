using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = _blogManager.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            if (id == 0)
            {
                // ID verilmediği durumda bir hata mesajı veya başka bir sayfaya yönlendirme yapılabilir
                return RedirectToAction("Index", "Blog");  // Blog ana sayfasına yönlendirme örneği
            }
            var values = _blogManager.GetBlogByID(id);

            ViewBag.WriterID = values.First().WriterID;

            return View(values);
        }
    }
}
