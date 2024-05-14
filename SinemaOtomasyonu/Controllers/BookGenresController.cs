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
            if (ModelState.IsValid)
            {
                _appDbContext.Genres.Add(bookGenres);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
            
        }


		
		[HttpGet]
		public IActionResult Update(Guid? BookGenreId)
		{
			if (BookGenreId == null || BookGenreId == Guid.Empty)
				return NotFound();

			var bookGenresDb = _appDbContext.Genres.Find(BookGenreId);

			if (bookGenresDb == null)
				return NotFound();

			return View(bookGenresDb);
		}


		[HttpPost]
		public IActionResult Update(BookGenres bookGenres)
		{
			if (ModelState.IsValid)
			{
				_appDbContext.Genres.Update(bookGenres);
				_appDbContext.SaveChanges();

				return RedirectToAction("Index");
			}
			return View();

		}
		[HttpGet]
		public IActionResult Update(Guid? BookGenreId)
		{
			if (BookGenreId == null || BookGenreId == Guid.Empty)
				return NotFound();

			var bookGenresDb = _appDbContext.Genres.Find(BookGenreId);

			if (bookGenresDb == null)
				return NotFound();

			return View(bookGenresDb);
		}


		[HttpPost]
		public IActionResult Update(BookGenres bookGenres)
		{
			if (ModelState.IsValid)
			{
				_appDbContext.Genres.Update(bookGenres);
				_appDbContext.SaveChanges();

				return RedirectToAction("Index");
			}
			return View();

		}


	}
}
