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
    }
}
