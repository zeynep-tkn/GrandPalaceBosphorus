using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;




namespace GPB.WebApp.Controllers

{

    public class HomeController : Controller

    {

        [Authorize(Roles = "Guest")]

        public IActionResult Index()

        {

            return View();



        }

        [Authorize(Roles = "Guest")]

        public IActionResult HotelOverview()

        {

            return View();

        }




        [Authorize(Roles = "Admin")]

        public IActionResult Room()

        {

            return View();

        }

        [Authorize(Roles = "Guest")]

        public IActionResult Restaurant()

        {

            return View();

        }

        [Authorize(Roles = "Guest")]

        public IActionResult Offers()

        {

            return View();

        }

        [Authorize(Roles = "Guest")]

        public IActionResult Services()

        {

            return View();

        }







    }

}