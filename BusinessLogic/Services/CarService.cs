 using DataAccess;
using DataAccess.Entites;
using DataAccess.Interfaces;

namespace BusinessLogic.Services
{

    public interface ICarService
    {
        List<Car> GetAll();

        List<Car> Get(int[] ids);
        Car? Get(int id);

        void Create(Car car);
        void Delete(int id);
        void Edit(Car car);
    }

    public class CarService : ICarService
    {
        //private readonly CarDbContext context;
        private IRepository<Car> carRepo;

        public CarService(IRepository<Car> carRepo)
        {
            this.carRepo = carRepo;
        }

        public void Create(Car car)
        {
            carRepo.Insert(car);
            carRepo.Save();
        }

        public void Delete(int id)
        {
            var item = Get(id);

            if (item == null) return;

            carRepo.Delete(item);
            carRepo.Save();
        }

        public void Edit(Car car)
        {
            carRepo.Update(car);
            carRepo.Save();
        }

        public List<Car> GetAll()
        {
            return carRepo.Get().ToList();
        }

        public Car? Get(int id)
        {
            if (id < 0) return null; //exeption

            var car =carRepo.GetByID(id);

            /*if (car == null) return null;*/ //exeption

            return car;
        }

        public List<Car> Get(int[] ids)
        {
            return carRepo.Get(x => ids.Contains(x.Id)).ToList();
        }
    }

}