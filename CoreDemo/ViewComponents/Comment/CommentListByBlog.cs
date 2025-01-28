using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager _commentManager = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = _commentManager.GetList(id);
            return View(values);
        }
    }
}
