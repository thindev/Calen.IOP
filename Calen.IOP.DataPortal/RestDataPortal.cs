using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Calen.IOP.DTO.Json;
using System.Threading.Tasks;
using RestSharp.Portable.HttpClient;

namespace Calen.IOP.DataPortal
{
    public class RestDataPortal
    {
        RestClient _restClient;
        public RestDataPortal(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public async Task<ICollection<department>> GetDepartmentTree()
        {
           return await Task.Run<ICollection<department>>(new Func<ICollection<department>> (()=>
            {
                return null;
            }
            ));
        }
    }
}
