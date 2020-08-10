using Newtonsoft.Json;

namespace wkfront.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
