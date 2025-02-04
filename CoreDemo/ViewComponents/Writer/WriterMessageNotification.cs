using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager _messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            var values = _messageManager.GetListByReceiver(1);
            return View(values);
        }
    }
}
