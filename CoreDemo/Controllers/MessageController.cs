using System.Security.Claims;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageRepository());
        UserManager<AppUser> _userManagerIdentity;
        IUserService _userManager;
        public MessageController(UserManager<AppUser> userManager,IUserService userService)
        {
            _userManagerIdentity = userManager;
            _userManager = userService;
        }

        [HttpGet]
        public async Task<IActionResult> InBox()
        {
            var user = await _userManagerIdentity.GetUserAsync(User);
            var values = _messageManager.GetListByReceiver(user.Id);
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
        public IActionResult MessageDetails(int id)
        {
            var value = _messageManager.GetById(id);
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            var user = await _userManagerIdentity.GetUserAsync(User);
            var id = user.Id;

            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            var user = await _userManagerIdentity.GetUserAsync(User);
            message.SenderID = user.Id;
            message.ReceiverID = 2;
            message.MessageStatus = true;
            message.MessageDate = DateTime.Now;
            _messageManager.TAdd(message);
            return RedirectToAction("InBox");
        }

        [HttpGet]
        public IActionResult GetUsers(string searchTerm)
        {
            var users = _userManagerIdentity.Users
            .Where(u => u.Email.Contains(searchTerm) || u.UserName.Contains(searchTerm))
            .Select(u => new { label = u.UserName + " (" + u.Email + ")", value = u.Id })
            .ToList();
            return Json(users);
        }
    }
}
