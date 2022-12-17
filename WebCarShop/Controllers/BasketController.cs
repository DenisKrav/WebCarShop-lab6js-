using Microsoft.AspNetCore.Mvc;

namespace WebCarShop.Controllers
{
    public class BasketController : Controller
    {
        public ViewResult BasketElements()
        {
            ViewBag.Title = "Кошик";
            return View();
        }
    }
}
