namespace Furni101.App.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageName {  get; set; }
        public string ImageUrl { get; set; }
    }
    //https://localhost:7078/assets/images/couch.png
}


