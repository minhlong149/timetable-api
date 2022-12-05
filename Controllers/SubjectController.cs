using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
    }
}
