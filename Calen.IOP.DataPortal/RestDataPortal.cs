﻿using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Calen.IOP.DTO.Json;
using System.Threading.Tasks;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using Newtonsoft.Json;

namespace Calen.IOP.DataPortal
{
    public class RestDataPortal
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
    }
}
