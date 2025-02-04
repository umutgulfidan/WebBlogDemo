﻿using System.Security.Claims;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace CoreDemo.Controllers
{
    public class LoginController : Controller
    {

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
        {
            Context context = new Context();
            var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);

            if (dataValue != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.NameIdentifier,dataValue.WriterID.ToString()),
                    new Claim(ClaimTypes.Name,dataValue.WriterName),
                    new Claim(ClaimTypes.Email, dataValue.WriterMail),
                };

                var userIdentity = new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                return View();
            }

        }
    }
}
//Context c = new Context();
//var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
//if (dataValue != null)
//{
//    HttpContext.Session.SetString("username", writer.WriterMail);
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View();
//}