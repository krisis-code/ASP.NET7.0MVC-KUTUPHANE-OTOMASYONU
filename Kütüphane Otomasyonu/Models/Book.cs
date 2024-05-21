using System.ComponentModel.DataAnnotations;

namespace KitapKiralamaOtomasyonu.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        
        public string Description { get; set; }
        [Required]
        public string Writer { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
