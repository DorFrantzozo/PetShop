using Microsoft.AspNetCore.Mvc;
using PetShop.Model;
using PetShop.Reposetory;

namespace PetShop.Controllers
{
    public class AdminController : Controller
    {
        private IAnimalRepository repository;

        public AdminController(IAnimalRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.Category = CategoriesRepository.GetCategories();


            List<Animal> allAnimals = repository.GetAllAnimals();
            return View(allAnimals);
        }

        [HttpPost]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = repository.GetAnimal(id);
            if (animal == null)
            {
                return NotFound();
            }
            repository.DeleteAnimal(animal);


            return RedirectToAction("Index");
        }
    }
}
