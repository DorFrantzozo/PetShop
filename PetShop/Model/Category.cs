using Microsoft.EntityFrameworkCore;

namespace PetShop.Model
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Animal>? Animals { get; set; } = new List<Animal>();
    }
}
