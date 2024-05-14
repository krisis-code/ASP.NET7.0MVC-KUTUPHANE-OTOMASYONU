using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SinemaOtomasyonu.Models
{
    public class BookGenres
    {
        [Key]
        public Guid BookGenreId { get; set; }

        [Required(ErrorMessage ="Kitap türü boş bırakılamaz")]
        [DisplayName("Kitap Türü Adı")]
        [MaxLength(25)]
        public string BookGenreName { get; set; }
    }
}
