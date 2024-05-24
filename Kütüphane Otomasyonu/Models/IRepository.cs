using System.Linq.Expressions;

namespace KitapKiralamaOtomasyonu.Models
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll(string? includeProps = null);
		T Get(Expression<Func<T, bool>> filter, string? includeProps = null);
		void add(T entity);
		void remove(T entity);
		void removeBetweem(IEnumerable<T> entities);
	}
}
