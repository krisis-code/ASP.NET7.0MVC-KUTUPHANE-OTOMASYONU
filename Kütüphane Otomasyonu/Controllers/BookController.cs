using KitapKiralamaOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SinemaOtomasyonu.Models;
using SinemaOtomasyonu.Utilitiy;


namespace SinemaOtomasyonu.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
		private readonly IBookGenreRepository _bookGenreRepository;
		public readonly IWebHostEnvironment _webHostEnvironment;

		public BookController(IBookRepository context,IBookGenreRepository bookGenreRepository, IWebHostEnvironment _webHostEnvironment)
        {
            _bookRepository = context;
			_bookGenreRepository = bookGenreRepository;
			this._webHostEnvironment = _webHostEnvironment;
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
			
			IEnumerable<SelectListItem> BookGenreList = _bookGenreRepository.GetAll()
				.Select(k => new SelectListItem
				{
					Text = k.BookGenreName,
					Value = k.BookGenreId.ToString()
				});

			ViewBag.BookGenreList = BookGenreList;
			return View();
		}

		[HttpPost]
		public IActionResult Add(Book book, IFormFile? file)
		{
			if (!ModelState.IsValid)
			{
				IEnumerable<SelectListItem> BookGenreList = _bookGenreRepository.GetAll()
					.Select(k => new SelectListItem
					{
						Text = k.BookGenreName,
						Value = k.BookGenreId.ToString()
					}).ToList();
				ViewBag.BookGenreList = BookGenreList;
				return View(book); // Form verilerini koruma
			}
			string wwwRootPath = _webHostEnvironment.WebRootPath;
			string kitapPath = Path.Combine(wwwRootPath, @"img");

			if (file != null)
			{
				using (var fileStream = new FileStream(Path.Combine(kitapPath, file.FileName), FileMode.Create))
				{
					file.CopyTo(fileStream);
				}
				book.ImageUrl = @"\img\" + file.FileName;
			}



			_bookRepository.add(book);
			_bookRepository.save();
			TempData["success"] = "Yeni kitap başarıyla eklendi";
			return RedirectToAction("Index");
		}










		[HttpGet]
		public IActionResult Update(Guid? BookId)
		{
			IEnumerable<SelectListItem> BookGenreList = _bookGenreRepository.GetAll()
					.Select(k => new SelectListItem
					{
						Text = k.BookGenreName,
						Value = k.BookGenreId.ToString()
					}).ToList();
			ViewBag.BookGenreList = BookGenreList;

			
			if (BookId == null || BookId == Guid.Empty)
				return NotFound();

			var bookDb = _bookRepository.Get(u=>u.BookId== BookId);

			if (bookDb == null)
				return NotFound();

			return View(bookDb);
		}


		[HttpPost]
		public IActionResult Update(Book book,IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				string kitapPath = Path.Combine(wwwRootPath, @"img");

				if (file != null)
				{
					using (var fileStream = new FileStream(Path.Combine(kitapPath, file.FileName), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					book.ImageUrl = @"\img\" + file.FileName;
				}
				else
				{
					book.ImageUrl = book.ImageUrl;
				}
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
