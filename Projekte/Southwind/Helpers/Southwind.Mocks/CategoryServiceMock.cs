using Southwind.Contracts.Interfaces;
using Southwind.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Southwind.Mocks
{
    public class CategoryServiceMock : ICategoryClient
    {
        //public Task<IEnumerable<Category>> LoadCategories()
        //{
        //    var result = Task.Factory.StartNew<IEnumerable<Category>>(() =>
        //    {
        //        Task.Delay(2000).Wait();
        //        return new List<Category>
        //        {
        //            new Category { Id=1, Name="Steaks", Description="Medium or rare"},
        //            new Category{Id=2, Name="Drinks", Description="Soft or hard"}
        //        };
        //    });
        //    return result;
        //}

        public async Task<IEnumerable<Category>> LoadCategories()
        {
            await Task.Delay(2000);
            var result = new List<Category>
                {
                    new Category { Id=1, Name="Steaks", Description="Medium or rare"},
                    new Category{Id=2, Name="Drinks", Description="Soft or hard"}
                };
            return result;
        }
    }
}
