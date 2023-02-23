using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(IProductService productService, UserManager<IdentityUser> userManager)
        {
            this.productService = productService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            TempData["Title"] = "Anasayfa";
            ViewBag.SiparisSayisi = 100;//todo: sepet işleminin ardından yapılacak.
            ViewBag.UrunSayisi = productService.GetAllProducts().Count();
            ViewBag.KullaniciSayisi = userManager.Users.Count();
            ViewBag.Gelir = 100;//todo: sipariş işleminin ardından yapılacak.
            return View();
        }
    }
}
