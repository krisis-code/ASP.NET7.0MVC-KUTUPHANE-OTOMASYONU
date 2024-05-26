using KitapKiralamaOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using SinemaOtomasyonu.Models;
using System.Diagnostics;

namespace SinemaOtomasyonu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookRepository context;
        private readonly IBookRepository _bookRepository;
        private readonly IBookGenreRepository _bookGenreRepository;
        public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository, IBookGenreRepository bookGenreRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _bookGenreRepository = bookGenreRepository;
        }


        public IActionResult Index()
        {
            List<Book> objBookGenresList = _bookRepository.GetAll(includeProps: "BookGenres").ToList();


            return View(objBookGenresList);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
