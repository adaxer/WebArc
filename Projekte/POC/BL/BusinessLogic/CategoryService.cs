using Southwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Southwind.Models;

namespace Southwind.BusinessLogic
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> catRepo)
        {
            categoryRepository = catRepo;
        }

        public void AddCategory(Category category)
        {
            categoryRepository.Add(category);
            categoryRepository.Save();
        }

        public IEnumerable<Category> LoadCategories()
        {
             return categoryRepository.Find().ToList();
        }
    }
}
