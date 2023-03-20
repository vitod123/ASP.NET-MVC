using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            return View(cartService.GetCars());
        }

        public IActionResult Add(int carId, string returnUrl)
        {
            cartService.Add(carId);

            return Redirect(returnUrl);
        }

        public IActionResult Remove(int carId, string returnUrl)
        {
            cartService.Remove(carId);

            return Redirect(returnUrl);
        }
    }
}
