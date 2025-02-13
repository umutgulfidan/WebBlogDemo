using System.Security.Claims;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager _messageManager = new MessageManager(new EfMessageRepository());
        UserManager<AppUser> _userManager;

        public WriterMessageNotification(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var id = Convert.ToInt32(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var values = _messageManager.GetListByReceiver(user.Id);
            return View(values);
        }
    }
}
