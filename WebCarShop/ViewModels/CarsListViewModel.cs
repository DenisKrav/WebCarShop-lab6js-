using WebCarShop.Data.Models;

namespace WebCarShop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }
        public IEnumerable<Car> AvailCars { get; set; }
        public IEnumerable<Car> SortCars { get; set; }
        public IEnumerable<Car> SortAvailCars { get; set; }

    }
}
