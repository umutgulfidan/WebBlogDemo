using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        UserManager<AppUser> _userManagerIdentity;
        MessageManager _messageManager = new MessageManager(new EfMessageRepository());

        public AdminMessageController(UserManager<AppUser> userManagerIdentity)
        {
            _userManagerIdentity = userManagerIdentity;
        }
        [HttpGet]
        public IActionResult Inbox()
        {
            var userId = Convert.ToInt32(_userManagerIdentity.GetUserId(User));
            var values = _messageManager.GetListByReceiver(userId);
            return View(values);
        }

        [HttpGet]
        public IActionResult SendBox()
        {
            var userId = Convert.ToInt32(_userManagerIdentity.GetUserId(User));
            var values = _messageManager.GetListBySender(userId);
            return View(values);
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(Message message)
        {
            message.SenderID = Convert.ToInt32(_userManagerIdentity.GetUserId(User));
            message.MessageStatus = true;
            message.MessageDate = DateTime.Now;
           _messageManager.TAdd(message);
            return RedirectToAction("Sendbox");
        }
    }
}
