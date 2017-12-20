using Southwind.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Southwind.Contracts.Interfaces
{
    public interface ICategoryClient
    {
        Task<IEnumerable<Category>> LoadCategories();
    }
}