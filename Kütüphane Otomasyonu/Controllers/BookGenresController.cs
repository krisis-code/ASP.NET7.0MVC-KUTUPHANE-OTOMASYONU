using KitapKiralamaOtomasyonu.Models;
using KitapKiralamaOtomasyonu.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinemaOtomasyonu.Models;
using SinemaOtomasyonu.Utilitiy;


namespace SinemaOtomasyonu.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class BookGenresController : Controller
    {
        private readonly IBookGenreRepository _bookGenreRepository;

        public BookGenresController(IBookGenreRepository context )
        {
			_bookGenreRepository = context;
        }

        public AppDbContext Context { get; }

        public IActionResult Index()
        {
            List<BookGenres> objBookGenresList = _bookGenreRepository.GetAll().ToList();

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
				_bookGenreRepository.add(bookGenres);
				_bookGenreRepository.save();
				TempData["success"] = "Yeni kitap türü başarıyla eklendi";
                return RedirectToAction("Index");
            }
            return View();
            
        }


		
		[HttpGet]
		public IActionResult Update(Guid? BookGenreId)
		{
			if (BookGenreId == null || BookGenreId == Guid.Empty)
				return NotFound();

			var bookGenresDb = _bookGenreRepository.Get(u=>u.BookGenreId== BookGenreId);

			if (bookGenresDb == null)
				return NotFound();

			return View(bookGenresDb);
		}


		[HttpPost]
		public IActionResult Update(BookGenres bookGenres)
		{
			if (ModelState.IsValid)
			{
				_bookGenreRepository.Update(bookGenres);
                TempData["success"] = "Kitap türü başarıyla Güncellendi";
                _bookGenreRepository.save();

				return RedirectToAction("Index");
			}
			return View();

		}
		[HttpGet]
		public IActionResult Delete(Guid? BookGenreId)
		{
			if (BookGenreId == null || BookGenreId == Guid.Empty)
				return NotFound();

			var bookGenresDb = _bookGenreRepository.Get(u=>u.BookGenreId== BookGenreId);

			if (bookGenresDb == null)
				return NotFound();

			return View(bookGenresDb);
		}


		[HttpPost]
		public IActionResult Delete(BookGenres bookGenres)
		{
			if (ModelState.IsValid)
			{
				_bookGenreRepository.remove(bookGenres);
                TempData["success"] = "Kitap türü başarıyla silindi !";
                _bookGenreRepository.save();

				return RedirectToAction("Index");
			}
			return View();

		}


	}
}
