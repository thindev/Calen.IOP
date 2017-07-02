using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calen.IOP.DTO.Common;
using Calen.IOP.BLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Calen.IOP.WebService.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public int Post([FromBody]employee[] items)
        {
            EmployeeManager manager = new EmployeeManager();
            return manager.AddEmployees(items);
        }

        [HttpPost]
        public resultForEmployees Post([FromBody] criteriaForEmployees critera)
        {
            EmployeeManager manager = new EmployeeManager();
            return manager.QueryEmployees(critera);
        }

        // PUT api/values/5
        [HttpPut]
        public int Put([FromBody]employee[] items)
        {
            EmployeeManager manager = new EmployeeManager();
            return manager.UpdateEmployees(items);
        }

        // DELETE api/values/5
        [HttpDelete]
        public int Delete([FromBody] employee[] items)
        {
            EmployeeManager manager = new EmployeeManager();
            return manager.DeleteEmployees(items);

        }
    }
}
