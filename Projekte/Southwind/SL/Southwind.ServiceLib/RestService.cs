using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Southwind.Services.Lib
{
    public class RestService : IRestService
    {
        public async Task<T> GetDataAsync<T>(string url) where T:class
        {
            // try-catch darum bauen
            var client = new HttpClient();
            var json = await client.GetStringAsync(url);
            if (typeof(T) == typeof(string))
                return json as T;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
