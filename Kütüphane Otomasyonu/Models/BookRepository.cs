using Microsoft.EntityFrameworkCore;
using SinemaOtomasyonu.Models;
using SinemaOtomasyonu.Utilitiy;
using System.Linq.Expressions;

namespace KitapKiralamaOtomasyonu.Models
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

       
        public void save()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(Book book)
        {
                _appDbContext.Update(book);
            
        }
    }

}
