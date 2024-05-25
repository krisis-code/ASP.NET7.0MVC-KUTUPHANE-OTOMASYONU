using KitapKiralamaOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SinemaOtomasyonu.Models;
using SinemaOtomasyonu.Utilitiy;


namespace SinemaOtomasyonu.Controllers
{
    public class BorrowController : Controller
    {
        private readonly IBookRepository _bookRepository;
		private readonly IBorrowRepository _borrowRepository;
		public readonly IWebHostEnvironment _webHostEnvironment;

		public BorrowController(IBorrowRepository context, IBookRepository _bookRepository, IWebHostEnvironment _webHostEnvironment)
        {
			_borrowRepository = context;
			this._bookRepository = _bookRepository;
			this._webHostEnvironment = _webHostEnvironment;
		}

        public AppDbContext Context { get; }

        public IActionResult Index()
        {
            List<Borrow> objBarrowList = _borrowRepository.GetAll(includeProps:"book").ToList();
			

            return View(objBarrowList);
        }

		[HttpGet]
		public IActionResult Add()
		{

			
			IEnumerable<SelectListItem> BookList = _bookRepository.GetAll()
				.Select(k => new SelectListItem
				{
					Text = k.BookName,
					Value = k.BookId.ToString()
				});

			ViewBag.BookList = BookList;
			return View();
		}

		[HttpPost]
		public IActionResult Add(Borrow	 borrow)
		{
			if (!ModelState.IsValid)
			{
				IEnumerable<SelectListItem> BookList = _bookRepository.GetAll()
					.Select(k => new SelectListItem
					{
						Text = k.BookName,
						Value = k.BookId.ToString()
					}).ToList();
				ViewBag.BookList = BookList;
				return View(borrow); // Form verilerini koruma
			}
			
			_borrowRepository.add(borrow);
			_borrowRepository.save();
			TempData["success"] = "Yeni kitap başarıyla eklendi";
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Update(Guid? BarrowId)
		{
			IEnumerable<SelectListItem> BookList = _bookRepository.GetAll()
					.Select(k => new SelectListItem
					{
						Text = k.BookName,
						Value = k.BookId.ToString()
					}).ToList();
			ViewBag.BookList = BookList;

			
			if (BarrowId == null || BarrowId == Guid.Empty)
				return NotFound();

			var BorrowDb = _borrowRepository.Get(u=>u.BorrowId == BarrowId);

			if (BorrowDb == null)
				return NotFound();

			return View(BorrowDb);
		}


		[HttpPost]
		public IActionResult Update(Borrow borrow)
		{
			if (ModelState.IsValid)
			{
				
				_borrowRepository.Update(borrow);
                TempData["success"] = "Kitap türü başarıyla Güncellendi";
                _borrowRepository.save();

				return RedirectToAction("Index");
			}
			return View();

		}
		[HttpGet]
		public IActionResult Delete(Guid? BarrowId)
		{
			if (BarrowId == null || BarrowId == Guid.Empty)
				return NotFound();

			var borrowDb = _borrowRepository.Get(u=>u.BorrowId == BarrowId);

			if (borrowDb == null)
				return NotFound();

			return View(borrowDb);
		}


		[HttpPost]
		public IActionResult Delete(Borrow borrow)
		{
			if (ModelState.IsValid)
			{
                _borrowRepository.remove(borrow);
                TempData["success"] = "Kitap türü başarıyla silindi !";
                _borrowRepository.save();

				return RedirectToAction("Index");
			}
			return View();

		}


	}
}
