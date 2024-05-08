using Microsoft.EntityFrameworkCore;
using PetShop.Model;
using System.Diagnostics.Metrics;
using System;

namespace PetShop.Data
{
    public class PetStoreContext : DbContext
    {
        public PetStoreContext(DbContextOptions<PetStoreContext> options) : base(options)
        {

        }
        public PetStoreContext()
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Mammals" },
                new Category { CategoryId = 2, Name = "Reptails" },
                  new Category { CategoryId = 3, Name = "Bird" }
            );
            modelBuilder.Entity<Animal>().HasData(
                new Animal { AnimalId = 1, CategoryId = 1, Name = "Dolphin", Age = 7, Description = "A dolphin is an aquatic mammal within the infraorder Cetacea" , PhotoName ="dolphin.jpg" },
                new Animal { AnimalId = 2, CategoryId = 2, Name = "Ape", Age = 5, Description = "Apes (collectively Hominoidea /hɒmɪˈnɔɪdi.ə/) are a clade of Old World simians native to sub-Saharan Africa and Southeast Asia (though they were more widespread in Africa, most of Asia, and Europe in prehistory), which together with its sister group Cercopithecidae form the catarrhine clade, cladistically making them monkeys. Apes do not have tails due to a mutation of the TBXT gene.[2] In traditional and non-scientific use, the term ape can include tailless primates taxonomically considered Cercopithecidae (such as the Barbary ape and black ape), and is thus not equivalent to the scientific taxon Hominoidea. There are two extant branches of the superfamily Hominoidea: the gibbons, or lesser apes; and the hominids, or great apes.", PhotoName = "Great-Ape-Gorilla.jpg"    },
                new Animal { AnimalId = 3, CategoryId = 2, Name = "lizard", Age = 4, Description = "lizards have a small head, short neck, and long body and tail. Unlike snakes, most lizards have moveable eyelids. There are currently over 4,675 lizard species, including iguanas, ", PhotoName = "animals-lizard-redheadedrockagama.jpg" }
            );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, AnimalId=1, CommentMessage = "hey" },
                new Comment { CommentId = 2,AnimalId =2,  CommentMessage = "DANI DANONA" },
                new Comment { CommentId = 3, AnimalId = 3, CommentMessage = "DANI DANONA", },
                   new Comment { CommentId = 4, AnimalId = 3, CommentMessage = "shalom", },
                   new Comment { CommentId = 5, AnimalId = 2, CommentMessage = "lll", }



            );
        }
    }
}
