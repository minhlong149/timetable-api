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
        public IHttpActionResult SelectStudentByClass(string MaLop, bool ChuaDangKy = false)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaLop", MaLop },
                };

                string StoredProcedureName = ChuaDangKy ? "SelectStudentCanRegisterClass" : "SelectStudentByClass";
                return Ok(Database.Database.readTable(StoredProcedureName, param));
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
