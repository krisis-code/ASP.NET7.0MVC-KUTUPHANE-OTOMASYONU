using SinemaOtomasyonu.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

		public Guid BookGenreId { get; set; }
        [ForeignKey("BookGenreId")]
        public BookGenres BookGenres { get; set; }

        public string ImageUrl { get; set; }
	}
}
