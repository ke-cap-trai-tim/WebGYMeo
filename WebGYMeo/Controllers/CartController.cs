using Microsoft.AspNetCore.Mvc;
using WebGYMeo.Models;
using WebGYMeo.ViewModels;
using WebGYMeo.Helpers;


namespace WebGYMeo.Controllers
{
    public class CartController : Controller
    {
        QlGymContext db = new QlGymContext();

        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();

        public IActionResult GioHang()
        {
            return View(Cart);
        }

        public IActionResult AddToCart(string id, int quantity = 1)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.MaHh == id);
            if (item == null)
            {
                var hangHoa = db.SanPhams.SingleOrDefault(p => p.IdSanPham == id);
                if (hangHoa == null)
                {
                    TempData["Message"] = $"Không tìm thấy hàng hóa có mã {id}";
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    MaHh = hangHoa.IdSanPham,
                    TenHH = hangHoa.TenSanPham,
                    DonGia = hangHoa.Gia,
                    Hinh = hangHoa.AnhSanPham ?? string.Empty,
                    SoLuong = quantity
				};
                gioHang.Add(item);
            }
            else
            {
                item.SoLuong += quantity;
            }

            HttpContext.Session.Set(MySetting.CART_KEY, gioHang);

            return RedirectToAction("GioHang");
        }

        public IActionResult RemoveCart(string id)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.MaHh == id);
            if (item != null)
            {
                gioHang.Remove(item);
                HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
            }
            return RedirectToAction("GioHang");
        }
    }
}
