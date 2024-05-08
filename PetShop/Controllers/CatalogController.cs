using Microsoft.AspNetCore.Mvc;
using PetShop.Model;
using PetShop.Reposetory;

namespace PetShop.Controllers
{
    public class CatalogController : Controller
    {
        private IAnimalRepository repository;

        public CatalogController(IAnimalRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.Category = CategoriesRepository.GetCategories();
           

            List<Animal> allAnimals = repository.GetAllAnimals();
            return View(allAnimals);
        }

      
    }
}
