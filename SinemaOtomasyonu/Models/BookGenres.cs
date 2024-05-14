using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SinemaOtomasyonu.Models
{
    public class BookGenres
    {
        [Key]
        public Guid BookGenreId { get; set; }

        [Required]
        [DisplayName("Kitap Türü Adı")]
        [MaxLength(25)]
        public string BookGenreName { get; set; }
    }
}
