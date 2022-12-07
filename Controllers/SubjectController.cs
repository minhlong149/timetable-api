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
    public class SubjectController : ApiController
    {
        [Route("api/MonHoc")]
        [HttpGet]
        public IHttpActionResult SelectAllSubject()
        {
            try
            {
                DataTable MonHoc = Database.Database.readTable("SelectAllSubject");
                return Ok(MonHoc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/MonHoc")]
        [HttpPost]
        public IHttpActionResult InsertSubject(MonHoc monHoc)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaMon", monHoc.MaMon },
                    { "TenMon", monHoc.TenMon },
                    { "SoTC", monHoc.SoTC }
                };
                return Ok(Database.Database.ExecCommand("InsertSubject", param));
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/MonHoc")]
        [HttpPut]
        public IHttpActionResult UpdateSubject(MonHoc monHoc)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaMon", monHoc.MaMon },
                    { "TenMon", monHoc.TenMon },
                    { "SoTC", monHoc.SoTC }
                };
                return Ok(Database.Database.ExecCommand("UpdateSubject", param));
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/MonHoc")]
        [HttpDelete]
        public IHttpActionResult DeleteSubject(string MaMon)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaMon", MaMon },
                };
                return Ok(Database.Database.ExecCommand("DeleteSubject", param));

            }
            catch
            {
                return NotFound();
            }
        }
    }
}
