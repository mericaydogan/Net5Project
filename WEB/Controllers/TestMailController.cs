using Microsoft.AspNetCore.Mvc;
using Project.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Controllers
{
    public class TestMailController : Controller
    {
        public IActionResult Index()
        {
            MailSender.SendEmail("fatih.gunalp@gmail.com", "Test maili", "bu eposta test amaçlı gönderildi!");
            return RedirectToAction("Index", "Home");
        }
    }
}
