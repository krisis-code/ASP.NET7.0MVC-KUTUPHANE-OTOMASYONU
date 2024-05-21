using Microsoft.EntityFrameworkCore;
using SinemaOtomasyonu.Utilitiy;
using System.Linq.Expressions;

namespace KitapKiralamaOtomasyonu.Models
{
	public class Repository<T> : IRepository<T> where T : class
	{
		protected readonly AppDbContext _context;
		protected readonly DbSet<T> _dbSet;

		public Repository(AppDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}



		public void add(T entity)
		{
			_dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> find = _dbSet;
			find=find.Where(filter);
			return find.FirstOrDefault();
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> find = _dbSet;
			return find.ToList();
		}

		public void remove(T entity)
		{
			_dbSet.Remove(entity);
		}

		public void removeBetweem(IEnumerable<T> entities)
		{
			_dbSet.RemoveRange(entities);
		}
	}
}
