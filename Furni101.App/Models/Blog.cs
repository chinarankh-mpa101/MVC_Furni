namespace Furni101.App.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text {  get; set; }
        public DateTime postedDate { get; set; }
        public string ImageName {  get; set; }
        public string ImageUrl { get; set; }

        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
