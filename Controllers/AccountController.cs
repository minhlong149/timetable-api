using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimetableAPI.Models;
using System.Data;

namespace TimetableAPI.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/TaiKhoan")]
        [HttpGet]
        public IHttpActionResult SelectStudentByCredentials(string TenDangNhap, string MatKhau)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "TenDangNhap", TenDangNhap },
                    { "MatKhau", MatKhau }
                };
                DataTable SinhVien = Database.Database.readTable("SelectStudentByCredentials", param);
                return Ok(SinhVien);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/TaiKhoan")]
        [HttpPost]
        public IHttpActionResult InsertCredentials(SinhVien sinhVien)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                   { "MaSV", sinhVien.MaSV },
                   { "TenSV", sinhVien.TenSV },
                   { "TenDangNhap", sinhVien.TenDangNhap },
                   { "MatKhau", sinhVien.MatKhau },
                   { "QuyenAdmin", sinhVien.QuyenAdmin }
                };
                return Ok(Database.Database.ExecCommand("InsertCredentials", param));
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/TaiKhoan")]
        [HttpPut]
        public IHttpActionResult UpdateCredentials(SinhVien sinhVien)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                   { "MaSV", sinhVien.MaSV },
                   { "TenSV", sinhVien.TenSV },
                   { "TenDangNhap", sinhVien.TenDangNhap },
                   { "MatKhau", sinhVien.MatKhau },
                };
                return Ok(Database.Database.ExecCommand("UpdateCredentials", param));
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/TaiKhoan")]
        [HttpDelete]
        public IHttpActionResult DeleteCredentials(string MaSV)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                   { "MaSV", MaSV }
                };
                return Ok(Database.Database.ExecCommand("DeleteCredentials", param));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
