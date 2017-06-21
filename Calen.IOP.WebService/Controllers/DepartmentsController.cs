using Calen.IOP.BLL;
using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Common;
using Calen.IOP.WebService.Converters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Calen.IOP.WebService.Controllers
{
    [Route("api/[controller]")]
    public  class DepartmentsController:Controller
    {
        private DepartmentManager GetManager()
        {
            DepartmentManager dmgr = new DepartmentManager();
            return dmgr;
        }

        //GET api/departments
        [HttpGet]
        public IEnumerable<department> Get()
        {
            return GetManager().GetDepartmentTree();

        }

        // POST api/departments
        [HttpPost]
        public void Post([FromBody]department[] departments)
        {
            this.GetManager().AddDepartments(departments);
        }

        // PUT api/departments/
        [HttpPut]
        public void Put([FromBody]department[] departments)
        {
            this.GetManager().UpdateDepartments(departments);
        }

        // PUT api/departments/
        [HttpDelete]
        public void Delete([FromBody]department[] departments,bool recursive)
        {
            this.GetManager().DeleteDepartments(departments,recursive);
        }
    }
}
