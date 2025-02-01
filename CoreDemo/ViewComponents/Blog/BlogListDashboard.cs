using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var value = _blogManager.GetBlogListWithCategory().OrderByDescending(x=> x.BlogCreateDate).Take(10);
            return View(value);
        }

    }
}
