namespace Bank_PBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bankinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IBAN_Number = c.String(nullable: false, maxLength: 34),
                        Name = c.String(nullable: false, maxLength: 100),
                        IdClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Surname = c.String(nullable: false, maxLength: 30),
                        Login = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 96),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InternalTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSender = c.Int(nullable: false),
                        IdReceiver = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InternalTransactions");
            DropTable("dbo.Clients");
            DropTable("dbo.Accounts");
        }
    }
}
