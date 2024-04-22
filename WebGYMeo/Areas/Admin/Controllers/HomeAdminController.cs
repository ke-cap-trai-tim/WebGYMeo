using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebGYMeo.Models;
using X.PagedList;

namespace WebGYMeo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlGymContext db=new QlGymContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.SanPhams.OrderBy(x => x.TenSanPham);
            PagedList<SanPham> lst = new PagedList<SanPham>(lstsanpham, pageNumber, pageSize);
            return View(lst);

        }

        [Route("danhmuckhachhang")]
        public IActionResult DanhMucKhachHang(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstkhachhang = db.KhachHangs.OrderBy(x => x.TenKhach);
            PagedList<KhachHang> lst = new PagedList<KhachHang>(lstkhachhang, pageNumber, pageSize);
            return View(lst);

        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
           
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult ThemSanPhamMoi(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);
        }

        /*sua san pham*/
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(String maSanPham)
        {
            
            var sanPham = db.SanPhams.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult SuaSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }

        /*xóa san pham*/
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.HoaDonSanPhams.Where(x => x.IdSabPham == maSanPham).ToList();
            if (chiTietSanPham.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            var anhSanPham = db.AnhSanPhamChiTiets.Where(x => x.IdSanPham == maSanPham);
            if (anhSanPham.Any()) db.RemoveRange(anhSanPham);
            db.Remove(db.SanPhams.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }
    }
}
