using System.Security.Claims;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = _blogManager.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            if (id == 0)
            {
                // ID verilmediği durumda bir hata mesajı veya başka bir sayfaya yönlendirme yapılabilir
                return RedirectToAction("Index", "Blog");  // Blog ana sayfasına yönlendirme örneği
            }
            var values = _blogManager.GetById(id);

            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var id = Convert.ToInt32(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
            var values = _blogManager.GetListWithCategoryByWriter(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }
                                                   ).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        private bool CheckBothOfImages(AddBlogWithImage blogWithImage)
        {
            if (blogWithImage.BlogImage == null || blogWithImage.BlogThumbnailImage == null)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        public IActionResult BlogAdd(AddBlogWithImage blogWithImage)
        {

            var id = Convert.ToInt32(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);

            if (!CheckBothOfImages(blogWithImage))
            {
                ViewBag.ImageError = "İki Resmi Seçtiğinizden de emin olun!";
            }

            Blog blog = new Blog()
            {
                BlogStatus = true,
                BlogImage = CheckBothOfImages(blogWithImage) ? FileHelper.AddBlogImage(blogWithImage.BlogImage) : "",
                BlogThumbnailImage = CheckBothOfImages(blogWithImage) ? FileHelper.AddBlogThumbnailImage(blogWithImage.BlogThumbnailImage) : "",
                BlogCreateDate = DateTime.Now,
                BlogContent = blogWithImage.BlogContent,
                BlogTitle = blogWithImage.BlogTitle,
                CategoryID = blogWithImage.CategoryID,
                WriterID = id
            };

            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);


            if (results.IsValid)
            {
                _blogManager.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                ModelState.Clear();
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                CategoryManager cm = new CategoryManager(new EfCategoryRepository());
                List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryID.ToString()
                                                       }
                                                       ).ToList();
                ViewBag.cv = categoryValues;
            }
            return View(blog);
        }

        public IActionResult DeleteBlog(int id)
        {
            var blog = _blogManager.GetById(id);
            _blogManager.TDelete(blog);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogValue = _blogManager.GetById(id);
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());

            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }
                                                   ).ToList();
            ViewBag.cv = categoryValues;

            return View(blogValue);
        }
        [HttpPost]

        public IActionResult EditBlog(AddBlogWithImage blogWithImage)
        {
            Blog blog = _blogManager.GetById( blogWithImage.BlogID);
            blog.BlogTitle = blogWithImage.BlogTitle;
            blog.BlogContent = blogWithImage.BlogContent;
            blog.CategoryID = blogWithImage.CategoryID;



            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);
            blog.BlogImage = blogWithImage.BlogImage != null ? FileHelper.AddBlogImage(blogWithImage.BlogImage) : blog.BlogImage;
            blog.BlogThumbnailImage = blogWithImage.BlogThumbnailImage != null ? FileHelper.AddBlogThumbnailImage(blogWithImage.BlogThumbnailImage) : blog.BlogThumbnailImage;


            if (results.IsValid)
            {
                _blogManager.TUpdate(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                ModelState.Clear();
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                CategoryManager cm = new CategoryManager(new EfCategoryRepository());
                List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryID.ToString()
                                                       }
                                                       ).ToList();
                ViewBag.cv = categoryValues;
            }
            return View(blog);
        }
    }
}
