using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICartService
    {
        List<Car> GetCars();
        void Add(int carId);
        void Remove(int carId);
        bool IsInCart(int carId);
    }
}
