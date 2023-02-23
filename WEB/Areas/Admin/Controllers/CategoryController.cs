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
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            TempData["Title"] = "Category";
            var categories = categoryService.GetAllCategories().ToList();
            //todo: kategoriler listenirken o kategoriye ait ürün sayısı da gösterilecek.
            return View(categories);
        }

        public IActionResult Create()
        {
            TempData["Title"] = "Create Category";
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            categoryService.CreateCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = categoryService.Get(id);
            categoryService.RemoveCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var category = categoryService.Get(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }
    }
}
