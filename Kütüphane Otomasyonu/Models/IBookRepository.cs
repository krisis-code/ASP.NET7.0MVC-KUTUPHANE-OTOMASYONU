using SinemaOtomasyonu.Models;

namespace KitapKiralamaOtomasyonu.Models
{
	public interface IBookRepository : IRepository<Book>
	{
		void Update(Book book);

		void save();
	}
}
