using PetShop.Model;

namespace PetShop.Reposetory
{
    public interface IAnimalRepository
    {
        public List<Animal> TopCommentedAnimals();

        public List<Animal> GetAllAnimals();//get all the animals

        public Animal GetAnimal(int id);

        public void AddAnimal(Animal animal);

        public void UpdateAnimal(int id, Animal animal);

        public void DeleteAnimal(Animal a);

        public void AddNewComment(Comment comment);


    }
}
