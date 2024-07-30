using Microsoft.AspNetCore.Mvc;
using GPB.Application.Dtos.ReservationDtos;
using GPB.Application.Services.ReservationServices;

namespace GPB.WebApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationServices _reservationServices;

        public ReservationController(IReservationServices reservationServices)
        {
            _reservationServices = reservationServices;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationDto model)
        {
            if (ModelState.IsValid)
            {
                await _reservationServices.CreateReservationAsync(model);
                return RedirectToAction("Index", "Home"); // Rezervasyon başarıyla oluşturulduktan sonra yönlendirme
            }
            return View(model);
        }
    }
}
