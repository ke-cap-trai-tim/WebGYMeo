using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebGYMeo.Models;
using WebGYMeo.Models.Authentication;
using X.PagedList;

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

        [Authentication]
        public IActionResult Index(int? page)
        {
            var lstSanPham = db.SanPhams.AsNoTracking().OrderBy(x => x.TenSanPham);
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
       
            PagedList<SanPham> lst = new PagedList<SanPham>(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }

        [Authentication]
        public IActionResult GoiDichVu()
        {
            var lstGoi = db.GoiDichVus.ToList();

            return View(lstGoi);
        }

        [Authentication]
        public IActionResult GioiThieu()
        {

            return View();
        }

        [Authentication]
        public IActionResult ChiTietSanPham(String maSp)
        {
            var sanPham = db.SanPhams.SingleOrDefault(x => x.IdSanPham == maSp);
            var anhSanPham = db.AnhSanPhamChiTiets.Where(x => x.IdSanPham == maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);

        }

		[Authentication]
		public IActionResult ChiTietDichVu(String maDv)
		{
			var goiDichVu = db.GoiDichVus.SingleOrDefault(x => x.IdGoi == maDv);
			
			return View(goiDichVu);

		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
