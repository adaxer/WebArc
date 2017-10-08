using System.Threading.Tasks;

namespace Southwind.Services.Lib
{
    public interface IRestService
    {
        Task<T> GetDataAsync<T>(string url) where T:class;
    }
}
