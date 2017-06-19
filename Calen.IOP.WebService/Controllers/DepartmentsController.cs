using Calen.IOP.BLL;
using Calen.IOP.DataAccess;
using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Json;
using Calen.IOP.WebService.Converters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calen.IOP.WebService.Controllers
{
    [Route("api/[controller]")]
    public  class DepartmentsController:Controller
    {
        DepartmentConverter _depConverter = new DepartmentConverter();
        //GET api/departments
        [HttpGet]
        public IEnumerable<department> Get()
        {
            DepartmentManager dmgr = new DepartmentManager();
            List<Department> departments= dmgr.GetAllDepartments();
            return _depConverter.ConvertToTree(departments);

        }

        // POST api/departments
        [HttpPost]
        public void Post([FromBody]department[] dArray)
        {
            if(dArray==null)
            {
                return;
            }
            
            List<Department> ds = new List<Department>();
            foreach(var d in dArray)
            {
                Department dep= _depConverter.ConvertBack(d);
                ds.Add(dep);
            }
            DepartmentManager dmgr = new DepartmentManager();
            dmgr.AddDepartments(ds);
            //using (IOPContext context = new IOPContext())
            //{
            //    Department d = new Department();
            //    d.Description = "。。。。。";
            //    d.Id = Guid.NewGuid().ToString();
            //    d.Name = "主干组织架构";
            //    d.Code = "00";
            //    context.Departments.Add(d);

            //    Department sub = new Department();
            //    sub.Description = "。。。";
            //    sub.Id = Guid.NewGuid().ToString();
            //    sub.ParentDepartment = d;
            //    sub.Code = "0001";
            //    sub.Name = "一级组织架构";
            //    context.Departments.Add(sub);
            //    context.SaveChanges();
            //}
        }
    }
}
