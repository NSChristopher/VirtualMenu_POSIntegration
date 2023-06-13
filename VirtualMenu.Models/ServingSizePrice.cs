using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtualMenu.Models
{
    public class ServingSizePrice
    {
        [Key]
        [JsonPropertyName("id")]
        public string servingSizeId { get; set; }
        public string name { get; set; }
        public string priceStr { get; set; }
    }
}