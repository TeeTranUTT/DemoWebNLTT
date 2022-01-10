using System;
using System.Collections.Generic;

#nullable disable

namespace DemoWebNLTT.Models
{
    public partial class TblThongSoNangLuong
    {
        public int Id { get; set; }
        public int? MtCshienTai { get; set; }
        public int? MtCsmax { get; set; }
        public int? MtCsthietKe { get; set; }
        public int? MtCssanLuongNgay { get; set; }
        public int? GioCshienTai { get; set; }
        public int? GioCsmax { get; set; }
        public int? GioCsthietKe { get; set; }
        public int? GioCssanLuongNgay { get; set; }
        public int? SkCshienTai { get; set; }
        public int? SkCsmax { get; set; }
        public int? SkCsthietKe { get; set; }
        public int? SkCssanLuongNgay { get; set; }
        public int? TongCshienTai { get; set; }
        public int? TongCsmax { get; set; }
        public int? TongCsthietKe { get; set; }
        public int? TongCssanLuongNgay { get; set; }
        public DateTime? Tgian { get; set; }
    }
}
