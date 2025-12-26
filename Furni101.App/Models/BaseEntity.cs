namespace Furni101.App.Models
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}