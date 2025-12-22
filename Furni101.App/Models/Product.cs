namespace Furni101.App.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageName {  get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate {  get; set; }
        public DateTime? UpdateDate {  get; set; }
        public bool IsDeleted { get; set; }
    }
    //https://localhost:7078/assets/images/couch.png
}
