using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using TimetableAPI.Models;

namespace TimetableAPI.Controllers
{
    public class HomeworkController : ApiController
    {
        [Route("api/Homework")]
        [HttpGet]
        public IHttpActionResult SelectHomeWorkByStudent(string MaSV)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaSV", MaSV }
                };

                DataTable BaiTap = Database.Database.readTable("SelectHomeWorkByStudent", param);
                return Ok(BaiTap);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/Homework")]
        [HttpGet]
        public IHttpActionResult SelectHomeWorkByStudentClass(string MaSV, string MaLop)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaSV", MaSV },
                    { "MaLop", MaLop }
                };

                DataTable BaiTap = Database.Database.readTable("SelectHomeWorkByStudentClass", param);
                return Ok(BaiTap);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/Homework")]
        [HttpPost]
        public IHttpActionResult InsertHomeWork(BaiTap baitap)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaSV", baitap.MaSV },
                    { "MaLop", baitap.MaLop },
                    { "TieuDe", baitap.TieuDe },
                    { "NoiDung", baitap.NoiDung },
                    { "ThoiGian ", baitap.ThoiGian  },
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
        public IHttpActionResult UpdateHomeWorkByID(int ID)
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
        [HttpPut]
        public IHttpActionResult UpdateHomeWorkContentByID(BaiTap baitap)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "ID", baitap.ID },
                    { "TieuDe", baitap.TieuDe },
                    { "NoiDung", baitap.NoiDung },
                    { "ThoiGian ", baitap.ThoiGian  },
                };

                return Ok(Database.Database.ExecCommand("UpdateHomeWorkContentByID", param));
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
