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
        public IEnumerable<Category> LoadCategories()
        {
            var cats = new List<Category>
            {
                new Category{ CategoryID=1, CategoryName="Drinks", Description="Getränke aller Art"},
                new Category{ CategoryID=2, CategoryName="Burgers", Description="Ham- Cheese- und Businessburger"},
            };
            return cats;
        }
    }
}
