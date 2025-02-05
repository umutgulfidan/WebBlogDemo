using System.Security.Claims;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterDropdownProfile : ViewComponent  
    {
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var id = Convert.ToInt32(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
            var writer = _writerManager.GetById(id);
            return View(writer);
        }
    }
}
