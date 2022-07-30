using Microsoft.AspNetCore.Mvc;
using MyWebAPIs.AnyDataEndpoints.Model;
using MyWebAPIs.AnyDataEndpoints.Processing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebAPIs.AnyDataEndpoints.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AnyJSONController : ControllerBase
    {
        private readonly IAnyDataRepository AnyDataRepo;

        public AnyJSONController(IAnyDataRepository anyDataRepo)
        {
            AnyDataRepo = anyDataRepo;
        }

        // GET: api/<AnyJSONController>
        [HttpGet]
        public Task<Response<dynamic>> GetData()
        {
            return AnyDataRepo.RetrieveData();
        }

        // GET api/<AnyJSONController>/5
        [HttpGet("{id}")]
        public Task<Response<dynamic>> GetDataPerId(int id)
        {
            return AnyDataRepo.RetrieveDataPerId(id);
        }

        // POST api/<AnyJSONController>
        [HttpPost]
        public Task<Response<dynamic>> Post([FromBody] Request<dynamic> requestBody)
        {
            return AnyDataRepo.CreateData(requestBody.Header, requestBody.Payload);
        }

        // PUT api/<AnyJSONController>/5
        [HttpPut("{id}")]
        public Task<Response<dynamic>> Put(int id, [FromBody] Request<dynamic> requestBody)
        {
            return AnyDataRepo.UpdateData(id, requestBody.Header, requestBody.Payload);
        }

        // DELETE api/<AnyJSONController>/5
        [HttpDelete("{id}")]
        public Task<Response<dynamic>> Delete(int id)
        {
            return AnyDataRepo.DeleteData(id);
        }

    }
}
