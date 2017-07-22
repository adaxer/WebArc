using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiSelfHost
{
    public class ValuesController : ApiController
    {
        // GET api/values 
        public IEnumerable<CategoryDTO> Get()
        {
            var db = new NorthwindEntities();
            //var cats = db.Categories.Select(c=>new CategoryDTO{ CategoryID= .CategoryDTO....ToList();
            var cats = db.Categories.ToList();
            var result = Mapper.Map<List<Category>, List<CategoryDTO>>(cats);
            return result;
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        [HttpPost]
        [Route("api2/testpost")]
        public Customer Foo(Customer value)
        {
            Console.WriteLine("Von {0} kam der Wert: {1}", RequestContext.RouteData.Route.RouteTemplate, value);
            return new Customer { Id = value.Id + 1, Name = value.Name };
        }

        public CategoryDTO Post(CategoryDTO category)
        {
            var cat = Mapper.Map<CategoryDTO, Category>(category);
            // in db einfügen
            cat.CategoryID = 42;
            return Mapper.Map<Category, CategoryDTO>(cat);
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}",Id, Name);
        }
    }

    public partial class CategoryDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

}
