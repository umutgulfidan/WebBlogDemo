using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageRepository());
        public IActionResult InBox()
        {
            var values = _messageManager.GetListByReceiver(1);
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
