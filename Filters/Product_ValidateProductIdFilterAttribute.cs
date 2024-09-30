using DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public class Product_ValidateProductIdFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;

        public Product_ValidateProductIdFilterAttribute(ApplicationDbContext db)
        {
            this.db = db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var productId = context.ActionArguments["id"] as int?;
            if (productId.HasValue)
            {
                if (productId.Value <= 0)
                {
                    context.ModelState.AddModelError("ProductId", "ProductId is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else
                {
                    var product = db.Products.Find(productId.Value);

                    if (product == null)
                    {
                        context.ModelState.AddModelError("ProductId", "Product doesn't exist.");
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(problemDetails);
                    }
                    else
                    {
                        context.HttpContext.Items["product"] = product;
                    }
                }
            }
        }
    }
}
