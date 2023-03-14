namespace ClassLibrary.Models
{
    public class Item
    {
        public string id { get; set; }
        public bool activeStatus { get; set; }
        public string name { get; set; }
        public Category category { get; set; }
        public List<ServingSizePrice> servingSizePrices { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }

        //custome field
        public DateTime lastAccessed { get; set; }

    }
}