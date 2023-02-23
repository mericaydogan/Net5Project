using Microsoft.AspNetCore.Mvc;
using Project.BLL.Service;
using Project.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            TempData["Title"] = "Product";
            var products = productService.GetAllProducts().ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            TempData["Title"] = "Create Product";
            //ViewBag.Categories = categoryService.GetAllCategories().ToList();
            ViewBag.Categories = categoryService.GetAllCategories()
                .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { 
                    Text = x.CategoryName, Value = x.Id.ToString() 
                });
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            productService.CreateProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = productService.Get(id);
            productService.RemoveProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var product = productService.Get(id);
            ViewBag.Categories = categoryService.GetAllCategories()
               .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
               {
                   Text = x.CategoryName,
                   Value = x.Id.ToString()
               });
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            productService.UpdateProduct(product);
            return RedirectToAction("Index");
        }
    }
}
