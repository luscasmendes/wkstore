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

    public class ProductController : Controller
    {

        public async Task<IActionResult> Index()
        {
            ViewBag.products = await IApiService.GetProducts();
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await IApiService.GetCategories();
            ViewBag.product = await IApiService.GetProduct(id);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await IApiService.DeleteProduct(id);
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> New(int id)
        {
            ViewBag.Categories = await IApiService.GetCategories();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            await IApiService.UpdateProduct(product);
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await IApiService.InsertProduct(product);
            return RedirectToAction("Index", "Product");
        }
    }
}
