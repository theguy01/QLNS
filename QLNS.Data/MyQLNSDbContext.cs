namespace QLNS.Data
{
    using QLNS.Model.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyQLNSDbContext : DbContext
    {
        // Your context has been configured to use a 'MyQLNSDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QLNS.Data.MyQLNSDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyQLNSDbContext' 
        // connection string in the application configuration file.
        public MyQLNSDbContext()
            : base("name=MyQLNSDbContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer<MyQLNSDbContext>(new DropCreateDatabaseIfModelChanges<MyQLNSDbContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<WorkingProcess> WorkingProcesses { get; set; }
        public static MyQLNSDbContext Create()
        {
            return new MyQLNSDbContext();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}