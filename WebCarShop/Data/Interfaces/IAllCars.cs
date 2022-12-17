using WebCarShop.Data.Models;

namespace WebCarShop.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> allC { get; }
        IEnumerable<Car> getAvailCars { get; }
        IEnumerable<Car> getSortCars { get; }
        IEnumerable<Car> getSortAvailCars { get; }
        Car getobjectCar(int carId);
    }
}
