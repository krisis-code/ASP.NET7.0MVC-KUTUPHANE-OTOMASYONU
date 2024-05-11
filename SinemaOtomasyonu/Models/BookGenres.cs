using System.ComponentModel.DataAnnotations;

namespace SinemaOtomasyonu.Models
{
    public class BookGenres
    {
        [Key]
        public Guid BookGenreId { get; set; }

        [Required]
        public string BookGenreName { get; set; }
    }
}
