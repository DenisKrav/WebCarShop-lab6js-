using System.Linq;
using WebCarShop.Data.Interfaces;
using WebCarShop.Data.Models;

namespace WebCarShop.Data.Repositories
{
    public class CarsReposytory : IAllCars
    {
        private readonly UsedCarContext usedCarContext = new UsedCarContext();


        public IEnumerable<Car> allC => usedCarContext.Cars.ToList();
        public IEnumerable<Car> getAvailCars => usedCarContext.Cars.Where(p => p.Availability == "в наличии").ToList();
        public IEnumerable<Car> getSortCars => usedCarContext.Cars.OrderByDescending(p => p.Price).ToList();
        public IEnumerable<Car> getSortAvailCars => usedCarContext.Cars.Where(p => p.Availability == "в наличии").OrderByDescending(p => p.Price).ToList();
        public Car getobjectCar(int carId) => usedCarContext.Cars.FirstOrDefault(p => p.IdLot == carId);
    }
}
