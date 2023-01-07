using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableAPI.Models
{
    public class BaiTap
    {
        public string ID { get; set; }
        public string MaSV { get; set; }
        public string MaLop { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime ThoiGian { get; set; }
        public bool HoanThanh { get; set; }
    }
}