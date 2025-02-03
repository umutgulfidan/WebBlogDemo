using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = _notificationManager.GetList().Where(x=>x.NotificationStatus==true).OrderByDescending(x=>x.NotificationDate).ToList();
            return View(values);
        }
    }
}
