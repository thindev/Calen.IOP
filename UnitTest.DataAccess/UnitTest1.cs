using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calen.IOP.DataAccess;
using Calen.IOP.DataAccess.Entities;

namespace UnitTest.DataAccess
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddEmployee()
        {
            using (IOPContext context = new IOPContext())
            {

                context.Employees.Add(new Employee {Id=Guid.NewGuid().ToString(),Name="张三",Department=null});
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void AddDepartment()
        {
            using (IOPContext context = new IOPContext())
            {
                Department d = new Department();
                d.Description = "键身房门店";
                d.Id = Guid.NewGuid().ToString();
                d.Name = "金奥健身房";
                context.Departments.Add(d);
                context.SaveChanges();
            }
        }
    }
}
