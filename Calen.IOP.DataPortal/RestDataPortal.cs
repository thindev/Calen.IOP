using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Calen.IOP.DTO.Common;
using System.Threading.Tasks;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using Newtonsoft.Json;

namespace Calen.IOP.DataPortal
{
    public class RestDataPortal : IDataPortal
    {
        RestClient _restClient;
        public RestDataPortal(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public async Task<ICollection<department>> GetDepartmentTreeAsync()
        {
            var request = new RestRequest("departments", Method.GET);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
           var result= JsonConvert.DeserializeObject<department[]>(content);
            return result;
        }

        public async Task AddDepartments(ICollection<department> ds)
        {
            var request = new RestRequest("departments", Method.POST);
            request.AddJsonBody(ds);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
        }

        public async Task UpdateDepartments(ICollection<department> ds)
        {
            var request = new RestRequest("departments", Method.PUT);
            request.AddJsonBody(ds);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
        }

        public async Task<int> DeleteDepartments(ICollection<department> ds, bool recursive)
        {
            var request = new RestRequest("departments", Method.DELETE);
            request.AddJsonBody(ds);
            request.AddQueryParameter("recursive", recursive);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 0;
        }
    }
}
