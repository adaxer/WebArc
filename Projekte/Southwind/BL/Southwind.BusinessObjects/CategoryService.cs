using Southwind.Contracts.Interfaces;
using Southwind.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace Southwind.BusinessLayer.Objects
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
