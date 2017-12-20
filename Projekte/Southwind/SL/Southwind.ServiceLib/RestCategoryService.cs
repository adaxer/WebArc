using Southwind.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Southwind.Contracts.Models;
using System.Threading.Tasks;

namespace Southwind.Services.Lib
{
    public class RestCategoryService : ICategoryClient
    {
        IRestService restService;
        private string baseUrl;

        public RestCategoryService(IRestService rest, string baseUrl)
        {
            restService = rest;
            this.baseUrl = baseUrl;
        }

        public async Task<IEnumerable<Category>> LoadCategories()
        {
            return await restService.GetDataAsync<IEnumerable<Category>>($"{baseUrl}/api/categories");
        }
    }
}
