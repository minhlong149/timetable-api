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
        [Route("api/SinhVien")]
        [HttpGet]
        public IHttpActionResult SelectStudentByClass(string MaLop)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaLop", MaLop },
                };
                    DataTable SinhVien = Database.Database.readTable("SelectStudentByClass", param);
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
