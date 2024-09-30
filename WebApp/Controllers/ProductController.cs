using Microsoft.AspNetCore.Mvc;
using Model.Repositories;
using Model.Models;
using DataAccess.Data;


namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebApiExecuter webApiExecuter;

        public ProductController(IWebApiExecuter webApiExecuter)
        {
            this.webApiExecuter = webApiExecuter;
        }

        public async Task<IActionResult> Index()
        {
            return View(await webApiExecuter.InvokeGet<List<Products>>("products"));
        }

        public IActionResult CreateProduct()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(Products product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await webApiExecuter.InvokePost("products", product);
                    if (response != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                //catch (WebApiException ex)
                //{
                //    HandleWebApiException(ex);
                //}

            }

            return View(product);
        }

        public async Task<IActionResult> UpdateProduct(int Id)
        {
            try
            {
                var product = await webApiExecuter.InvokeGet<Products>($"products/{Id}");
                if (product != null)
                {
                    return View(product);
                }
            }
            //catch (WebApiException ex)
            //{
            //    HandleWebApiException(ex);
            //    return View();
            //}


            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Products product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await webApiExecuter.InvokePut($"products/{product.Id}", product);
                    return RedirectToAction(nameof(Index));
                }
                //catch (WebApiException ex)
                //{
                //    HandleWebApiException(ex);
                //}

            }

            return View(product);
        }

        public async Task<IActionResult> DeleteShirt(int Id)
        {
            try
            {
                await webApiExecuter.InvokeDelete($"products/{Id}");
                return RedirectToAction(nameof(Index));
            }
            catch (WebApiException ex)
            {
                HandleWebApiException(ex);
                return View(nameof(Index),
                    await webApiExecuter.InvokeGet<List<Products>>("products"));
            }
        }

        //private void HandleWebApiException(WebApiException ex)
        //{
        //    if (ex.ErrorResponse != null &&
        //        ex.ErrorResponse.Errors != null &&
        //        ex.ErrorResponse.Errors.Count > 0)
        //    {
        //        foreach (var error in ex.ErrorResponse.Errors)
        //        {
        //            ModelState.AddModelError(error.Key, string.Join("; ", error.Value));
        //        }
        //    }
        //    else if (ex.ErrorResponse != null)
        //    {
        //        ModelState.AddModelError("Error", ex.ErrorResponse.Title);
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("Error", ex.Message);
        //    }
        //}
    }



}

