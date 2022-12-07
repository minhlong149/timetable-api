using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableAPI.Models
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public bool QuyenAdmin { get; set; }
    }
}