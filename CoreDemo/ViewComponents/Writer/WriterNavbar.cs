using System.Security.Claims;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNavbar : ViewComponent
    {
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var id = Convert.ToInt32(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
            EntityLayer.Concrete.Writer writerValues = _writerManager.GetById(id);
            return View(writerValues);
        }
    }
}
