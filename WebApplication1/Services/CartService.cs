using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Entites;

namespace WebApplication1.Services
{
    public class CartService : ICartService
    {
        private readonly ICarService carService;
        private readonly HttpContext? httpContext;

        public CartService(ICarService carService, 
                           IHttpContextAccessor httpContextAccessor)
        {
            this.carService = carService;
            this.httpContext = httpContextAccessor.HttpContext;
        }

        public List<Car> GetCars()
        {
            var carIds = httpContext.Session.GetObject<List<int>>("cart");

            List<Car> cars = new List<Car>();

            if (carIds != null)
            {
                cars = carService.Get(carIds.ToArray());
            }

            return cars;
        }

        public void Add(int carId)
        {
            var carIds = httpContext.Session.GetObject<List<int>>("cart");

            if (carIds == null) carIds = new List<int>();
            carIds.Add(carId);

            httpContext.Session.SetObject("cart", carIds);
        }

        public void Remove(int carId)
        {
            var carIds = httpContext.Session.GetObject<List<int>>("cart");

            if (carIds == null) carIds = new List<int>();
            carIds.Remove(carId);

            httpContext.Session.SetObject("cart", carIds);
        }

        public bool IsInCart(int carId)
        {
            var carIds = httpContext.Session.GetObject<List<int>>("cart");
            if(carIds == null) return false;
            return carIds.Contains(carId);
        }
    }
}
