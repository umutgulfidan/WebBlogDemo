using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult RefreshCommentList(int id)
        {
            string referer = Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(referer) || !referer.Contains("/Blog/BlogReadAll/")) 
            {
                return Unauthorized("Bu sayfaya doğrudan erişemezsiniz.");
            }

            return ViewComponent("CommentListByBlog", new { id = id });
        }

        [HttpPost]
        public JsonResult CommentAdd([FromBody] Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            if (comment != null)
            {
                // Yorum veritabanına ekleme
                _commentManager.TAdd(comment);

                // JSON yanıtı döndürme
                return new JsonResult(new { success = true, message = "Yorum başarıyla eklendi!" });
            }

            return new JsonResult(new { success = false, message = "Geçersiz veri!" });
        }
    }
}
