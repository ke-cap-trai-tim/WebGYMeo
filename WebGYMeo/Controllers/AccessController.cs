using Microsoft.AspNetCore.Mvc;
using WebGYMeo.Models;

namespace WebBanVaLi.Controllers
{
    public class AccessController : Controller
    {
        QlGymContext db = new QlGymContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("TenDangNhap") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("GioiThieu", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(KhachHang user)
        {
            if (HttpContext.Session.GetString("TenDangNhap") == null)
            {
                var u = db.KhachHangs.Where(x => x.TenDangNhap.Equals(user.TenDangNhap)/*&& x.LoaiUser.Equals(user.LoaiUser)*/ && x.Mk.Equals(user.Mk)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("TenDangNhap", u.TenDangNhap.ToString());
                   
                   
                        return RedirectToAction("GioiThieu", "Home");

                
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("TenDangNhap");
            return RedirectToAction("Login", "Access");
        }
        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]

        //public IActionResult Register(TUser user)
        //{
        //    QlbanValiContext userContext = new QlbanValiContext();
        //    try
        //    {
        //        var userData = new TUser()
        //        {
        //            Username = user.Username,
        //            Password = user.Password
        //        };
        //        userContext.TUsers.Add(userData);
        //        userContext.SaveChanges();
        //        ViewBag.Status = 1;
        //    }
        //    catch
        //    {
        //        ViewBag.Status = 0;
        //    }
        //    return View();
        //}


    }
}
