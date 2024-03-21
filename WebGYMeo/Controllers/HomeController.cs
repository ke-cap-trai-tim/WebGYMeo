using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebGYMeo.Models;

namespace WebGYMeo.Controllers
{
    public class HomeController : Controller
    {
        QlGymContext db = new QlGymContext();
      
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lstSanPham = db.SanPhams.ToList();
            var lstGoi = db.GoiDichVus.ToList();

            return View(lstSanPham) ;
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
