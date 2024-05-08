using System;

namespace PetShop.Model
{
    public class Animal
    {


        public int AnimalId { get; set; }
        public string? Name { get; set; }

        public int Age { get; set; }

        public string? PhotoName { get; set; } 

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; } 
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

   
    }
}
