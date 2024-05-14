using Microsoft.AspNetCore.Mvc;
using SinemaOtomasyonu.Models;
using SinemaOtomasyonu.Utilitiy;


namespace SinemaOtomasyonu.Controllers
{
    public class BookGenresController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BookGenresController(AppDbContext context )
        {
            _appDbContext = context;
        }

        public AppDbContext Context { get; }

        public IActionResult Index()
        {
            List<BookGenres> objBookGenresList = _appDbContext.Genres.ToList();

                return View(objBookGenresList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BookGenres bookGenres)
        {
            _appDbContext.Genres.Add(bookGenres);
            _appDbContext.SaveChanges();

           return RedirectToAction("Index");
        }


    }
}
