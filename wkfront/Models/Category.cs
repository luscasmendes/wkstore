using Newtonsoft.Json;

namespace wkfront.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
