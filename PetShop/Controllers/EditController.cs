using Microsoft.AspNetCore.Mvc;
using PetShop.Model;
using PetShop.Reposetory;

namespace PetShop.Controllers
{
    public class EditController : Controller
    {
        private IAnimalRepository repository;
        private IWebHostEnvironment webHostEnvironment;


        public EditController(IAnimalRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            this.repository = repository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int id)
        {
            ViewBag.Category = CategoriesRepository.GetCategories();// adds the category to the view

            Animal Animal = repository.GetAnimal(id);//check how to add id 
            return View(Animal);


        }

        [HttpPost]
        public IActionResult EditAnimal(Animal updatedAnimal, IFormFile Photo)
        {



            if (Photo != null)
            {
                var fileName = Guid.NewGuid().ToString() + Photo.FileName; // new id to img file 
                var filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", fileName); // path
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
                updatedAnimal.PhotoName = fileName;
            }

            Animal existingAnimal = repository.GetAnimal(updatedAnimal.AnimalId);

            repository.UpdateAnimal(existingAnimal.AnimalId, updatedAnimal);

            return RedirectToAction("Index", "Admin");



        

        }


    }
}
