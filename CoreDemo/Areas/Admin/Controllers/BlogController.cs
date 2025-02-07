using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(BlogRowCount,1).Value = item.ID;
                    workSheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using(var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content , "application/vnd.openxmlformats-officedocument.spreedsheetml.sheet","BlogListesi.xlsx" );
                }

            }

        }

        private List<BlogExcelModel> GetBlogList()
        {
            List<BlogExcelModel> blogs =  new List<BlogExcelModel>();
            using (var c = new Context())
            {
                blogs = c.Blogs.Select(x => new BlogExcelModel()
                {
                    ID=x.BlogID,
                    BlogName = x.BlogTitle
                }).ToList();
            }
            return blogs;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }
    }
}
