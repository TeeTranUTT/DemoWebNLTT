using DemoWebNLTT.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace DemoWebNLTT.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        #region Variable
        TTDLContext db = new TTDLContext();
        #endregion
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetChartData()
        {
            var data = db.TblThongSoNangLuongs.
                Select(x => new GoogleChartData()
                {
                    MatTroi_HT = x.MtCshienTai,
                    Gio_HT = x.GioCshienTai,
                    SinhKhoi_HT = x.SkCshienTai,
                    Tong_HT = x.TongCshienTai,
                    Tgian = x.Tgian.Value
                }).ToList();
            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Tgian",
                "Mặt Trời",
                "Gió",
                "Sinh Khối",
                "Tổng"
            };

            int j = 0;
            foreach (var i in data)
            {
                j++;
                chartData[j] = new object[] { i.Tgian.ToString(), i.MatTroi_HT, i.Gio_HT, i.SinhKhoi_HT, i.Tong_HT };
            }
            return Json(chartData);
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
