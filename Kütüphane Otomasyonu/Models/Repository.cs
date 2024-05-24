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
			_context.Books.Include(k => k.BookGenres).Include(k => k.BookGenreId);
		}



		public void add(T entity)
		{
			_dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter, string? includeProps = null)
		{
			IQueryable<T> find = _dbSet;
			find=find.Where(filter);
			if (!string.IsNullOrEmpty(includeProps))
			{
				foreach (var item in includeProps.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
				{
					find = find.Include(item);
				}
			}
			return find.FirstOrDefault();
		}

		public IEnumerable<T> GetAll(string? includeProps = null)
		{
			IQueryable<T> find = _dbSet;
			if (!string.IsNullOrEmpty(includeProps))
			{
				foreach (var item in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					find = find.Include(item);
				}
			}
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
