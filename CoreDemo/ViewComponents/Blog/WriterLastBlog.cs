﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = _blogManager.GetBlogListWithWriter(id).OrderByDescending(x=>x.BlogCreateDate).Take(5).ToList();
            return View(values);
        }
    }
}
