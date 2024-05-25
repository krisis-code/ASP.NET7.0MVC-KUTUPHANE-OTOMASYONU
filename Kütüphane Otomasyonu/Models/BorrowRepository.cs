using Microsoft.EntityFrameworkCore;
using SinemaOtomasyonu.Models;
using SinemaOtomasyonu.Utilitiy;
using System.Linq.Expressions;

namespace KitapKiralamaOtomasyonu.Models
{
    public class BorrowRepository : Repository<Borrow> , IBorrowRepository
    {
        private readonly AppDbContext _appDbContext;

        public BorrowRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

       
        public void save()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(Borrow borrow)
        {
                _appDbContext.Update(borrow);
            
        }
    }

}
