using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Model;
using System.Collections.Generic;

namespace PetShop.Reposetory
{
    public class AnimalsRepository : IAnimalRepository
    {
        private PetStoreContext context;

        public AnimalsRepository(PetStoreContext context)
        {
            this.context = context;

        }


        public List<Animal> TopCommentedAnimals()
        {
             
            return context.Animals.OrderByDescending(animal => animal.Comments.Count()).Take(2).ToList();// orders  and return list of the top comments
        }

        public List<Animal> GetAllAnimals()//get all the animals
        {
            List<Animal> animalsList = context.Animals.ToList();
            return animalsList;
        }


        public Animal GetAnimal(int id)//get  the animal
        {



            return context.Animals!.Find(id);

     
        }

        public void  AddAnimal(Animal animal)
        {
            

            context.Animals.Add(animal);/// הוספת חיה
            context.SaveChanges(); /// שמירה בדאטה בייס
           
        }

        public void UpdateAnimal(int id, Animal animal)
        {
            Animal UpdateAnimal = context.Animals!.Where(a => a.AnimalId == id).FirstOrDefault()!;
            UpdateAnimal!.Age = animal.Age;
            UpdateAnimal.Name = animal.Name;
            UpdateAnimal.Description = animal.Description;
            UpdateAnimal.CategoryId = animal.CategoryId;
            UpdateAnimal.PhotoName = animal.PhotoName;
            context.SaveChanges();
        }
       

        public void DeleteAnimal(Animal a)
        {
            
            context.Animals.Remove(a);
            context.SaveChanges();
        }

        public void AddNewComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }



    }
}
