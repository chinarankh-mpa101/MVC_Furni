namespace Furni101.App.ViewModels.ProductViewModels
{
   

    public class ProductUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageName { get; set; }
        public IFormFile? MainImage { get; set; }
        public string? MainImagePath { get; set; }
    }
}


