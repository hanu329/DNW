
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Bulky.Models;

namespace DNWb.Controllers
{
    public class HomeController : Controller
    {
       

        public HomeController()
        {
        }
        public IActionResult Index()
        {
            var x = Index1();
            return View("Index1",x);
        }
      
         

        public List<AllItems> Index1()
        {
            return new List<AllItems>()
            {
                new AllItems()
                {
                    Id = 1,
                    Name="Stationery",
                    Description="lorem ipsum demo demo demo",
                    Img="https://5.imimg.com/data5/XI/PZ/CQ/SELLER-89977312/stationary-goods-500x500.jpeg",
                    TimePass=5
                },
                  new AllItems()
                {
                    Id = 2,
                    Name="Grocery",
                    Description="lorem ipsum demo3 demo demo5",
                    Img="https://5.imimg.com/data5/SELLER/Default/2021/3/KO/QG/XG/3922575/all-grocery-items-500x500.jpg",
                    TimePass=2
                },
                    new AllItems()
                {
                    Id = 3,
                    Name="Bookings",
                    Description="lorem ipsum9 demo demo1 demo",
                    Img="https://www.shutterstock.com/shutterstock/photos/2172252889/display_1500/stock-vector-travel-promo-vector-design-travel-tour-text-with-special-offer-discount-with-airplane-and-location-2172252889.jpg",
                    TimePass=4
                }
            };
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