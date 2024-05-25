using SinemaOtomasyonu.Models;

namespace KitapKiralamaOtomasyonu.Models
{
	public interface IBorrowRepository : IRepository<Borrow>
	{
		void Update(Borrow borrow);

		void save();
	}
}
