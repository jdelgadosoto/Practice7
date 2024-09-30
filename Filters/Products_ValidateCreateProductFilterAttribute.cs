using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Model.Repositories;
using Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace Filters
{
    public class Products_ValidateCreateProductFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;

        public Products_ValidateCreateProductFilterAttribute(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var product = context.ActionArguments["product"] as Products;

            if (product == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt object is null.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingProduct = db.Products.FirstOrDefault(x =>
                    !string.IsNullOrWhiteSpace(product.Name) &&
                    !string.IsNullOrWhiteSpace(x.Name) &&
                    x.Name.ToLower() == product.Name);

                if (existingProduct != null)
                {
                    context.ModelState.AddModelError("Shirt", "Shirt already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }


        }
    }
}
