using Microsoft.AspNetCore.Mvc;
using ReponsitoryMVC.Repository;

namespace ReponsitoryMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var products = _productRepository.GetProducts();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


    }
}
