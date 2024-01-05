using RecordManagement.Models;
using RecordManagementApp.DAL.Interrfaces;
using RecordManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RecordManagementApp.Controllers
{
    public class RecordController : ApiController
    {
        private readonly IRecordService _service;
        public RecordController(IRecordService service)
        {
            _service = service;
        }
        public RecordController()
        {
            // Constructor logic, if needed
        }
        [HttpPost]
        [Route("api/Record/CreateRecord")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> CreateRecord([FromBody] Record model)
        {
            var leaveExists = await _service.GetRecordById(model.RecordId);
            var result = await _service.CreateRecord(model);
            return Ok(new Response { Status = "Success", Message = "Record created successfully!" });
        }


        [HttpPut]
        [Route("api/Record/UpdateRecord")]
        public async Task<IHttpActionResult> UpdateRecord([FromBody] Record model)
        {
            var result = await _service.UpdateRecord(model);
            return Ok(new Response { Status = "Success", Message = "Record updated successfully!" });
        }


        [HttpDelete]
        [Route("api/Record/DeleteRecord")]
        public async Task<IHttpActionResult> DeleteRecord(long id)
        {
            var result = await _service.DeleteRecordById(id);
            return Ok(new Response { Status = "Success", Message = "Record deleted successfully!" });
        }


        [HttpGet]
        [Route("api/Record/GetRecordById")]
        public async Task<IHttpActionResult> GetRecordById(long id)
        {
            var record = await _service.GetRecordById(id);
            return Ok(record);
        }


        [HttpGet]
        [Route("api/Record/GetAllRecords")]
        public async Task<IEnumerable<Record>> GetAllRecords()
        {
            return _service.GetAllRecords();
        }
    }
}
