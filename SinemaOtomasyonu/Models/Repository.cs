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
			DbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> find = DbSet;
			find=find.Where(filter);
			return find.FirstOrDefault();
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> find = DbSet;
			return find.ToList();
		}

		public void remove(T entity)
		{
			DbSet.Remove(entity);
		}

		public void removeBetweem(IEnumerable<T> entities)
		{
			DbSet.RemoveRange(entities);
		}
	}
}
