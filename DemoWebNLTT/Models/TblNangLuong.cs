using System;
using System.Collections.Generic;

#nullable disable

namespace DemoWebNLTT.Models
{
    public partial class TblNangLuong
    {
        public int Id { get; set; }
        public string TenTieude { get; set; }
        public string CsHientai { get; set; }
        public string CsMax { get; set; }
        public string CsThietke { get; set; }
        public string SanluongNgay { get; set; }
        public DateTime? Tgian { get; set; }
    }
}
