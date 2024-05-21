using KitapKiralamaOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using SinemaOtomasyonu.Models;
using SinemaOtomasyonu.Utilitiy;


namespace SinemaOtomasyonu.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository context )
        {
            _bookRepository = context;
        }

        public AppDbContext Context { get; }

        public IActionResult Index()
        {
            List<Book> objBookGenresList = _bookRepository.GetAll().ToList();

            return View(objBookGenresList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.add(book);
                _bookRepository.save();
				TempData["success"] = "Yeni kitap  başarıyla eklendi";
                return RedirectToAction("Index");
            }
            return View();
            
        }


		
		[HttpGet]
		public IActionResult Update(Guid? BookId)
		{
			if (BookId == null || BookId == Guid.Empty)
				return NotFound();

			var bookDb = _bookRepository.Get(u=>u.BookId== BookId);

			if (bookDb == null)
				return NotFound();

			return View(bookDb);
		}


		[HttpPost]
		public IActionResult Update(Book book)
		{
			if (ModelState.IsValid)
			{
                _bookRepository.Update(book);
                TempData["success"] = "Kitap türü başarıyla Güncellendi";
                _bookRepository.save();

				return RedirectToAction("Index");
			}
			return View();

		}
		[HttpGet]
		public IActionResult Delete(Guid? BookId)
		{
			if (BookId == null || BookId == Guid.Empty)
				return NotFound();

			var bookDb = _bookRepository.Get(u=>u.BookId== BookId);

			if (bookDb == null)
				return NotFound();

			return View(bookDb);
		}


		[HttpPost]
		public IActionResult Delete(Book book)
		{
			if (ModelState.IsValid)
			{
                _bookRepository.remove(book);
                TempData["success"] = "Kitap türü başarıyla silindi !";
                _bookRepository.save();

				return RedirectToAction("Index");
			}
			return View();

		}


	}
}
