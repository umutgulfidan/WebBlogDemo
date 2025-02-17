using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            var values = _commentManager.GetListWithBlog().OrderByDescending(x=>x.CommentDate);
            return View(values);
        }
        public IActionResult DeactivateComment(int id)
        {
            var value = _commentManager.GetById(id);
            value.CommentStatus = false;
            _commentManager.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult ActivateComment(int id)
        {
            var value = _commentManager.GetById(id);
            value.CommentStatus = true;
            _commentManager.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
