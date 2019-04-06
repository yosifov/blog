namespace Blog.IntegrationTests
{
    using Newtonsoft.Json;

    public partial class Article
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        public static Article FromJson(string json) => JsonConvert.DeserializeObject<Article>(json, Converter.Settings);
    }
}
