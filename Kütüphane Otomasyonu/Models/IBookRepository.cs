using SinemaOtomasyonu.Models;

namespace KitapKiralamaOtomasyonu.Models
{
	public interface IBookGenreRepository : IRepository<BookGenres>
	{
		void Update(BookGenres bookGenres);

		void save();
	}
}
