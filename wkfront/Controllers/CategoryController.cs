using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refit;
using wkfront.Models;
using wkfront.Services;

namespace wkfront.Controllers
{

    public class CategoryController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var categories = await IApiService.GetCategories();
            ViewBag.categories = categories;
            return View();
        }

        public async Task<IActionResult> New(int id)
        { 
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await IApiService.GetCategory(id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category category)
        {
            await IApiService.UpdateCategory(category);
            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            await IApiService.InsertCategory(category);
            return RedirectToAction("Index", "Category");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await IApiService.DeleteCategory(id);
            return RedirectToAction("Index", "Category");
        }
    }
}
