namespace Calen.IOP.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class IOPContext : DbContext
    {
       static IOPContext()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<IOPContext>());
        }
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“IOPContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Calen.IOP.DataAccess.IOPContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“IOPContext”
        //连接字符串。
        public IOPContext()
            : base("name=IOPContext")
        {

        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

         public virtual DbSet<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}