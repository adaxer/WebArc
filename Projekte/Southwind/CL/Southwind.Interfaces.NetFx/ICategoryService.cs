using Southwind.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Southwind.Contracts.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> LoadCategories();
    }
}