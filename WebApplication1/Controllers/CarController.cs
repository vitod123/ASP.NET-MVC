using BusinessLogic.Services;
using DataAccess;
using DataAccess.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;
        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        // GET: ~/Cars/Index
        public IActionResult Index()
        {
            return View(carService.GetAll());
        }

        // GET: ~/Cars/Details/{id}
        public IActionResult Details(int id, string returnUrl = null)
        {

            if (id < 0) return BadRequest(); //error 400

            var car = carService.Get(id);

            if (car == null) return NotFound(); //error 404

            ViewBag.ReturnUrl = returnUrl;
            return View(car);
        }

        // GET: ~/Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ~/Cars/Create
        [HttpPost]
        public IActionResult Create(Car car) // car - model
        {
            //validations
            if (!ModelState.IsValid)
            {
                return View(car);
            }

            carService.Create(car);

            return RedirectToAction(nameof(Index));
        }

        // GET: ~/Cars/Edit/{id}
        public IActionResult Edit(int id)
        {
            var car = carService.Get(id);

            if (car == null) return NotFound();

            return View(car);

            //context.SaveChanges();
        }

        // POST: ~/Cars/Edit/{id}
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            //validations
            if (!ModelState.IsValid)
            {
                return View(car);
            }

            // edit car in database
            carService.Edit(car);

            return RedirectToAction(nameof(Index));
        }

        // GET: ~/Cars/Delete/{id}
        public IActionResult Delete(int id)
        {
            carService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
