using Microsoft.AspNetCore.Mvc;
using ReponsitoryMVC.Models;
using ReponsitoryMVC.Repository;

namespace ReponsitoryMVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository<Product> repository;
        
        public ProductController(IProductRepository<Product> repository)
        {
            this.repository = repository;
        }
        public IActionResult Product()
        {
            var product = repository.GetAll();
            return View(product);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(product);
                repository.Save();
                return RedirectToAction("Product", "Product"); 
            }
            return View("Create", product); 
        }
        public IActionResult Edit(int id)
        {
            var product = repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Update(product);
                repository.Save();
                return RedirectToAction("Product", "Product"); 
            }

            return View("Edit", product); 
        }
        public IActionResult Delete(int id)
        {
            Product product = repository.GetById(id);
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Product", "Product");   
        }
        public IActionResult Arrange()
        {
            var arr = repository.Arrange();
            return View("Product", arr);
        }
        public IActionResult ArrangebyName()
        {
            var arr = repository.ArrangebyName();
            return View("Product", arr);
        }


    }
}
