using MyWebAPIs.AnyDataEndpoints.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebAPIs.AnyDataEndpoints.Processing
{
    public class AnyDataRepository : IAnyDataRepository
    {

        public Task<Response<dynamic>> CreateData(dynamic header, dynamic payload)
        {
            dynamic inputHeader = JsonConvert.DeserializeObject<dynamic>(header.ToString());
            dynamic inputPayload = JsonConvert.DeserializeObject<dynamic>(payload.ToString());

            //if (inputHeader.server == "01")
            //    return Task.FromResult(new Response<dynamic>() { Data = inputPayload, Success = true, Message = "Server was 01" });
            //else
            //    return Task.FromResult(new Response<dynamic>() { Data = inputHeader, Success = false, Message = "Server was NOT 01" });

            DataContext.Data = inputPayload;

            var response = Task.FromResult(new Response<dynamic>() { Data = inputPayload, Success = true, Message = "Server was UP" });

            return response;
        }

        public Task<Response<dynamic>> DeleteData(int id)
        {
            var response = Task.FromResult(new Response<dynamic>() { Data = "No data found to delete", Success = true, Message = "Server was UP" });
            dynamic data = DataContext.Data;

            if (data != null && data.uniqueId == id)
            {
                DataContext.Data = null;
                response = Task.FromResult(new Response<dynamic>() { Data = "No data exist", Success = true, Message = "Server was UP" });
            }

            return response;
        }

        public Task<Response<dynamic>> RetrieveData()
        {
            var response = Task.FromResult(new Response<dynamic>() { Data = "No data exist", Success = true, Message = "Server was UP" });

            if (DataContext.Data != null)
            {
                response = Task.FromResult(new Response<dynamic>() { Data = DataContext.Data, Success = true, Message = "Server was UP" });
            }

            return response;
        }

        public Task<Response<dynamic>> RetrieveDataPerId(int id)
        {
            var response = Task.FromResult(new Response<dynamic>() { Data = "No data found", Success = true, Message = "Server was UP" });
            dynamic data = DataContext.Data;

            if (data.uniqueId == id)
            {
                response = Task.FromResult(new Response<dynamic>() { Data = DataContext.Data, Success = true, Message = "Server was UP" });
            }

            return response;
        }

        public Task<Response<dynamic>> UpdateData(int id, dynamic header, dynamic payload)
        {
            var response = Task.FromResult(new Response<dynamic>() { Data = "No data found to update", Success = true, Message = "Server was UP" });
            dynamic data = DataContext.Data;
            dynamic inputHeader = JsonConvert.DeserializeObject<dynamic>(header.ToString());
            dynamic inputPayload = JsonConvert.DeserializeObject<dynamic>(payload.ToString());

            if (data != null && data.uniqueId == id)
            {
                DataContext.Data = inputPayload;
                response = Task.FromResult(new Response<dynamic>() { Data = DataContext.Data, Success = true, Message = "Server was UP" });
            }

            return response;
        }
    }
}
