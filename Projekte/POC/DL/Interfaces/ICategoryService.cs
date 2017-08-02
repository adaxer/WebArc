using Southwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southwind.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> LoadCategories();
    }
}
