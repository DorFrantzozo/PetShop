using Microsoft.AspNetCore.Mvc;
using PetShop.Model;
using PetShop.Reposetory;

namespace PetShop.Controllers
{
    public class AddAnimalController : Controller
    {
        private IAnimalRepository repository;
        private IWebHostEnvironment webHostEnvironment;// adds accese to wwwroot
        public AddAnimalController(IAnimalRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            this.repository = repository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ViewBag.Category = CategoriesRepository.GetCategories();


            List<Animal> allAnimals = repository.GetAllAnimals();
            return View(allAnimals);
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal, IFormFile Photo)
        {
            var fileName = Guid.NewGuid().ToString() + Photo.FileName; // new id to img file 
            var filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", fileName); // path
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            animal.PhotoName = fileName;
            repository.AddAnimal(animal);

            return RedirectToAction("Index", "Home", new { AnimalId = animal.AnimalId });


        }
    }
}