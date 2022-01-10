using System;
using System.Collections.Generic;

#nullable disable

namespace DemoWebNLTT.Models
{
    public partial class TblTaiKhoan
    {
        public int Id { get; set; }
        public string TenTaikhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenDangnhap { get; set; }
        public DateTime? NgayHieuluc { get; set; }
        public int? TrangThai { get; set; }
    }
}
