using MyWebAPIs.AnyDataEndpoints.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebAPIs.AnyDataEndpoints.Processing
{
    public interface IAnyDataRepository
    {
        public Task<Response<dynamic>> CreateData(dynamic header, dynamic payload);
        public Task<Response<dynamic>> RetrieveData();
        public Task<Response<dynamic>> RetrieveDataPerId(int id);
        public Task<Response<dynamic>> UpdateData(int id, dynamic header, dynamic payload);
        public Task<Response<dynamic>> DeleteData(int id);
        
    }
}
