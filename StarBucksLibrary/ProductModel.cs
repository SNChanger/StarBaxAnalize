using System.Text.Json.Serialization;
namespace StarBucksLibrary
{ 

    public class ProductModelRecord
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("size")]
        public string? Size { get; set; }


        [JsonPropertyName("product_code")]
        public string? ProductCode { get; set; }

        [JsonPropertyName("product_name")]
        public string? ProductName { get; set; }

        [JsonPropertyName("product_note")]
        public string? ProductNote { get; set; }

        [JsonPropertyName("sales_day")]
        public string? SalesDay { get; set; }

    }

}