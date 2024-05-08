using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Model;
using PetShop.Reposetory;

namespace PetShop.Controllers
{
    public class SelectedAnimalController : Controller
    {
        private IAnimalRepository repository;

        public SelectedAnimalController(IAnimalRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index(int id)
        {
            Animal Animal = repository.GetAnimal(id);// pass the chosen animal
            ViewBag.AnimalId = Animal.AnimalId;   
            return View(Animal);
        }




  


        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
           
               
                repository.AddNewComment(comment);
                
                return RedirectToAction("Index", new { id = comment.AnimalId }); // Redirect to the appropriate action or view
          

            
        }
    }
}
