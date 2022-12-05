using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace TimetableAPI.Controllers
{
    public class HomeworkController : ApiController
    {
        [Route("api/Homework")]
        [HttpGet]
        public IHttpActionResult SelectHomeWorkByStudent(string MaSV, string MaLop = null)
        {
            try
            {
                string StoredProcedureName = "SelectHomeWorkByStudent";

                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaSV", MaSV }
                };

                if (MaLop != null)
                {
                    param.Add("MaLop", MaLop);
                    StoredProcedureName = "SelectHomeWorkByStudentClass";
                }

                DataTable ThongBao = Database.Database.readTable(StoredProcedureName, param);
                return Ok(ThongBao);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/Homework")]
        [HttpPost]
        public IHttpActionResult InsertHomeWork(string MaSV, string MaLop, string NoiDung)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaSV", MaSV },
                    { "MaLop", MaLop },
                    { "NoiDung", NoiDung }
                };
                return Ok(Database.Database.ExecCommand("InsertHomeWork", param));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/Homework")]
        [HttpPut]
        public IHttpActionResult UpdateHomeWorkStatusByID(int ID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "ID", ID }
                };
                return Ok(Database.Database.ExecCommand("UpdateHomeWorkStatusByID", param));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/Homework")]
        [HttpDelete]
        public IHttpActionResult DeleteHomeWorkByID(int ID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "ID", ID }
                };
                return Ok(Database.Database.ExecCommand("DeleteHomeWorkByID", param));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }
    }
}
