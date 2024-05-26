using KitapKiralamaOtomasyonu.Models;
using KitapKiralamaOtomasyonu.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SinemaOtomasyonu.Models;
using SinemaOtomasyonu.Utilitiy;



namespace SinemaOtomasyonu.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class BorrowController : Controller
    {
        private readonly IBookRepository _bookRepository;
		private readonly IBorrowRepository _borrowRepository;
		public readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public BorrowController(IBorrowRepository context,IBookRepository _bookRepository, IWebHostEnvironment _webHostEnvironment,UserManager<IdentityUser> userManager)
        {
            _borrowRepository = context;
            this._bookRepository = _bookRepository;
            this._webHostEnvironment = _webHostEnvironment;
            _userManager = userManager;
        }

        public AppDbContext Context { get; }
        public IActionResult Index()
        {
            List<Borrow> objBarrowList = _borrowRepository.GetAll(includeProps: "book").ToList();

            // Borrow nesnelerine ilgili kullanıcı adlarını ekleyin
            foreach (var borrow in objBarrowList)
            {
                var user = _userManager.FindByIdAsync(borrow.UserId.ToString()).Result;
                borrow.UserName = user.UserName;
            }

            return View(objBarrowList);
        }
    



    [HttpGet]
        public async Task<IActionResult> Add()
        {
            IEnumerable<SelectListItem> UserList = _userManager.Users
        .Select(u => new SelectListItem
        {
            Text = u.UserName,
            Value = u.Id // Varsayılan olarak kullanıcıların ID'sini kullanabilirsiniz
        });

            // ViewBag üzerinden view'e geçirme
            ViewBag.UserList = UserList;

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
        public IActionResult Update(Guid? BorrowId)
        {
            if (BorrowId == null || BorrowId == Guid.Empty)
                return NotFound();

            var borrowDb = _borrowRepository.Get(u => u.BorrowId == BorrowId, includeProps: "book");

            if (borrowDb == null)
                return NotFound();

            ViewBag.BookList = _bookRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.BookName,
                    Value = k.BookId.ToString()
                }).ToList();

            return View(borrowDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                _borrowRepository.Update(borrow);
                _borrowRepository.save();
                TempData["success"] = "Kitap türü başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            ViewBag.BookList = _bookRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.BookName,
                    Value = k.BookId.ToString()
                }).ToList();

            return View(borrow);
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
