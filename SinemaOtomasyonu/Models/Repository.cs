using Microsoft.EntityFrameworkCore;
using SinemaOtomasyonu.Utilitiy;
using System.Linq.Expressions;

namespace KitapKiralamaOtomasyonu.Models
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext _appDbContext;

		

		internal DbSet<T> DbSet;

		public Repository(AppDbContext appDbContext, DbSet<T> dbSet)
		{
			_appDbContext = appDbContext;
			DbSet = dbSet;
		}


		public void add(T entity)
		{
			throw new NotImplementedException();
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> GetAll()
		{
			throw new NotImplementedException();
		}

		public void remove(T entity)
		{
			throw new NotImplementedException();
		}

		public void removeBetweem(IEnumerable<T> entities)
		{
			throw new NotImplementedException();
		}
	}
}
