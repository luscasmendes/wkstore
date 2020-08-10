using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using wkfront.Models;

namespace wkfront.Services
{
    public interface IApiService
    {
        static async Task<JArray> GetProducts()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000/v1/products");

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            JArray contentJson = JArray.Parse(response.Content.ReadAsStringAsync().Result);

            return contentJson;
        }

        static async Task<JObject> GetProduct(int id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000/v1/products/" + id);

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            JObject contentJson = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            return contentJson;
        }

        static async Task<JObject> UpdateProduct(Product product)
        {
            var jsonString = JsonConvert.SerializeObject(new { id = product.Id, title = product.Title, categoryId = product.CategoryId });
            HttpContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().PutAsync("http://localhost:5000/v1/products/" + product.Id, httpContent);
            JObject contentJson = JObject.Parse(await response.Content.ReadAsStringAsync());

            return contentJson;
        }

        static async Task<JObject> InsertProduct(Product product)
        {
            var jsonString = JsonConvert.SerializeObject(new { title = product.Title, categoryId = product.CategoryId });
            HttpContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().PostAsync("http://localhost:5000/v1/products/", httpContent);
            JObject contentJson = JObject.Parse(await response.Content.ReadAsStringAsync());

            return contentJson;
        }

        static async Task<JObject> DeleteProduct(int id)
        {
            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().DeleteAsync("http://localhost:5000/v1/products/" + id);
            JObject contentJson = JObject.Parse(await response.Content.ReadAsStringAsync());

            return contentJson;
        }

                static async Task<JArray> GetCategories()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000/v1/categories");

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            JArray contentJson = JArray.Parse(response.Content.ReadAsStringAsync().Result);

            return contentJson;
        }

        static async Task<JObject> InsertCategory(Category category)
        {
            var jsonString = JsonConvert.SerializeObject(new { title = category.Title });
            HttpContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().PostAsync("http://localhost:5000/v1/categories/", httpContent);
            JObject contentJson = JObject.Parse(await response.Content.ReadAsStringAsync());

            return contentJson;
        }

        static async Task<JObject> DeleteCategory(int id)
        {
            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().DeleteAsync("http://localhost:5000/v1/categories/" + id);
            JObject contentJson = JObject.Parse(await response.Content.ReadAsStringAsync());

            return contentJson;
        }

        static async Task<JObject> UpdateCategory(Category category)
        {
            var jsonString = JsonConvert.SerializeObject(new { id = category.Id, title = category.Title });
            HttpContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().PutAsync("http://localhost:5000/v1/categories/" + category.Id, httpContent);
            JObject contentJson = JObject.Parse(await response.Content.ReadAsStringAsync());

            return contentJson;
        }

        static async Task<JObject> GetCategory(int id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000/v1/categories/" + id);

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            JObject contentJson = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            return contentJson;
        }
    }
}