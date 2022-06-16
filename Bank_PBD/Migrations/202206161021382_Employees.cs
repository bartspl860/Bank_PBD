namespace Bank_PBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employees : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employee", newName: "Employees");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Employees", newName: "Employee");
        }
    }
}
