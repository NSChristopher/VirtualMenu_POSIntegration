using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace VirtualMenu.Models
{
    public class Item
    {
        [Key]
        [JsonPropertyName("id")]
        public string itemId { get; set; }
        public bool activeStatus { get; set; }
        public string name { get; set; }
        public Category category { get; set; }
        public List<ServingSizePrice> servingSizePrices { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }

        //custome field
        public DateTime lastAccessed { get; set; } = DateTime.Now;

    }
}