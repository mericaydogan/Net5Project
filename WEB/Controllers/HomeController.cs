using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.BLL.Service;
using Project.Common;
using Project.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WEB.Models;
using WEB.Models.ViewModels;
using WEB.Utils;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public HomeController(IProductService productService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.productService = productService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            TempData["sepet"] = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
            
            return View(productService.GetAllProducts().ToList());
        }

        public IActionResult AddToCart(int id)
        {
            Cart cartSession;
            
            if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") == null)
            {
                cartSession = new Cart();
            }
            else
            {
                cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
            }

            //Cart cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") == null ? new Cart() : SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");

            var newProduct = productService.Get(id);




            CartItem cartItem = new CartItem()
            {
                Id = newProduct.Id,
                ProductName = newProduct.ProductName,
                UnitPrice = newProduct.UnitPrice

            };


            cartSession.AddItem(cartItem);

            SessionHelper.SetProductJson(HttpContext.Session, "sepet", cartSession);

          





            return RedirectToAction("Index");
        }

        //todo: kullanıcı giriş yapmadan önce sepette ürün adeti gösterilmiyor.
        public IActionResult MyCart()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") != null)
                {
                    Cart c = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
                    return View(c.MyCart);
                }
                else
                {
                    return RedirectToAction("Index");
                }


            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerUser)
        {
            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser()
                {
                    UserName = registerUser.Username,
                    Email = registerUser.Email
                };

                var result =await userManager.CreateAsync(newUser, registerUser.Password);



                var registerToken = "";
                if (result.Succeeded)
                {
                   
                    while (true)
                    {
                        registerToken = userManager.GenerateEmailConfirmationTokenAsync(newUser).Result;
                        if (!registerToken.Contains("/"))
                        {
                            break;
                        }
                    }

                   
                     
                    MailSender.SendEmail(registerUser.Email, "Register", $"Merhaba {registerUser.Username}! kayıt işleminiz başarılı şekilde oluşturuldu! Üyeliği tamamlamak için linke tıklayın https://localhost:5001/home/confirmation/"+newUser.Id+"/"+registerToken);

                    TempData["result"] = $"{newUser.Email} adresine aktivasyon maili gönderdik. Üyeliğinizi aktif hale getirmek için ilgili linki tıklayın.";

                    //return RedirectToAction("Confirmation", new { id = newUser.Id, registerCode = registerToken.Result });
                    return View(registerUser);
                }
                else
                {
                    return View(registerUser);
                }
                
            }
            return View(registerUser);
        }

        public async Task<IActionResult> Confirmation(string id,string registerCode)
        {
            if (id != null && registerCode != null)
            {
                var user = await userManager.FindByIdAsync(id);
                var confirm = await userManager.ConfirmEmailAsync(user, registerCode);
                if (confirm.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                
            }
            return View();
        }
       
        public IActionResult Login()
        {

            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user =await userManager.FindByNameAsync(loginVM.Username);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                       
                        return RedirectToAction("Index");
                    }
                }
                return View();

            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
