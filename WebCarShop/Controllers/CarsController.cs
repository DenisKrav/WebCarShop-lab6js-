using Microsoft.AspNetCore.Mvc;
using WebCarShop.Data.Interfaces;
using WebCarShop.Data.Models;
using WebCarShop.ViewModels;

namespace WebCarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars allCars;

        public CarsController(IAllCars iAllCars) 
        {
            allCars = iAllCars;
        }

        public ViewResult ListCars()
        {
            ViewBag.Title = "Сторінка з автомобілями";
            CarsListViewModel obj = new CarsListViewModel();
            obj.AllCars = allCars.allC;
            return View(obj);
        }

        public ViewResult AvailCars()
        {
            ViewBag.Title = "Сторінка з автомобілями";
            CarsListViewModel obj = new CarsListViewModel();
            obj.AvailCars = allCars.getAvailCars;
            return View(obj);
        }

        public ViewResult SortCars()
        {
            ViewBag.Title = "Сторінка з автомобілями";
            CarsListViewModel obj = new CarsListViewModel();
            obj.SortCars = allCars.getSortCars;
            return View(obj);
        }

        public ViewResult SortAvailCars()
        {
            ViewBag.Title = "Сторінка з автомобілями";
            CarsListViewModel obj = new CarsListViewModel();
            obj.SortAvailCars = allCars.getSortAvailCars;
            return View(obj);
        }
    }
}
