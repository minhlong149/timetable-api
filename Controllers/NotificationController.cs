using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace TimetableAPI.Controllers
{
    public class NotificationController : ApiController
    {
        [Route("api/Notification")]
        [HttpGet]
        public IHttpActionResult SelectAllNotification()
        {
            try
            {
                DataTable ThongBao = Database.Database.readTable("SelectAllNotification");
                return Ok(ThongBao);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/Notification")]
        [HttpGet]
        public IHttpActionResult SelectNotificationByStudent(string MaSV)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaSV", MaSV }
                };
                DataTable ThongBao = Database.Database.readTable("SelectNotificationByStudent", param);
                return Ok(ThongBao);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/Notification")]
        [HttpPost]
        public IHttpActionResult InsertNotification(string NoiDung, string MaSV = null)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "NoiDung", NoiDung },
                    { "MaSV", MaSV }
                };
                return Ok(Database.Database.ExecCommand("InsertNotification", param));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/Notification")]
        [HttpDelete]
        public IHttpActionResult DeleteNotificationByID(int ID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "ID", ID }
                };
                return Ok(Database.Database.ExecCommand("DeleteNotificationByID", param));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [Route("api/Notification")]
        [HttpDelete]
        public IHttpActionResult DeleteNotificationByStudent(string MaSV)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "MaSV", MaSV }
                };
                return Ok(Database.Database.ExecCommand("DeleteNotificationByStudent", param));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }
    }
}
