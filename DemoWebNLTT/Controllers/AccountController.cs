using DemoWebNLTT.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebNLTT.Controllers
{
    public class AccountController : Controller
    {
        #region Variable
        TTDLContext db = new TTDLContext();
        #endregion 
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(TblTaiKhoan model, IFormCollection collection)
        {
            var tentaikhoan = model.TenTaikhoan;
            var matkhau = GetMD5(model.MatKhau);
            if (!string.IsNullOrEmpty(tentaikhoan) && string.IsNullOrEmpty(matkhau))
            {
                return RedirectToAction("Login", "Account");
            }
            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, tentaikhoan)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            var itemTaiKhoan = db.TblTaiKhoans.
                Where(x => x.TenTaikhoan == tentaikhoan && x.MatKhau == matkhau && x.TrangThai == 1).
                FirstOrDefault();
            if (itemTaiKhoan != null)
            {
                if (itemTaiKhoan.NgayHieuluc < DateTime.Now)
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Hết hiệu lực");
                    return View();
                }

            }
            else
            {
                if ((tentaikhoan == null || matkhau == null) || (tentaikhoan == null && matkhau == null))
                {
                    ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không được để trống. Vui lòng nhập lại!");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin tài khoản hoặc mật khẩu không đúng!!!");
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(TblTaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                var check = db.TblTaiKhoans.
                    FirstOrDefault(s => s.TenTaikhoan == taiKhoan.TenTaikhoan);
                if (check == null)
                {
                    taiKhoan.MatKhau = GetMD5(taiKhoan.MatKhau);
                    taiKhoan.NgayHieuluc = DateTime.Now;
                    taiKhoan.TrangThai = 1;
                    db.TblTaiKhoans.Add(taiKhoan);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Tên tài khoản đã tồn tại!");
                    return View();
                }
            }
            return View();
        }
        //Đăng xuất.
        [HttpPost]
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        //Mã hóa mật khẩu bằng MD5.
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
    }
}
