using System.Security.Claims;
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
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        UserManager<AppUser> _userManager;

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> InBox()
        {
            var user = await _userManager.GetUserAsync(User);
            var writerId = _writerManager.GetWriterByMail(user.Email).WriterID;
            var values = _messageManager.GetListByReceiver(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = _messageManager.GetById(id);
            return View(value);
        }
    }
}
