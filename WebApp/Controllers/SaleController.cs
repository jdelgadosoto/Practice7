using Microsoft.AspNetCore.Mvc;
using Model.Repositories;
using Model.Models;

namespace WebApp.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View(SalesRepository.GetSale());
        }
    }
}
