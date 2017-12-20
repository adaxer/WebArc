using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Southwind.Contracts.Interfaces;
using Southwind.Contracts.Models;

namespace Southwind.ServiceApp.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ICategoryService categoryService;

        public CategoriesController(ICategoryService catService)
        {
            categoryService = catService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var data = categoryService.LoadCategories().Select(c=>new Category { Id = c.CategoryId, Name = c.CategoryName, Description = c.Description }).ToList();
            return Ok(data);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
