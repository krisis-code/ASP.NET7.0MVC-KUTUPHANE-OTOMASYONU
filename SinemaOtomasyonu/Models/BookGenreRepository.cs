using Microsoft.EntityFrameworkCore;
using SinemaOtomasyonu.Models;
using SinemaOtomasyonu.Utilitiy;
using System.Linq.Expressions;

namespace KitapKiralamaOtomasyonu.Models
{
	public class BookGenreRepository : Repository<BookGenres>, IBookGenreRepository 
	{
		private  AppDbContext _appDbContext;

		public BookGenreRepository(AppDbContext appDbContext, DbSet<BookGenres> dbSet) : base(appDbContext, dbSet)
		{
			_appDbContext = appDbContext;
		}

		public void save()
		{
			throw new NotImplementedException();
		}

		public void Update(BookGenres bookGenres)
		{
			throw new NotImplementedException();
		}
	}
}
