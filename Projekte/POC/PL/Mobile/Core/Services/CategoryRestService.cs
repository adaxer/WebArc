using Southwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Southwind.Models;
using Refit;

namespace Southwind.Core.Services
{
    public class CategoryRestService : ICategoryService
    {
        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> LoadCategories()
        {
            try
            {
                var catApi = RestService.For<ISouthwindApi>("http://localhost:9000/api/categories");

                var result = catApi.GetCategories().Result;
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }

    public interface ISouthwindApi
    {
        [Get("/all")]
        Task<IEnumerable<Category>> GetCategories();
    }
}
