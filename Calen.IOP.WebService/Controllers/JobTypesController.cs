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
    public class JobTypesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<jobType> Get()
        {
            JobTypeManager manager = new JobTypeManager();
            return manager.GetAllJobTypes();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public int Post([FromBody]IEnumerable<jobType> items)
        {
            JobTypeManager manager = new JobTypeManager();
            return manager.AddJobTypes(items);
        }

        // PUT api/values/5
        [HttpPut]
        public int Put([FromBody]IEnumerable<jobType> items)
        {
            JobTypeManager manager = new JobTypeManager();
            return manager.UpdateJobTypes(items);
        }

        // DELETE api/values/5
        [HttpDelete]
        public int Delete([FromBody]IEnumerable<jobType> items)
        {
            JobTypeManager manager = new JobTypeManager();
            return manager.DeleteJobTypes(items);
        }
    }
}
