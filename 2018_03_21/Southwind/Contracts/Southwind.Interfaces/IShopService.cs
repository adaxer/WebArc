using Southwind.Models;
using System;
using System.Collections.Generic;

namespace Southwind.Interfaces
{
    public interface IShopService
    {
        IEnumerable<Category> GetCategories();
    }
}
