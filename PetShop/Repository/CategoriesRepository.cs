using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System;
using PetShop.Model;

namespace PetShop.Reposetory
{
    public class CategoriesRepository
    {


        private static List<Category> _categories = new List<Category>()
        {
            new Category {CategoryId = 1, Name = "Reptails" },

             new Category {CategoryId = 2, Name = "Mammals" },

              new Category {CategoryId = 3, Name = "Birds" }
        };


        public static List<Category> GetCategories() => _categories;// get the category list 

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId); //search for the first category thats have the same id that we are giving to the function
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,

                };
            }
            return null;
        }


        public static void AddCategory(Category category)// adds a new category
        {
            var maxId = _categories.Max(x => x.CategoryId);
            _categories.Add(category);
        }


       





    }


}
