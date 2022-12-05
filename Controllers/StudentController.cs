using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace TimetableAPI.Controllers
{
    public class StudentController : ApiController
    {
        [Route("api/DangNhap")]
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

        [Route("api/SinhVien")]
        [HttpGet]
        public IHttpActionResult SelectClassByStudent(string MaSV)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaSV", MaSV },
                };
                    DataTable SinhVien = Database.Database.readTable("SelectClassByStudent", param);
                    return Ok(SinhVien);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/SinhVien")]
        [HttpPost]
        public IHttpActionResult InsertStudentClass(string MaSV, string MaLop)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                   { "MaSV", MaSV },
                   { "MaLop", MaLop }
                };
                return Ok(Database.Database.ExecCommand("InsertStudentClass", param));
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/SinhVien")]
        [HttpDelete]
        public IHttpActionResult DeleteStudentClass(string MaSV, string MaLop)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                   { "MaSV", MaSV },
                   { "MaLop", MaLop }
                };
                return Ok(Database.Database.ExecCommand("DeleteStudentClass", param));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
