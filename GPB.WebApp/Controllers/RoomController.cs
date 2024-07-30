using Microsoft.AspNetCore.Mvc;


namespace GPB.WebApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly ILogger<RoomController> _logger;

        public RoomController(ILogger<RoomController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityViewRoom()
        {
            return View();
        }
        public IActionResult EleganceRoom()
        {
            return View();
        }
        public IActionResult ComfortRoom()
        {
            return View();
        }
        public IActionResult FamilyRoom()
        {
            return View();
        }
        public IActionResult TerraceRoom()
        {
            return View();
        }
        public IActionResult CornerRoom()
        {
            return View();
        }

        public IActionResult DeluxeSuite()
        {
            return View();
        }
        public IActionResult RoyalSuite()
        {
            return View();
        }
        public IActionResult PresidentialSuite()
        {
            return View();
        }
        public IActionResult PenthouseSuite()
        {
            return View();
        }
        public IActionResult PanoramicSuite()
        {
            return View();
        }
        public IActionResult SignatureSuite()
        {
            return View();
        }

        // Yeni Detay action methodu
        public IActionResult Detay(string RoomType)
        {
            if (string.IsNullOrEmpty(RoomType))
            {
                return NotFound();
            }

            // Teklif türüne göre ilgili View'ı yükleyin
            return View(RoomType);
        }
    }
}

