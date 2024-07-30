using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace OtelRezervasyonSitesi.Controllers
{
    public class OffersController : Controller
    {
        private readonly ILogger<OffersController> _logger;
        public OffersController(ILogger<OffersController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TravelPulse()
        {
            return View();
        }
        public IActionResult EarlyReservation()
        {
            return View();
        }
        public IActionResult FamilyPackage()
        {
            return View();
        }
        public IActionResult StayThreePayTwo()
        {
            return View();
        }
        public IActionResult RomanticGetaway()
        {
            return View();
        }
        // Yeni Detay action methodu
        public IActionResult Detay(string OffersType)
        {
            if (string.IsNullOrEmpty(OffersType))
            {
                return NotFound();
            }

            // Teklif türüne göre ilgili View'ı yükleyin
            return View(OffersType);
        }
    }
}

