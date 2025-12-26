namespace Furni101.App.ViewModels.ProductViewModels
{
    public class ProductCreateVM
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageName { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}

