using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterByID(int writerId)
        {
            var findWriter = writers.FirstOrDefault(writers => writers.Id == writerId);
            var jsonWriter = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriter);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(w => w.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        [HttpPost]
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(writer => writer.Id == w.Id);
            writer.Name = w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass> 
        { 
            new WriterClass()
            {
                Id = 1,
                Name = "Ayşe"
            },
            new WriterClass()
            {
                Id = 2,
                Name = "Ahmet"
            },
            new WriterClass()
            {
                Id = 3,
                Name = "Buse"
            }
        };
    }
}
