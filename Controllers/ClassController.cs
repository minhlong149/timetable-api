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
    public class ClassController : ApiController
    {
        [Route("api/LopHoc")]
        [HttpGet]
        public IHttpActionResult SelectAllClass()
        {
            try
            {
                DataTable LopHoc = Database.Database.readTable("SelectAllClass");
                return Ok(LopHoc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/LopHoc")]
        [HttpGet]
        public IHttpActionResult SelectClassBySubject(string MaMon)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaMon", MaMon }
                };
                DataTable LopHoc = Database.Database.readTable("SelectClassBySubject", param);
                return Ok(LopHoc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/LopHoc")]
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

        [Route("api/LopHoc")]
        [HttpPost]
        public IHttpActionResult InsertClass(LopHoc lopHoc)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaMon", lopHoc.MaMon },
                    { "Thu", lopHoc.Thu },
                    { "Tiet", lopHoc.Tiet },
                    { "NgayBD", lopHoc.NgayBD },
                    { "NgayKT", lopHoc.NgayKT },
                    { "GiaoVien", lopHoc.GiaoVien },
                    { "PhongHoc", lopHoc.PhongHoc }
                };
                return Ok(Database.Database.ExecCommand("InsertClass", param)); 
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/LopHoc")]
        [HttpPut]
        public IHttpActionResult UpdateClass(LopHoc lopHoc)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaLop", lopHoc.MaLop },
                    { "Thu", lopHoc.Thu },
                    { "Tiet", lopHoc.Tiet },
                    { "NgayBD", lopHoc.NgayBD },
                    { "NgayKT", lopHoc.NgayKT },
                    { "GiaoVien", lopHoc.GiaoVien },
                    { "PhongHoc", lopHoc.PhongHoc }
                };
                return Ok(Database.Database.ExecCommand("UpdateClass", param));
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/LopHoc")]
        [HttpDelete]
        public IHttpActionResult DeleteClass(string maLop)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaLop", maLop },
                };
                return Ok(Database.Database.ExecCommand("DeleteClass", param));

            }
            catch
            {
                return NotFound();
            }
        }
    }
}
