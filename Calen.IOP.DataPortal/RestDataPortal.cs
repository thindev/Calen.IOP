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


        #region Departments
        public async Task<ICollection<department>> GetDepartmentTreeAsync()
        {
            var request = new RestRequest("departments", Method.GET);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            var result = JsonConvert.DeserializeObject<department[]>(content);
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
        #endregion departments

#region hireTypes
        public async Task<ICollection<hireType>> GetAllHireTypesAsync()
        {
            var request = new RestRequest("hiretypes", Method.GET);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            var result = JsonConvert.DeserializeObject<hireType[]>(content);
            return result;
        }

        public async Task<int> AddHireTypes(IEnumerable<hireType> hts)
        {
            var request = new RestRequest("hiretypes", Method.POST);
            request.AddJsonBody(hts);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }
        public async Task<int> DeleteHireTypes(IEnumerable<hireType> items)
        {
            var request = new RestRequest("hiretypes", Method.DELETE);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }

        public async Task<int> UpdateHireTypes(IEnumerable<hireType> items)
        {
            var request = new RestRequest("hiretypes", Method.PUT);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }
        #endregion hireTypes

        #region jobTypes
        public async Task<ICollection<jobType>> GetAllJobTypesAsync()
        {
            var request = new RestRequest("jobtypes", Method.GET);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            var result = JsonConvert.DeserializeObject<jobType[]>(content);
            return result;
        }

        public async Task<int> AddJobTypes(IEnumerable<jobType> items)
        {
            var request = new RestRequest("jobtypes", Method.POST);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }

        public async Task<int> DeletJobTypes(IEnumerable<jobType> items)
        {
            var request = new RestRequest("jobtypes", Method.DELETE);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }

        public async Task<int> UpdateJobTypes(IEnumerable<jobType> items)
        {
            var request = new RestRequest("jobtypes", Method.PUT);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }
        #endregion jobTypes

        #region jobPositionlevels
        public async Task<ICollection<jobPositionLevel>> GetAllJobPositionLevelsAsync()
        {
            var request = new RestRequest("jobpositionlevels", Method.GET);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            var result = JsonConvert.DeserializeObject<jobPositionLevel[]>(content);
            return result;
        }

        public async Task<int> AddJobPositionLevels(IEnumerable<jobPositionLevel> items)
        {
            var request = new RestRequest("jobpositionlevels", Method.POST);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }

        public async Task<int> DeletJobPositionLevels(IEnumerable<jobPositionLevel> items)
        {
            var request = new RestRequest("jobpositionlevels", Method.DELETE);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }

        public async Task<int> UpdateJobPositionLevels(IEnumerable<jobPositionLevel> items)
        {
            var request = new RestRequest("jobpositionlevels", Method.PUT);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }


        #endregion jobpositionlevels

        #region UserRole
        public async Task<ICollection<userRole>> GetAllUserRolesAsync()
        {
            var request = new RestRequest("userroles", Method.GET);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            var result = JsonConvert.DeserializeObject<userRole[]>(content);
            return result;
        }

        public async Task<int> AddUserRoles(IEnumerable<userRole> items)
        {
            var request = new RestRequest("userroles", Method.POST);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }

        public async Task<int> DeleteUserRoles(IEnumerable<userRole> items)
        {
            var request = new RestRequest("userroles", Method.DELETE);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }

        public async Task<int> UpdateUserRoles(IEnumerable<userRole> items)
        {
            var request = new RestRequest("userroles", Method.PUT);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }


        #endregion UserRole
        #region employee
        public async Task<resultForEmployees> FetchEmployees(criteriaForEmployees criteria)
        {
            var request = new RestRequest("employeesquery", Method.POST);
            request.AddBody(criteria);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            var result = JsonConvert.DeserializeObject<resultForEmployees>(content);
            return result;
        }

        public async Task<int> AddEmployees(IEnumerable<employee> items)
        {
            var request = new RestRequest("employees", Method.POST);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }

        public async Task<int> DeleteEmployees(IEnumerable<employee> items)
        {
            var request = new RestRequest("employees", Method.DELETE);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }

        public async Task<int> UpdateEmployees(IEnumerable<employee> items)
        {
            var request = new RestRequest("employees", Method.PUT);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }
        #endregion
        #region employee
        public async Task<IEnumerable<vipCard>> FetchAllVipCards()
        {
            var request = new RestRequest("vipcards", Method.POST);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            var result = JsonConvert.DeserializeObject<vipCard[]>(content);
            return result;
        }

        public async Task<int> AddVipCards(IEnumerable<vipCard> items)
        {
            var request = new RestRequest("vipcards", Method.POST);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }

        public async Task<int> DeleteVipCards(IEnumerable<vipCard> items)
        {
            var request = new RestRequest("vipcards", Method.DELETE);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }

        public async Task<int> UpdateVipCards(IEnumerable<vipCard> items)
        {
            var request = new RestRequest("vipcards", Method.PUT);
            request.AddJsonBody(items);
            // execute the request
            IRestResponse response = await _restClient.Execute(request);
            string content = response.Content;
            return 1;
        }
        #endregion
    }
}
