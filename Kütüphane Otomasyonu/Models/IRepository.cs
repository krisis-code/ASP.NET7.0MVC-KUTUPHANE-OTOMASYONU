using System.Linq.Expressions;

namespace KitapKiralamaOtomasyonu.Models
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		T Get(Expression<Func<T, bool>> filter);
		void add(T entity);
		void remove(T entity);
		void removeBetweem(IEnumerable<T> entities);
	}
}
