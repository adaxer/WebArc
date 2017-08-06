using Southwind.Interfaces;
using Southwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Southwind.BLHost
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private ICategoryService categoryService;

        public CategoriesController(ICategoryService cats)
        {
            categoryService = cats;
        }
        
        [Route("all")]
        public IEnumerable<Category> Get()
        {
            return categoryService.LoadCategories();
        }

        // GET api/categories/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/categories 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/categories/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/categories/5 
        public void Delete(int id)
        {
        }
    }
}
