using Southwind.Contracts.Interfaces;
using Southwind.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Southwind.BusinessLayer.Objects
{
    public class CategoryService : ICategoryService
    {
        public async Task<IEnumerable<Category>> LoadCategories()
        {
            await Task.Delay(2000);
            var result = new List<Category>
                {
                    new Category { Id=1, Name="Hummer & Kaviar", Description="Medium or rare"},
                    new Category{Id=2, Name="Drinks", Description="Soft or hard"}
                };
            return result;
        }
    }
}
