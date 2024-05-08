using Microsoft.AspNetCore.Mvc;
using PetShop.Data;
using PetShop.Model;
using PetShop.Reposetory;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        
        private IAnimalRepository repository;
        

     
        public HomeController(IAnimalRepository repository)
        {
           this.repository = repository;
        }

        public IActionResult Index()
        {
           List<Animal> topCommendsAnimals = repository.GetAllAnimals().OrderByDescending(animal => animal.Comments.Count).Take(2).ToList();
            return View(topCommendsAnimals);
        }


      
    }
}
 