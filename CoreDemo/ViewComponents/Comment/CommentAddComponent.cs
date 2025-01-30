using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentAddComponent : ViewComponent
    {
        private readonly CommentManager _commentManager = new CommentManager(new EfCommentRepository());

        [HttpGet]
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.BlogID = id;           
            return View();
        }

    }
}
