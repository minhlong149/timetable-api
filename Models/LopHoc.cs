﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableAPI.Models
{
    public class LopHoc
    {
        public string MaLop { get; set; }
        public string MaMon { get; set; }
        public string Thu { get; set; }
        public string Tiet { get; set; }
        public string SoTiet { get; set; }
        public string TietBD { get; set; }
        public string TietKT { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public string GiaoVien { get; set; }
        public string PhongHoc { get; set; }
    }
}