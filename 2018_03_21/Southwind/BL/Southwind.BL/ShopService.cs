using Southwind.Interfaces;
using Southwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southwind.BL
{
    public class ShopService : IShopService
    {
        IRepository<Category> _categoryRepository;

        public ShopService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.Find().ToList();
        }
    }
}
